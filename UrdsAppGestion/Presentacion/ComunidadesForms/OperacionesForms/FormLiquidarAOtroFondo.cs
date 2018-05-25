using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    public partial class FormLiquidarAOtroFondo : Form
    {
        String idOpPasado;
        String idComunidad;
        String idEntidad;

        public FormLiquidarAOtroFondo(String idOpPasado, String idComunidad, String idEntidad)
        {
            InitializeComponent();
            this.idOpPasado = idOpPasado;
            this.idComunidad = idComunidad;
            this.idEntidad = idEntidad;
        }
        public void cargarDatagrid() {

            String sqlSelectFondos = "SELECT com_fondos.IdFondo, com_bloques.Descripcion AS Bloque, com_fondos.NombreFondo FROM com_fondos INNER JOIN com_bloques ON com_fondos.IdBloque = com_bloques.IdBloque WHERE com_fondos.IdComunidad = " + idComunidad + " AND com_fondos.Cierre <> -1;";

            dataGridView_fondos.DataSource = Persistencia.SentenciasSQL.select(sqlSelectFondos);
            dataGridView_fondos.Columns["NombreFondo"].Width = 200;
            dataGridView_fondos.Columns["Bloque"].Width = 150;
            dataGridView_fondos.Columns["IdFondo"].Width = 50;
        }

        private void FormLiquidarAOtroFondo_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            String idBloqueGG ="";
            Double totalApagar = 0.00;
            String fechaHoy = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd");
            String idCuentaCom = Logica.FuncionesTesoreria.CuentaCompesaciones(idComunidad);

            if (idCuentaCom == "No")
            {
                MessageBox.Show("Debes crear una cuenta de compesaciones para la comunidad");
                return;
            }

            String sqlBloqueGG = "SELECT IdBloque FROM com_bloques WHERE IdComunidad = " + idComunidad + " and GG = '-1'";
            DataTable bloque = Persistencia.SentenciasSQL.select(sqlBloqueGG);

            if (bloque.Rows.Count > 0)
                idBloqueGG = bloque.Rows[0][0].ToString();
            else
            {
                MessageBox.Show("No existe bloque Generales para esta Comunidad");
                return;
            }

            //BUSCO EJERCICIO
            String IdEjercicio = Logica.FuncionesTesoreria.ejercicioActivo(idComunidad, fechaHoy);
            //CREO EL MOVIMIENTO
            int idMov = Logica.FuncionesTesoreria.CreaMovimiento(IdEjercicio, idCuentaCom, "1", idEntidad, fechaHoy, "AJUSTE VENCIMIENTO LIQUIDADO");

            //BUSCO TODOS LOS VENCIMIENTOS DE ESA OPERACIÓN PARA PAGARLOS
            String sqlSelectVencimiento = "SELECT com_opdetalles.IdOpDet, com_opdetalles.IdEntidad, com_opdetalles.Fecha, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte FROM com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp WHERE(((com_operaciones.IdOp) = " + idOpPasado + "));";

            DataTable vencimientos = Persistencia.SentenciasSQL.select(sqlSelectVencimiento);

            for (int a = 0; a<vencimientos.Rows.Count;a++) {
                //CREO EL DETALLE
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(idMov.ToString(), vencimientos.Rows[a][0].ToString(), vencimientos.Rows[a][3].ToString());
                totalApagar += Convert.ToDouble(vencimientos.Rows[a][3].ToString());
            }

            //OPERACION DEVOLUCIÓN
            String sqlInsertOperacion = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdMovCrea, ImpOp, ImpOpPte, Guardada, IdURD, FAct) VALUES (" + idComunidad + "," + idEntidad + ",67800,1,'" + fechaHoy + "','VTO. ANTIGUO', 'VTO. ANTIGUO MOV" + idMov + "'," + idMov + "," + totalApagar.ToString().Replace(",", ".") + "," + totalApagar.ToString().Replace(",", ".") + ",'Si'," + Login.getId() + ",'" + fechaHoy + "')";

            int op = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertOperacion);

            //INSERTO EL IVA EN LA OPERACION
            String sqlIVA = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + op + "," + totalApagar.ToString().Replace(",", ".") + ",1,0.00)";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlIVA);

            //INSERTO EL REPARTO EN LA OPERACION
            String sqlBloq2 = "INSERT INTO com_opdetbloques (IdOp, IdBloque, Porcentaje, Importe) VALUES (" + op + "," + idBloqueGG + ",1," + totalApagar.ToString().Replace(",", ".") + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBloq2);

            //INSERTO EL VENCIMIENTO EN LA OPERACION
            String sqlDetOp2 = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe,ImpOpDetPte) VALUES (" + op + "," + idEntidad + ",'" + fechaHoy + "','" + fechaHoy + "'," + totalApagar.ToString().Replace(",", ".") + "," + totalApagar.ToString().Replace(",", ".") + ")";
            int nuevaDet = Persistencia.SentenciasSQL.InsertarGenericoID(sqlDetOp2);

            //INSERTO LA LIQUIDACION EN LA OPERACION ANTERIOR
            String sqlLiq2 = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + op + "," + LiquidacionFondo() + ",1," + totalApagar.ToString().Replace(",", ".") + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlLiq2);

            //CREO EL MOVIMIENTO
            int idMovEntrada = Logica.FuncionesTesoreria.CreaMovimiento(IdEjercicio, idCuentaCom, "8", idEntidad, fechaHoy, "AJUSTE VENCIMIENTO ANTIGUO");
            //CREO EL DETALLE
            Logica.FuncionesTesoreria.CreaDetalleMovimiento(idMovEntrada.ToString(), nuevaDet.ToString(), totalApagar.ToString().Replace(",", "."));

            MessageBox.Show("Movimiento de cuadre realizado");

            FromOperacionesVer vieja = new FromOperacionesVer(idOpPasado.ToString(), 2);
            vieja.Show();

            FromOperacionesVer nueva = new FromOperacionesVer(op.ToString(), 2);
            nueva.Show();
            
            this.Close();
        }
        private String LiquidacionFondo() {
            String sqlSelectIdLiquidacion = "SELECT com_liquidaciones.IdLiquidacion FROM com_liquidaciones WHERE com_liquidaciones.IdFondo = " + dataGridView_fondos.SelectedRows[0].Cells[0].Value.ToString();
            DataTable liquidacion =  Persistencia.SentenciasSQL.select(sqlSelectIdLiquidacion);
            if (liquidacion.Rows.Count > 0)
            {
                return liquidacion.Rows[0][0].ToString();
            }
            else
                return "";
        }
    }
}
