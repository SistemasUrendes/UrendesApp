using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms
{
    public partial class FormCuotasAlta : Form
    {
        String id_cuota_cargado = "0";
        String id_comunidad_cargado = "0";
        Cuotas form_anterior;
        DateTime inicio;
        String idSubcuenta = "70000";
        int tipoCreacion;

        public FormCuotasAlta(Cuotas form_anterior, String id_cuota_cargado, String id_comunidad_cargado)  {
            InitializeComponent();
            this.id_cuota_cargado = id_cuota_cargado;
            this.form_anterior = form_anterior;
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        public FormCuotasAlta(Cuotas form_anterior, String id_comunidad_cargado,int tipoCreacion)  {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.tipoCreacion = tipoCreacion;
        }

        private void FormCuotasAlta_Load(object sender, EventArgs e)  {
            String MetodoReparto="";

            String SelectTipoCuota = "SELECT IdTipoCuota, TipoCuota FROM com_tipocuotas";
            comboBox_TipoCuota.DataSource = Persistencia.SentenciasSQL.select(SelectTipoCuota);
            comboBox_TipoCuota.DisplayMember = "TipoCuota";
            comboBox_TipoCuota.ValueMember = "IdTipoCuota";

            //COMPRUEBO QUE TIPO DE REAPRTO TIENE EL EJERCICIO Y FILTRO LAS LIQUIDACIONES PERTINENTES
            String fecha = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");

            String sqlMetodo = "SELECT com_ejercicios.IdMetodoCuota FROM com_ejercicios WHERE(((com_ejercicios.IdComunidad) = " + id_comunidad_cargado + ") AND((com_ejercicios.FIni) <'" + fecha + "') AND ((com_ejercicios.FFin)>'" + fecha + "'));";

            //Alex --> 12/2017
            //Mejorado por salir un error de 0 filas cuando buscas una liquidación.
            DataTable ejercicios = Persistencia.SentenciasSQL.select(sqlMetodo);
            if (ejercicios.Rows.Count > 0)
                MetodoReparto = (Persistencia.SentenciasSQL.select(sqlMetodo)).Rows[0][0].ToString();
            else {
                MessageBox.Show("Debes crear un ejercicio y una liquidación.");
                return;
            }

            if (MetodoReparto == "2")  {
                String primerDia = (new DateTime(DateTime.Now.Year, 1, 1)).ToString("yyyy-MM-dd");
                String ultimoDia = (new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12))).ToString("yyyy-MM-dd");

                String SelectLiquidaciones = "SELECT com_liquidaciones.IdLiquidacion, com_liquidaciones.Liquidacion FROM com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio WHERE(((com_ejercicios.IdComunidad) = " + id_comunidad_cargado + ")) ORDER BY com_liquidaciones.IdLiquidacion DESC LIMIT 7;";

                DataTable posibles = Persistencia.SentenciasSQL.select(SelectLiquidaciones);

                comboBox_Liquidacion.DataSource = posibles;

            }
            else if (MetodoReparto == "1") {
                String anyo = DateTime.Now.Year.ToString();

                String SelectLiquidaciones = "SELECT com_liquidaciones.IdLiquidacion, com_liquidaciones.Liquidacion, com_liquidaciones.FIni FROM com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio WHERE com_ejercicios.IdComunidad = " + id_comunidad_cargado + " ORDER BY com_liquidaciones.IdLiquidacion DESC LIMIT 5 ";
                DataTable posibles = Persistencia.SentenciasSQL.select(SelectLiquidaciones);
                comboBox_Liquidacion.DataSource = posibles;
            }else {
                MessageBox.Show("Tipo de reparto diferente a 1 o 2");
            }
            comboBox_Liquidacion.DisplayMember = "Liquidacion";
            comboBox_Liquidacion.ValueMember = "IdLiquidacion";

            /////////////////////////////////////////////////////////////////////////////////////

            String SelectFondo = "SELECT IdFondo, NombreFondo FROM com_fondos WHERE IdComunidad = " + id_comunidad_cargado;
            comboBox_Fondo.DataSource = Persistencia.SentenciasSQL.select(SelectFondo);
            comboBox_Fondo.DisplayMember = "NombreFondo";
            comboBox_Fondo.ValueMember = "IdFondo";

            String SelectPlantillas = "SELECT com_cuotamanual.IdCuotaManual, com_cuotamanual.NombreCuotaManual FROM com_cuotamanual WHERE (((com_cuotamanual.Activa) = -1) And((com_cuotamanual.IdComunidad) = " + id_comunidad_cargado + ")) ORDER BY com_cuotamanual.NombreCuotaManual;";

            comboBox_PlantillaCuota.DataSource = Persistencia.SentenciasSQL.select(SelectPlantillas);
            comboBox_PlantillaCuota.DisplayMember = "NombreCuotaManual";
            comboBox_PlantillaCuota.ValueMember = "IdCuotaManual";

            String MetodosCuotas = "SELECT IdMetodoCuota,Método FROM com_metodoscuotas";
            comboBox_MetodoCuota.DataSource = Persistencia.SentenciasSQL.select(MetodosCuotas);
            comboBox_MetodoCuota.DisplayMember = "Método";
            comboBox_MetodoCuota.ValueMember = "IdMetodoCuota";

            textBox_estado.Text = "Abierta";
            textBox_FEmision.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToShortDateString();
            textBox_FVencimiento.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).ToShortDateString();

            comboBox_Fondo.Enabled = false;
            label9.Enabled = false;
                
        }

        private void comboBox_TipoCuota_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_TipoCuota.SelectedValue.ToString() != "2")  {
                comboBox_Fondo.Enabled = false;
                label9.Enabled = false;
            }else {
                comboBox_Fondo.Enabled = true;
                label9.Enabled = true;
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            String IdFondo = "NULL";
            if (checkBox_liquidable.Checked) 
                idSubcuenta = comboBox_subcuenta.SelectedValue.ToString();
            

            this.Cursor = Cursors.WaitCursor;
            if (comboBox_Fondo.SelectedValue != null && checkBox_fondo.Checked) {
                IdFondo = comboBox_Fondo.SelectedValue.ToString();
            }
                progressBar1.Visible = true;
                button_Cancelar.Enabled = false;
                button_Guardar.Enabled = false;
                inicio = DateTime.Now;

                String fechaInicio = (Convert.ToDateTime(textBox_FEmision.Text)).ToString("yyyy-MM-dd");
                String fechaFin = (Convert.ToDateTime(textBox_FVencimiento.Text)).ToString("yyyy-MM-dd");

                int id_cuota = 0;
                String sqlInsert = "";
                if (comboBox_Fondo.Enabled && checkBox_fondo.Checked)
                {
                    sqlInsert = "INSERT INTO com_cuotas (Descripcion, IdLiquidacion, IdTipoCuota, IdFondo, IdMetodo, FEmision, FVto, IdEstado) VALUES ('" + textBox_Cuota.Text + "'," + comboBox_Liquidacion.SelectedValue.ToString() + "," + comboBox_TipoCuota.SelectedValue.ToString() + "," + IdFondo + "," + comboBox_MetodoCuota.SelectedValue.ToString() + ",'" + fechaInicio + "','" + fechaFin + "','1')";
                }
                else
                {
                    sqlInsert = "INSERT INTO com_cuotas (Descripcion, IdLiquidacion, IdTipoCuota, IdMetodo, FEmision, FVto, IdEstado) VALUES ('" + textBox_Cuota.Text + "'," + comboBox_Liquidacion.SelectedValue.ToString() + "," + comboBox_TipoCuota.SelectedValue.ToString() + "," + comboBox_MetodoCuota.SelectedValue.ToString() + ",'" + fechaInicio + "','" + fechaFin + "','1')";
                }

                if (sqlInsert != "")
                    id_cuota = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert);
            
            //Aumento el porcentaje
            progressBar1.Value = 20;

            if (tipoCreacion == 1)
            {

                if (comboBox_MetodoCuota.SelectedIndex == 0)
                {
                    creoCuotaFija(id_cuota.ToString(), fechaInicio);
                    progressBar1.Value = 100;
                }
                else if (comboBox_MetodoCuota.SelectedIndex == 1)
                {
                    creoCuotaReal(id_cuota.ToString(), fechaInicio);
                    progressBar1.Value = 100;
                }
            }else if (tipoCreacion == 2 && comboBox_MetodoCuota.SelectedIndex == 0) {
                creoCuotaFijaConDetalles(id_cuota.ToString(), fechaInicio);
                progressBar1.Value = 100;
            }
            else {
                MessageBox.Show("No se puede crear a cuota real");
            }
            this.Cursor = Cursors.Arrow;
            form_anterior.cargarDatagrid();
            this.Close();
        }
        private void creoCuotaReal(String id_cuota, String fecha)
        {
            String sqlBloquesNeg = "SELECT com_liqreparto.IdLiquidacion, com_liqreparto.IdBloque, com_liqreparto.ImpBloque AS PrimeroDeImpBloque FROM com_liqreparto GROUP BY com_liqreparto.IdLiquidacion, com_liqreparto.IdBloque HAVING (((com_liqreparto.IdLiquidacion)=" + comboBox_Liquidacion.SelectedValue.ToString() + ") AND (com_liqreparto.ImpBloque<0));";

            DataTable bloquesNegativos = Persistencia.SentenciasSQL.select(sqlBloquesNeg);

            if (bloquesNegativos.Rows.Count > 0) {
                String nombreBloque = (Persistencia.SentenciasSQL.select("SELECT Descripcion FROM com_bloques WHERE IdBloque = " + bloquesNegativos.Rows[0][1].ToString())).Rows[0][0].ToString();

                MessageBox.Show("El bloque " + nombreBloque + " sale negativo. Por tanto tendras que generar una remesa de abono para dicho bloque.");
            }

            String fechaAhora = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd");
            progressBar1.Value = 50;
            String sqlCreoCabecera = "INSERT INTO com_operaciones ( IdDivision, ImpOp, ImpOpPte, IdCuota, IdSubCuenta, IdTipoReparto, Fecha,IdURD, FAct, Documento, Descripcion, IdEntidad, IdComunidad ) SELECT com_liqreparto.IdDivision, Sum(com_liqreparto.Importe) AS SumaDeImporte, Sum(com_liqreparto.Importe)AS SumaPte, " + id_cuota + " AS Cuota, 70000 AS SubCuenta, 1 AS TipoReparto,'" + fecha + "' as Fecha, " + Login.getId() + " AS Urds, '" + fechaAhora + "' AS FCrea, CONCAT ('C'," + id_cuota + ",'/',com_liqreparto.IdDivision) AS Doc,  CONCAT ( com_divisiones.Division,' - ','" + textBox_Cuota.Text + "') AS Descrip, com_comuneros.IdEntidad, com_comuneros.IdComunidad FROM(com_asociacion INNER JOIN(com_liqreparto INNER JOIN com_divisiones ON com_liqreparto.IdDivision = com_divisiones.IdDivision) ON com_asociacion.IdDivision = com_liqreparto.IdDivision) INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero GROUP BY com_liqreparto.IdDivision, com_liqreparto.idLiquidacion, com_liqreparto.DivPar, com_asociacion.Ppal, com_comuneros.IdEntidad, com_comuneros.IdComunidad HAVING(((com_liqreparto.idLiquidacion) = " + comboBox_Liquidacion.SelectedValue.ToString() + ") AND((com_liqreparto.DivPar) = 1) AND((com_asociacion.Ppal) = -1));";

            Persistencia.SentenciasSQL.InsertarGenerico(sqlCreoCabecera);

            //Crea Bloques
            String sqlAddBloques = "INSERT INTO com_opdetbloques(IdBloque, Importe, IdOp) SELECT com_liqreparto.IdBloque, com_liqreparto.Importe, com_operaciones.IdOp FROM com_liqreparto INNER JOIN com_operaciones ON com_liqreparto.IdDivision = com_operaciones.IdDivision WHERE (((com_operaciones.IdCuota)=" + id_cuota + ") AND ((com_liqreparto.IdLiquidacion)=" + comboBox_Liquidacion.SelectedValue.ToString() + ") AND ((com_liqreparto.divpar=1)));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlAddBloques);

            //Actualiza porcentajes en Bloques
            String sqlActBloquesPorc = "UPDATE com_opdetbloques INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp SET com_opdetbloques.Porcentaje = `com_opdetbloques`.`importe`/`com_operaciones`.`impop` WHERE (((com_operaciones.IdCuota)=" + id_cuota + "));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlActBloquesPorc);

            //Añadir IVA
            String sqlAddIVA = "INSERT INTO com_opdetiva ( IdOp, Base, IdIVA, IVA ) SELECT com_operaciones.IdOp, com_operaciones.ImpOp, 1 AS IdIVA, 0 AS IVA From com_operaciones WHERE (((com_operaciones.IdCuota)=" + id_cuota + "));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlAddIVA);

            //Añadir Liquidación
            String sqlAddLiq = "INSERT INTO com_opdetliquidacion ( IdOp, IdLiquidacion, Porcentaje, Importe ) SELECT com_operaciones.IdOp, " + comboBox_Liquidacion.SelectedValue.ToString() + " AS Liq, 1 AS Porc, com_operaciones.ImpOp From com_operaciones WHERE (((com_operaciones.IdCuota)=" + id_cuota + "));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlAddLiq);

            String sqlTodos;
            if (comboBox_TipoCuota.SelectedValue.ToString() == "1")
            {
                sqlTodos = "SELECT com_operaciones.IdOp, com_operaciones.IdEntidad, com_operaciones.Fecha, com_operaciones.Fecha, com_operaciones.ImpOp, com_operaciones.ImpOp, com_repartos.IdDivision, com_repartos.IdTipoCuota, com_repartos.Act, com_divisiones.Excluido FROM(com_operaciones INNER JOIN com_divisiones ON(com_operaciones.IdDivision = com_divisiones.IdDivision) AND(com_operaciones.IdDivision = com_divisiones.IdDivision)) LEFT JOIN com_repartos ON com_divisiones.IdDivision = com_repartos.IdDivision WHERE(((com_operaciones.IdCuota) = " + id_cuota + ") AND((com_repartos.IdTipoCuota) = 1) AND((com_repartos.Act) = -1) AND((com_divisiones.Excluido) = 0));";
            }
            else
            {
                sqlTodos = "SELECT com_operaciones.IdOp, com_operaciones.IdEntidad, com_operaciones.Fecha, com_operaciones.Fecha, com_operaciones.ImpOp, com_operaciones.ImpOp, com_repartos.IdDivision, com_repartos.IdTipoCuota, com_repartos.Act FROM(com_operaciones INNER JOIN com_divisiones ON com_operaciones.IdDivision = com_divisiones.IdDivision) INNER JOIN com_repartos ON com_divisiones.IdDivision = com_repartos.IdDivision WHERE(((com_operaciones.IdCuota) = " + id_cuota + ") AND((com_repartos.IdTipoCuota) = 2) AND((com_repartos.Act) = -1));";
            }
            DataTable reparto = Persistencia.SentenciasSQL.select(sqlTodos);
            double varImpAsig = 0.00;

            for (int a = 0; a < reparto.Rows.Count; a++)
            {
                String sqlReglas = "SELECT com_repartos.IdDivision, com_repartos.idtipocuota, com_repartos.Act, com_comuneros.IdEntidad, com_detrepartos.Porcentaje, com_detrepartos.ImporteFijo FROM (com_detrepartos INNER JOIN com_repartos ON com_detrepartos.IdReparto = com_repartos.IdReparto) INNER JOIN com_comuneros ON com_detrepartos.IdComunero = com_comuneros.IdComunero WHERE (((com_repartos.IdDivision)=" + reparto.Rows[a][6].ToString() + ") AND (com_repartos.idtipocuota =" + comboBox_TipoCuota.SelectedValue.ToString() + ") AND ((com_repartos.Act)=-1));";

                DataTable rstReglas = Persistencia.SentenciasSQL.select(sqlReglas);
                double varImpPte = Convert.ToDouble(reparto.Rows[a][4].ToString());
                int TotalReglas = reparto.Rows.Count;
                int NRegla = 0;

                for (int b = 0; b < rstReglas.Rows.Count; b++)
                {
                    String varEnt = rstReglas.Rows[b][3].ToString();
                    if (Convert.ToDouble(rstReglas.Rows[b][5].ToString()) != 0)
                    {
                        if (Convert.ToDouble(rstReglas.Rows[b][5].ToString()) < varImpPte)
                        {
                            varImpAsig = Convert.ToDouble(rstReglas.Rows[b][5].ToString());
                            varImpPte = varImpPte - varImpAsig;
                        }
                        else
                        {
                            varImpAsig = varImpPte;
                            varImpPte = 0;
                        }
                    }
                    else
                    {
                        if (NRegla == TotalReglas)
                        {
                            varImpAsig = varImpPte;
                            varImpPte = 0;
                        }
                        else
                        {
                            varImpAsig = Convert.ToDouble(reparto.Rows[a][4].ToString()) * Convert.ToDouble(rstReglas.Rows[b][4].ToString());
                            varImpPte = varImpPte - varImpAsig;
                        }
                    }
                    String sqlAddDet = "INSERT INTO com_opdetalles ( IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetPte ) SELECT " + reparto.Rows[a][0].ToString() + " AS Op, " + varEnt + " AS Ent, '" + fecha + "' AS FOp, '" + fecha + "' AS FPrev, " + varImpAsig.ToString().Replace(",", ".") + " AS Imp, " + varImpAsig.ToString().Replace(",", ".") + " AS ImpPte ;";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlAddDet);
                    NRegla++;

                }
                //Si queda importe Pte de asignar, crear detalle para la entidad de la operación
                if (varImpPte >= 0.01)
                {
                    String sqlAddDet1 = "INSERT INTO com_opdetalles ( IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetPte ) SELECT " + reparto.Rows[a][0].ToString() + " AS Op, " + reparto.Rows[a][1].ToString() + " AS Ent, '" + fecha + "' AS FOp, '" + fecha + "' AS FPrev, " + varImpPte.ToString().Replace(",", ".") + " AS Imp, " + varImpPte.ToString().Replace(",", ".") + " AS ImpPte;";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlAddDet1);
                }
                varImpPte = 0;

            }
            String sqlVencimientosQueQuedan = "INSERT INTO com_opdetalles(IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetPte) SELECT com_operaciones.IdOp, com_operaciones.IdEntidad, com_operaciones.Fecha, com_operaciones.Fecha, com_operaciones.ImpOp, com_operaciones.ImpOp FROM com_operaciones LEFT JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp GROUP BY com_operaciones.IdOp, com_operaciones.IdEntidad, com_operaciones.Fecha, com_operaciones.Fecha, com_operaciones.ImpOp, com_operaciones.ImpOp, com_operaciones.IdCuota HAVING(((com_operaciones.IdCuota) = " + id_cuota + ") AND((Count(com_opdetalles.IdOpDet)) = 0));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlVencimientosQueQuedan);

            String varAgrupar = (Persistencia.SentenciasSQL.select("SELECT Recibos FROM com_comunidades WHERE IdComunidad = " + id_comunidad_cargado)).Rows[0][0].ToString();

            if (varAgrupar == "1")
            {
                String sqlActualizoFXN = "UPDATE (com_comuneros INNER JOIN (com_operaciones INNER JOIN com_asociacion ON com_operaciones.IdDivision = com_asociacion.IdDivision) ON com_comuneros.IdComunero = com_asociacion.IdComunero) INNER JOIN com_opdetalles ON (com_operaciones.IdOp = com_opdetalles.IdOp) AND (com_comuneros.IdEntidad = com_opdetalles.IdEntidad) SET com_opdetalles.FXN = CONCAT('" + id_cuota + "-',com_opdetalles.IdEntidad,'-', IFNULL(com_asociacion.IdReglarec,'')) WHERE(((com_operaciones.IdCuota) = " + id_cuota + "))";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlActualizoFXN);

                String FXN = "UPDATE (((com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN ((com_comuneros INNER JOIN com_asociacion ON com_comuneros.IdComunero = com_asociacion.IdComunero) INNER JOIN com_repartos ON com_asociacion.IdDivision = com_repartos.IdDivision) ON com_operaciones.IdEntidad = com_comuneros.IdEntidad) INNER JOIN com_detrepartos ON com_repartos.IdReparto = com_detrepartos.IdReparto) INNER JOIN com_comuneros AS com_comuneros_1 ON com_detrepartos.IdComunero = com_comuneros_1.IdComunero SET com_opdetalles.FXN = CONCAT('" + id_cuota + "-',`com_comuneros_1`.`IdEntidad`,'-') WHERE(((com_opdetalles.FXN) = '') AND((com_operaciones.IdCuota) = " + id_cuota + ") AND((com_repartos.Act) = -1)); ";
                Persistencia.SentenciasSQL.InsertarGenerico(FXN);

                if (comprueboFXN(id_cuota))
                {
                    Logica.FuncionesTesoreria.CreoRecibosAgrupados(id_comunidad_cargado, id_cuota);
                    DateTime final = DateTime.Now;
                    TimeSpan duracion = final - inicio;
                    double segundosTotales = duracion.TotalSeconds;
                    int segundos = duracion.Seconds;

                    MessageBox.Show("Cuota Creada (" + segundos.ToString() + "s)");
                }
                else
                {
                    BorrarCuota(id_cuota);
                }
            }
            else if (varAgrupar == "2")
            {
                String sqlActualizoFXN = "UPDATE (com_asociacion INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN (com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) ON com_comuneros.IdEntidad = com_operaciones.IdEntidad SET com_opdetalles.FXN = CONCAT('" + id_cuota + "-',com_opdetalles.IdEntidad,'-',com_operaciones.IdDivision,'-') WHERE(((com_operaciones.IdCuota) = " + id_cuota + ") AND((com_asociacion.IdReglaRec)Is Null));";

                Persistencia.SentenciasSQL.InsertarGenerico(sqlActualizoFXN);

                String ReglasRecibos = "SELECT com_opdetalles.IdOpDet, com_asociacion.IdReglaRec FROM(com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_asociacion ON com_operaciones.IdDivision = com_asociacion.IdDivision WHERE(((com_operaciones.IdCuota) = " + id_cuota + ") AND((com_asociacion.IdReglaRec)Is Not Null));";
                DataTable reglas = Persistencia.SentenciasSQL.select(ReglasRecibos);

                if (reglas.Rows.Count > 0)
                {
                    for (int a = 0; a < reglas.Rows.Count; a++)
                    {
                        String ActualizarFXN = "UPDATE (com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_asociacion ON com_operaciones.IdDivision = com_asociacion.IdDivision SET com_opdetalles.FXN = CONCAT('" + id_cuota + "-',com_asociacion.IdReglaRec) WHERE(((com_opdetalles.IdOpDet) = " + reglas.Rows[a][0].ToString() + "));";
                        Persistencia.SentenciasSQL.InsertarGenerico(ActualizarFXN);
                    }
                }
                if (comprueboFXN(id_cuota))
                {
                    Logica.FuncionesTesoreria.CreoRecibosAgrupados(id_comunidad_cargado, id_cuota);
                    DateTime final = DateTime.Now;
                    TimeSpan duracion = final - inicio;
                    double segundosTotales = duracion.TotalSeconds;
                    int segundos = duracion.Seconds;

                    MessageBox.Show("Cuota Creada (" + segundos.ToString() + "s)");
                }
                else
                {
                    BorrarCuota(id_cuota);
                }
            }

        }
        private void creoCuotaFijaConDetalles(String id_cuota, String fecha) {
            String fechaAhora = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd");

            String sqlCreoCabecera = "INSERT INTO com_operaciones ( IdDivision, ImpOp, ImpOpPte, IdComunidad, IdEntidad, IdCuota, Fecha, IdSubCuenta, IdTipoReparto, IdURD, FAct, Documento, Descripcion )SELECT com_cuotamanualdet.IdDivision, Sum(com_cuotamanualdet.Importe) AS SumaDeImporte, Sum(com_cuotamanualdet.Importe)AS SumaDeImportePte, com_divisiones.IdComunidad, com_comuneros.IdEntidad, " + id_cuota + " AS Cuota, com_cuotamanualdet.Fecha AS FechaCuota, " + idSubcuenta + " AS SubCuenta, 1 AS TipoReparto, " + Login.getId() + " AS Urds, '" + fechaAhora + "' AS FCrea, CONCAT ('C'," + id_cuota + ",'/',com_cuotamanualdet.IdDivision) AS Doc, com_cuotamanualdet.Referencia as descr FROM ((com_cuotamanualdet INNER JOIN com_asociacion ON com_cuotamanualdet.IdDivision = com_asociacion.IdDivision) INNER JOIN com_divisiones ON com_cuotamanualdet.IdDivision = com_divisiones.IdDivision) INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero WHERE(((com_cuotamanualdet.IdCuotaManual) = " + comboBox_PlantillaCuota.SelectedValue.ToString() + ") AND ((com_asociacion.Ppal)=-1)) GROUP BY com_cuotamanualdet.IdDivision, com_divisiones.IdComunidad, com_comuneros.IdEntidad";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlCreoCabecera);

            //Crea Bloques
            String sqlAddBloques = "INSERT INTO com_opdetbloques ( IdBloque, Importe, IdOp ) SELECT com_cuotamanualdet.IdBloque, com_cuotamanualdet.Importe, com_operaciones.IdOp FROM com_cuotamanualdet INNER JOIN com_operaciones ON com_cuotamanualdet.IdDivision = com_operaciones.IdDivision WHERE (((com_operaciones.IdCuota)=" + id_cuota + ") AND ((com_cuotamanualdet.IdCuotaManual)=" + comboBox_PlantillaCuota.SelectedValue.ToString() + ")); ";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlAddBloques);

            //Actualiza porcentajes en Bloques
            String sqlActBloquesPorc = "UPDATE com_opdetbloques INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp SET com_opdetbloques.Porcentaje = `com_opdetbloques`.`importe`/`com_operaciones`.`impop` WHERE (((com_operaciones.IdCuota)=" + id_cuota + "));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlActBloquesPorc);

            //Añadir IVA
            String sqlAddIVA = "INSERT INTO com_opdetiva ( IdOp, Base, IdIVA, IVA ) SELECT com_operaciones.IdOp, com_operaciones.ImpOp, 1 AS IdIVA, 0 AS IVA From com_operaciones WHERE (((com_operaciones.IdCuota)=" + id_cuota + "));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlAddIVA);

            //Añadir Liquidación
            String sqlAddLiq = "INSERT INTO com_opdetliquidacion ( IdOp, IdLiquidacion, Porcentaje, Importe ) SELECT com_operaciones.IdOp, " + comboBox_Liquidacion.SelectedValue.ToString() + " AS Liq, 1 AS Porc, com_operaciones.ImpOp From com_operaciones WHERE (((com_operaciones.IdCuota)=" + id_cuota + "));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlAddLiq);

            String sqlTodos;
            if (comboBox_TipoCuota.SelectedValue.ToString() == "1")
            {
                sqlTodos = "SELECT com_operaciones.IdOp, com_operaciones.IdEntidad, com_operaciones.Fecha, com_operaciones.Fecha, com_operaciones.ImpOp, com_operaciones.ImpOp, com_repartos.IdDivision, com_repartos.IdTipoCuota, com_repartos.Act, com_divisiones.Excluido FROM(com_operaciones INNER JOIN com_divisiones ON(com_operaciones.IdDivision = com_divisiones.IdDivision) AND(com_operaciones.IdDivision = com_divisiones.IdDivision)) LEFT JOIN com_repartos ON com_divisiones.IdDivision = com_repartos.IdDivision WHERE(((com_operaciones.IdCuota) = " + id_cuota + ") AND((com_repartos.IdTipoCuota) = 1) AND((com_repartos.Act) = -1) AND((com_divisiones.Excluido) = 0));";
            }
            else
            {
                sqlTodos = "SELECT com_operaciones.IdOp, com_operaciones.IdEntidad, com_operaciones.Fecha, com_operaciones.Fecha, com_operaciones.ImpOp, com_operaciones.ImpOp, com_repartos.IdDivision, com_repartos.IdTipoCuota, com_repartos.Act FROM(com_operaciones INNER JOIN com_divisiones ON com_operaciones.IdDivision = com_divisiones.IdDivision) INNER JOIN com_repartos ON com_divisiones.IdDivision = com_repartos.IdDivision WHERE(((com_operaciones.IdCuota) = " + id_cuota + ") AND((com_repartos.IdTipoCuota) = 2) AND((com_repartos.Act) = -1));";
            }
            DataTable reparto = Persistencia.SentenciasSQL.select(sqlTodos);
            double varImpAsig = 0.00;

            for (int a = 0; a < reparto.Rows.Count; a++)
            {
                String sqlReglas = "SELECT com_repartos.IdDivision, com_repartos.idtipocuota, com_repartos.Act, com_comuneros.IdEntidad, com_detrepartos.Porcentaje, com_detrepartos.ImporteFijo FROM (com_detrepartos INNER JOIN com_repartos ON com_detrepartos.IdReparto = com_repartos.IdReparto) INNER JOIN com_comuneros ON com_detrepartos.IdComunero = com_comuneros.IdComunero WHERE (((com_repartos.IdDivision)=" + reparto.Rows[a][6].ToString() + ") AND (com_repartos.idtipocuota =" + comboBox_TipoCuota.SelectedValue.ToString() + ") AND ((com_repartos.Act)=-1));";

                DataTable rstReglas = Persistencia.SentenciasSQL.select(sqlReglas);
                double varImpPte = Convert.ToDouble(reparto.Rows[a][4].ToString());
                int TotalReglas = reparto.Rows.Count;
                int NRegla = 0;

                for (int b = 0; b < rstReglas.Rows.Count; b++)
                {
                    String varEnt = rstReglas.Rows[b][3].ToString();
                    if (Convert.ToDouble(rstReglas.Rows[b][5].ToString()) != 0)
                    {
                        if (Convert.ToDouble(rstReglas.Rows[b][5].ToString()) < varImpPte)
                        {
                            varImpAsig = Convert.ToDouble(rstReglas.Rows[b][5].ToString());
                            varImpPte = varImpPte - varImpAsig;
                        }
                        else
                        {
                            varImpAsig = varImpPte;
                            varImpPte = 0;
                        }
                    }
                    else
                    {
                        if (NRegla == TotalReglas)
                        {
                            varImpAsig = varImpPte;
                            varImpPte = 0;
                        }
                        else
                        {
                            varImpAsig = Convert.ToDouble(reparto.Rows[a][4].ToString()) * Convert.ToDouble(rstReglas.Rows[b][4].ToString());
                            varImpPte = varImpPte - varImpAsig;
                        }
                    }
                    String sqlAddDet = "INSERT INTO com_opdetalles ( IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetPte ) SELECT " + reparto.Rows[a][0].ToString() + " AS Op, " + varEnt + " AS Ent, '" + reparto.Rows[a][2].ToString() + "' AS FOp, '" + reparto.Rows[a][2].ToString() + "' AS FPrev, " + varImpAsig.ToString().Replace(",", ".") + " AS Imp, " + varImpAsig.ToString().Replace(",", ".") + " AS ImpPte ;";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlAddDet);
                    NRegla++;

                }
                //Si queda importe Pte de asignar, crear detalle para la entidad de la operación
                if (varImpPte >= 0.01)
                {
                    String sqlAddDet1 = "INSERT INTO com_opdetalles ( IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetPte ) SELECT " + reparto.Rows[a][0].ToString() + " AS Op, " + reparto.Rows[a][1].ToString() + " AS Ent, '" + reparto.Rows[a][2].ToString() + "' AS FOp, '" + reparto.Rows[a][2].ToString() + "' AS FPrev, " + varImpPte.ToString().Replace(",", ".") + " AS Imp, " + varImpPte.ToString().Replace(",", ".") + " AS ImpPte;";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlAddDet1);
                }
                varImpPte = 0;

            }
            String sqlVencimientosQueQuedan = "INSERT INTO com_opdetalles(IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetPte) SELECT com_operaciones.IdOp, com_operaciones.IdEntidad, com_operaciones.Fecha, com_operaciones.Fecha, com_operaciones.ImpOp, com_operaciones.ImpOp FROM com_operaciones LEFT JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp GROUP BY com_operaciones.IdOp, com_operaciones.IdEntidad, com_operaciones.Fecha, com_operaciones.Fecha, com_operaciones.ImpOp, com_operaciones.ImpOp, com_operaciones.IdCuota HAVING(((com_operaciones.IdCuota) = " + id_cuota + ") AND((Count(com_opdetalles.IdOpDet)) = 0));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlVencimientosQueQuedan);

            String varAgrupar = (Persistencia.SentenciasSQL.select("SELECT Recibos FROM com_comunidades WHERE IdComunidad = " + id_comunidad_cargado)).Rows[0][0].ToString();
            if (varAgrupar == "1")
            {
                String sqlActualizoFXN = "UPDATE (com_comuneros INNER JOIN (com_operaciones INNER JOIN com_asociacion ON com_operaciones.IdDivision = com_asociacion.IdDivision) ON com_comuneros.IdComunero = com_asociacion.IdComunero) INNER JOIN com_opdetalles ON (com_operaciones.IdOp = com_opdetalles.IdOp) AND (com_comuneros.IdEntidad = com_opdetalles.IdEntidad) SET com_opdetalles.FXN = CONCAT('" + id_cuota + "-',com_opdetalles.IdEntidad,'-', IFNULL(com_asociacion.IdReglarec,'')) WHERE(((com_operaciones.IdCuota) = " + id_cuota + "))";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlActualizoFXN);

                String FXN = "UPDATE (((com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN ((com_comuneros INNER JOIN com_asociacion ON com_comuneros.IdComunero = com_asociacion.IdComunero) INNER JOIN com_repartos ON com_asociacion.IdDivision = com_repartos.IdDivision) ON com_operaciones.IdEntidad = com_comuneros.IdEntidad) INNER JOIN com_detrepartos ON com_repartos.IdReparto = com_detrepartos.IdReparto) INNER JOIN com_comuneros AS com_comuneros_1 ON com_detrepartos.IdComunero = com_comuneros_1.IdComunero SET com_opdetalles.FXN = CONCAT('" + id_cuota + "-',`com_comuneros_1`.`IdEntidad`,'-') WHERE(((com_opdetalles.FXN) = '') AND((com_operaciones.IdCuota) = " + id_cuota + ") AND((com_repartos.Act) = -1)); ";

                Persistencia.SentenciasSQL.InsertarGenerico(FXN);

                if (comprueboFXN(id_cuota))
                {
                    Logica.FuncionesTesoreria.CreoRecibosAgrupados(id_comunidad_cargado, id_cuota);
                }
                else
                {
                    BorrarCuota(id_cuota);
                }
            }
            else if (varAgrupar == "2")
            {
                String sqlActualizoFXN = "UPDATE (com_asociacion INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN (com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) ON com_comuneros.IdEntidad = com_operaciones.IdEntidad SET com_opdetalles.FXN = CONCAT('" + id_cuota + "-',com_opdetalles.IdEntidad,'-',com_operaciones.IdDivision) WHERE(((com_operaciones.IdCuota) = " + id_cuota + ") AND((com_asociacion.IdReglaRec)Is Null));";

                Persistencia.SentenciasSQL.InsertarGenerico(sqlActualizoFXN);

                String ReglasRecibos = "SELECT com_opdetalles.IdOpDet, com_asociacion.IdReglaRec FROM(com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_asociacion ON com_operaciones.IdDivision = com_asociacion.IdDivision WHERE(((com_operaciones.IdCuota) = " + id_cuota + ") AND((com_asociacion.IdReglaRec)Is Not Null));";
                DataTable reglas = Persistencia.SentenciasSQL.select(ReglasRecibos);
                if (reglas.Rows.Count > 0)
                {
                    for (int a = 0; a < reglas.Rows.Count; a++)
                    {
                        String ActualizarFXN = "UPDATE (com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_asociacion ON com_operaciones.IdDivision = com_asociacion.IdDivision SET com_opdetalles.FXN = CONCAT('" + id_cuota + "-',com_asociacion.IdReglaRec) WHERE(((com_opdetalles.IdOpDet) = " + reglas.Rows[a][0].ToString() + "));";
                        Persistencia.SentenciasSQL.InsertarGenerico(ActualizarFXN);
                    }
                }
                if (comprueboFXN(id_cuota))
                {
                    Logica.FuncionesTesoreria.CreoRecibosAgrupados(id_comunidad_cargado, id_cuota);
                }
                else
                {
                    BorrarCuota(id_cuota);
                }
            }
        }
        private void creoCuotaFija(String id_cuota,String fecha) {
            String fechaAhora = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd");

            String sqlCreoCabecera = "INSERT INTO com_operaciones ( IdDivision, ImpOp, ImpOpPte, IdComunidad, IdEntidad, IdCuota, Fecha, IdSubCuenta, IdTipoReparto, IdURD, FAct, Documento, Descripcion )SELECT com_cuotamanualdet.IdDivision, Sum(com_cuotamanualdet.Importe) AS SumaDeImporte, Sum(com_cuotamanualdet.Importe)AS SumaDeImportePte, com_divisiones.IdComunidad, com_comuneros.IdEntidad, " + id_cuota + " AS Cuota, '" + fecha + "' AS FechaCuota, " + idSubcuenta + " AS SubCuenta, 1 AS TipoReparto, " + Login.getId() + " AS Urds, '" + fechaAhora + "' AS FCrea, CONCAT ('C'," + id_cuota + ",'/',com_cuotamanualdet.IdDivision) AS Doc, CONCAT ( com_divisiones.Division,' - ','" + textBox_Cuota.Text + "') as descr FROM ((com_cuotamanualdet INNER JOIN com_asociacion ON com_cuotamanualdet.IdDivision = com_asociacion.IdDivision) INNER JOIN com_divisiones ON com_cuotamanualdet.IdDivision = com_divisiones.IdDivision) INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero WHERE(((com_cuotamanualdet.IdCuotaManual) = " + comboBox_PlantillaCuota.SelectedValue.ToString() + ") AND ((com_asociacion.Ppal)=-1)) GROUP BY com_cuotamanualdet.IdDivision, com_divisiones.IdComunidad, com_comuneros.IdEntidad";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlCreoCabecera);

            //Crea Bloques
            String sqlAddBloques = "INSERT INTO com_opdetbloques ( IdBloque, Importe, IdOp ) SELECT com_cuotamanualdet.IdBloque, com_cuotamanualdet.Importe, com_operaciones.IdOp FROM com_cuotamanualdet INNER JOIN com_operaciones ON com_cuotamanualdet.IdDivision = com_operaciones.IdDivision WHERE (((com_operaciones.IdCuota)=" + id_cuota + ") AND ((com_cuotamanualdet.IdCuotaManual)=" + comboBox_PlantillaCuota.SelectedValue.ToString() + ")); ";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlAddBloques);

            //Actualiza porcentajes en Bloques
            String sqlActBloquesPorc = "UPDATE com_opdetbloques INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp SET com_opdetbloques.Porcentaje = `com_opdetbloques`.`importe`/`com_operaciones`.`impop` WHERE (((com_operaciones.IdCuota)=" + id_cuota+ "));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlActBloquesPorc);

            //Añadir IVA
            String sqlAddIVA = "INSERT INTO com_opdetiva ( IdOp, Base, IdIVA, IVA ) SELECT com_operaciones.IdOp, com_operaciones.ImpOp, 1 AS IdIVA, 0 AS IVA From com_operaciones WHERE (((com_operaciones.IdCuota)=" + id_cuota + "));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlAddIVA);

            //Añadir Liquidación
            String sqlAddLiq = "INSERT INTO com_opdetliquidacion ( IdOp, IdLiquidacion, Porcentaje, Importe ) SELECT com_operaciones.IdOp, " + comboBox_Liquidacion.SelectedValue.ToString() + " AS Liq, 1 AS Porc, com_operaciones.ImpOp From com_operaciones WHERE (((com_operaciones.IdCuota)=" + id_cuota +  "));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlAddLiq);
            progressBar1.Value = progressBar1.Value + 50;

            String sqlTodos;
            if (comboBox_TipoCuota.SelectedValue.ToString() == "1") {
                sqlTodos = "SELECT com_operaciones.IdOp, com_operaciones.IdEntidad, com_operaciones.Fecha, com_operaciones.Fecha, com_operaciones.ImpOp, com_operaciones.ImpOp, com_repartos.IdDivision, com_repartos.IdTipoCuota, com_repartos.Act, com_divisiones.Excluido FROM(com_operaciones INNER JOIN com_divisiones ON(com_operaciones.IdDivision = com_divisiones.IdDivision) AND(com_operaciones.IdDivision = com_divisiones.IdDivision)) LEFT JOIN com_repartos ON com_divisiones.IdDivision = com_repartos.IdDivision WHERE(((com_operaciones.IdCuota) = " + id_cuota + ") AND((com_repartos.IdTipoCuota) = 1) AND((com_repartos.Act) = -1) AND((com_divisiones.Excluido) = 0));";
            }
            else {
                sqlTodos = "SELECT com_operaciones.IdOp, com_operaciones.IdEntidad, com_operaciones.Fecha, com_operaciones.Fecha, com_operaciones.ImpOp, com_operaciones.ImpOp, com_repartos.IdDivision, com_repartos.IdTipoCuota, com_repartos.Act FROM(com_operaciones INNER JOIN com_divisiones ON com_operaciones.IdDivision = com_divisiones.IdDivision) INNER JOIN com_repartos ON com_divisiones.IdDivision = com_repartos.IdDivision WHERE(((com_operaciones.IdCuota) = " + id_cuota + ") AND((com_repartos.IdTipoCuota) = 2) AND((com_repartos.Act) = -1));";
            }
            DataTable reparto = Persistencia.SentenciasSQL.select(sqlTodos);
            double varImpAsig = 0.00;

            for (int a = 0; a < reparto.Rows.Count;a++) {
                String sqlReglas = "SELECT com_repartos.IdDivision, com_repartos.idtipocuota, com_repartos.Act, com_comuneros.IdEntidad, com_detrepartos.Porcentaje, com_detrepartos.ImporteFijo FROM (com_detrepartos INNER JOIN com_repartos ON com_detrepartos.IdReparto = com_repartos.IdReparto) INNER JOIN com_comuneros ON com_detrepartos.IdComunero = com_comuneros.IdComunero WHERE (((com_repartos.IdDivision)=" + reparto.Rows[a][6].ToString() + ") AND (com_repartos.idtipocuota =" + comboBox_TipoCuota.SelectedValue.ToString() + ") AND ((com_repartos.Act)=-1));";

                DataTable rstReglas = Persistencia.SentenciasSQL.select(sqlReglas);
                double varImpPte = Convert.ToDouble(reparto.Rows[a][4].ToString());
                int TotalReglas = reparto.Rows.Count;
                int NRegla = 0;

                for (int b = 0; b < rstReglas.Rows.Count; b++) {
                    String varEnt = rstReglas.Rows[b][3].ToString();
                    if (Convert.ToDouble(rstReglas.Rows[b][5].ToString()) != 0) {
                        if (Convert.ToDouble(rstReglas.Rows[b][5].ToString()) < varImpPte) {
                            varImpAsig = Convert.ToDouble(rstReglas.Rows[b][5].ToString());
                            varImpPte = varImpPte - varImpAsig;
                        }else {
                            varImpAsig = varImpPte;
                            varImpPte = 0;
                        }
                    }else {
                        if (NRegla == TotalReglas) {
                            varImpAsig = varImpPte;
                            varImpPte = 0;
                        } else {
                            varImpAsig = Convert.ToDouble(reparto.Rows[a][4].ToString()) * Convert.ToDouble(rstReglas.Rows[b][4].ToString());
                            varImpPte = varImpPte - varImpAsig;
                        }
                    }
                    String sqlAddDet = "INSERT INTO com_opdetalles ( IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetPte ) SELECT " + reparto.Rows[a][0].ToString() + " AS Op, " + varEnt + " AS Ent, '" + fecha + "' AS FOp, '" + fecha + "' AS FPrev, " + varImpAsig.ToString().Replace(",",".") + " AS Imp, " + varImpAsig.ToString().Replace(",", ".") + " AS ImpPte ;";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlAddDet);
                    NRegla++;

                }
                //Si queda importe Pte de asignar, crear detalle para la entidad de la operación
                if (varImpPte >= 0.01) {
                    String sqlAddDet1 = "INSERT INTO com_opdetalles ( IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetPte ) SELECT " + reparto.Rows[a][0].ToString() + " AS Op, " + reparto.Rows[a][1].ToString() + " AS Ent, '" + fecha + "' AS FOp, '" + fecha + "' AS FPrev, " + varImpPte.ToString().Replace(",", ".") + " AS Imp, " + varImpPte.ToString().Replace(",", ".") + " AS ImpPte;";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlAddDet1);
                }
                varImpPte = 0;

            }
            String sqlVencimientosQueQuedan = "INSERT INTO com_opdetalles(IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetPte) SELECT com_operaciones.IdOp, com_operaciones.IdEntidad, com_operaciones.Fecha, com_operaciones.Fecha, com_operaciones.ImpOp, com_operaciones.ImpOp FROM com_operaciones LEFT JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp GROUP BY com_operaciones.IdOp, com_operaciones.IdEntidad, com_operaciones.Fecha, com_operaciones.Fecha, com_operaciones.ImpOp, com_operaciones.ImpOp, com_operaciones.IdCuota HAVING(((com_operaciones.IdCuota) = " + id_cuota + ") AND((Count(com_opdetalles.IdOpDet)) = 0));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlVencimientosQueQuedan);

            String varAgrupar = (Persistencia.SentenciasSQL.select("SELECT Recibos FROM com_comunidades WHERE IdComunidad = " + id_comunidad_cargado)).Rows[0][0].ToString();
            if (varAgrupar == "1")
            {
                String sqlActualizoFXN = "UPDATE (com_comuneros INNER JOIN (com_operaciones INNER JOIN com_asociacion ON com_operaciones.IdDivision = com_asociacion.IdDivision) ON com_comuneros.IdComunero = com_asociacion.IdComunero) INNER JOIN com_opdetalles ON (com_operaciones.IdOp = com_opdetalles.IdOp) AND (com_comuneros.IdEntidad = com_opdetalles.IdEntidad) SET com_opdetalles.FXN = CONCAT('" + id_cuota + "-',com_opdetalles.IdEntidad,'-', IFNULL(com_asociacion.IdReglarec,'')) WHERE(((com_operaciones.IdCuota) = " + id_cuota + "))";

                Persistencia.SentenciasSQL.InsertarGenerico(sqlActualizoFXN);

                String FXN = "UPDATE (((com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN ((com_comuneros INNER JOIN com_asociacion ON com_comuneros.IdComunero = com_asociacion.IdComunero) INNER JOIN com_repartos ON com_asociacion.IdDivision = com_repartos.IdDivision) ON com_operaciones.IdEntidad = com_comuneros.IdEntidad) INNER JOIN com_detrepartos ON com_repartos.IdReparto = com_detrepartos.IdReparto) INNER JOIN com_comuneros AS com_comuneros_1 ON com_detrepartos.IdComunero = com_comuneros_1.IdComunero SET com_opdetalles.FXN = CONCAT('" + id_cuota + "-',`com_comuneros_1`.`IdEntidad`,'-') WHERE(((com_opdetalles.FXN) = '') AND((com_operaciones.IdCuota) = " + id_cuota + ") AND((com_repartos.Act) = -1)); ";
                Persistencia.SentenciasSQL.InsertarGenerico(FXN);
                if (comprueboFXN(id_cuota))
                {
                    Logica.FuncionesTesoreria.CreoRecibosAgrupados(id_comunidad_cargado, id_cuota);
                }
                else {
                    BorrarCuota(id_cuota);
                }
            }
            else if (varAgrupar == "2")
            {
                String sqlActualizoFXN = "UPDATE (com_asociacion INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN (com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) ON com_comuneros.IdEntidad = com_operaciones.IdEntidad SET com_opdetalles.FXN = CONCAT('" + id_cuota + "-',com_opdetalles.IdEntidad,'-',com_operaciones.IdDivision,'-') WHERE(((com_operaciones.IdCuota) = " + id_cuota + ") AND((com_asociacion.IdReglaRec)Is Null));";

                Persistencia.SentenciasSQL.InsertarGenerico(sqlActualizoFXN);

                String ReglasRecibos = "SELECT com_opdetalles.IdOpDet, com_asociacion.IdReglaRec FROM(com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_asociacion ON com_operaciones.IdDivision = com_asociacion.IdDivision WHERE(((com_operaciones.IdCuota) = " + id_cuota + ") AND((com_asociacion.IdReglaRec)Is Not Null));";
                DataTable reglas = Persistencia.SentenciasSQL.select(ReglasRecibos);

                if (reglas.Rows.Count > 0)  {
                    for (int a = 0; a < reglas.Rows.Count; a++)  {
                        String ActualizarFXN = "UPDATE (com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_asociacion ON com_operaciones.IdDivision = com_asociacion.IdDivision SET com_opdetalles.FXN = CONCAT('" + id_cuota + "-',com_asociacion.IdReglaRec) WHERE(((com_opdetalles.IdOpDet) = " + reglas.Rows[a][0].ToString() + "));";

                        Persistencia.SentenciasSQL.InsertarGenerico(ActualizarFXN);
                    }
                }

                if (comprueboFXN(id_cuota))
                    Logica.FuncionesTesoreria.CreoRecibosAgrupados(id_comunidad_cargado, id_cuota);
                else
                    BorrarCuota(id_cuota);
            }
        }

        private void comboBox_MetodoCuota_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            if (combo.SelectedValue.ToString() == "2") {
                comboBox_PlantillaCuota.Enabled = false;
                label3.Enabled = false;
            }else {
                comboBox_PlantillaCuota.Enabled = true;
                label3.Enabled = true;
            }
        }
        private Boolean comprueboFXN(String IdCuota) {
            String idopDet = "";

            String sqlSelectFXNvacio = "SELECT com_opdetalles.IdOpDet, com_opdetalles.FXN FROM com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp WHERE(((com_operaciones.IdCuota) = " + IdCuota + ") AND((com_opdetalles.FXN) = ''));";
            DataTable FXNvacios = Persistencia.SentenciasSQL.select(sqlSelectFXNvacio);
            if (FXNvacios.Rows.Count > 0) {
                for (int a = 0; a <FXNvacios.Rows.Count; a++) {
                    idopDet = idopDet + FXNvacios.Rows[a][0].ToString() + "\n";
                }
                MessageBox.Show("Existen " + FXNvacios.Rows.Count + " pagadores de divisiones que no estan asociados a esa Division IdOpDet:\n" + idopDet);
                return false;
            }else {
                return true;
            }
        }
        private void BorrarCuota(String id_cuota)
        {

            String numeroMovimientos = "SELECT Count(com_detmovs.IdDetMov) AS CuentaDeIdDetMov FROM(com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_detmovs ON com_opdetalles.IdOpDet = com_detmovs.IdOpDet GROUP BY com_operaciones.IdCuota HAVING(((com_operaciones.IdCuota) = " + id_cuota + "));";

            DataTable movimientos = Persistencia.SentenciasSQL.select(numeroMovimientos);
            if (movimientos.Rows.Count > 0)
            {
                if (Convert.ToInt32(movimientos.Rows[0][0].ToString()) > 0)
                {
                    MessageBox.Show("No se puede borrar porque existen movimientos");
                }
                else if (Convert.ToInt32(movimientos.Rows[0][0].ToString()) == 0)
                {

                    //BORRO LOS RECIBOS PERTENECIENTES A ESA CUOTA
                    String sqlBorrarRecibos = "DELETE From com_recibos WHERE (((com_recibos.IdCuota) = " + id_cuota + "));";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarRecibos);

                    //BORRO LAS OPERACIONES PERTENECIENTES A ESA CUOTA
                    String sqlBorrarOperaciones = "DELETE From com_operaciones WHERE (((com_operaciones.IdCuota) = " + id_cuota + "));";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarOperaciones);

                    //BORRO LA CUOTA
                    String sqlBorrar = "DELETE FROM com_cuotas WHERE IdCuota = " + id_cuota;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);

                    MessageBox.Show("Cuota Borrada");
                }
            }
            else
            {
                //BORRO LOS RECIBOS PERTENECIENTES A ESA CUOTA
                String sqlBorrarRecibos = "DELETE From com_recibos WHERE (((com_recibos.IdCuota) = " + id_cuota + "));";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarRecibos);

                //BORRO LAS OPERACIONES PERTENECIENTES A ESA CUOTA
                String sqlBorrarOperaciones = "DELETE From com_operaciones WHERE (((com_operaciones.IdCuota) = " + id_cuota + "));";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarOperaciones);

                //BORRO LA CUOTA
                String sqlBorrar = "DELETE FROM com_cuotas WHERE IdCuota = " + id_cuota;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);

                MessageBox.Show("Cuota Borrada");
            }
        }

        private void checkBox_liquidable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_liquidable.Checked)
            {
                comboBox_subcuenta.Enabled = true;
                comboBox_subcuenta.DataSource = NewMethod();
                comboBox_subcuenta.ValueMember = "Key";
                comboBox_subcuenta.DisplayMember = "Value";
            }else {
                comboBox_subcuenta.Enabled = false;
            }
        }

        private BindingSource NewMethod()
        {
            DataTable table;
            table = Persistencia.SentenciasSQL.select("SELECT IdSubcuenta, com_subcuentas.`TIT SUBCTA` FROM com_subcuentas WHERE IdSubcuenta >= 71000 AND IdSubcuenta <= 72000;");

            DataRowCollection rows = table.Rows;

            object[] cell;
            Dictionary<int, string> dic = new Dictionary<int, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;

                dic.Add(Convert.ToInt32(cell[0]), cell[0].ToString() + " - " + cell[1].ToString());

                cell = null;
            }

            binding.DataSource = dic;
            return binding;
        }
        public static AutoCompleteStringCollection LoadAutoComplete()
        {
            DataTable table;
            table = Persistencia.SentenciasSQL.select("SELECT IdSubcuenta, com_subcuentas.`TIT SUBCTA` FROM com_subcuentas WHERE IdSubcuenta >= 71000 AND IdSubcuenta <= 72000;");

            DataTable dt = table;

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row["IdSubcuenta"]) + " - " + Convert.ToString(row["TIT SUBCTA"]));
            }

            return stringCol;
        }
    }
}
