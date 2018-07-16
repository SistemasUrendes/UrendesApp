using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    public partial class FormOperacionesAjustarFavorita : Form
    {
        String id_op_fav = "0";
        String id_op_bbdd;
        DataTable datos;
        String id_comunidad_cargado;
        Boolean masDeUnaLineaIVA = false;
        Boolean masDeUnaLineaVencimientos = false;
        String textoBuscar;

        int id_op;

        public FormOperacionesAjustarFavorita(String id_op_fav, String textoBuscar)
        {
            InitializeComponent();
            this.id_op_fav = id_op_fav;
            this.textoBuscar = textoBuscar;
        }

        private void FormOperacionesAjustarFavorita_Load(object sender, EventArgs e)
        {
            cargartextbox();
        }
        private void cargartextbox()
        {
            if (id_op_fav != "0")
            {
                String sqlSelect = "SELECT IdOp, NomFavo, FechaFavo, DocFavo, ImpFavo FROM com_opfavoritas WHERE IdOpFav = " + id_op_fav;
                datos = Persistencia.SentenciasSQL.select(sqlSelect);
                textBox_documento.Text = datos.Rows[0][3].ToString();
                textBox_importe.Text = datos.Rows[0][4].ToString();
                textBox_nuevo_nombre.Text = datos.Rows[0][1].ToString();
                maskedTextBox_nueva_fecha.Text = datos.Rows[0][2].ToString();
                id_op_bbdd = datos.Rows[0][0].ToString();
            }
        }

        private void button_crear_Click(object sender, EventArgs e)
        {
            //CREAMOS CABECERA 
            String sqlInsertCabe = "";
            String fechaOp;
            if (id_op_bbdd != "")
            {
                try
                {
                    fechaOp = (Convert.ToDateTime(maskedTextBox_nueva_fecha.Text)).ToString("yyyy-MM-dd");
                }
                catch (Exception)
                {
                    MessageBox.Show("Comprueba la fecha de la operación.");
                    return;
                }
                String fechaAhora = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd hh:mm:ss");
                String sqlSelectCabe = "SELECT IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, IdRetencion, BaseRet, Retencion, Notas, IdCuota, IdDivision, IdExpte FROM com_operaciones WHERE (((com_operaciones.IdOp) = " + id_op_bbdd + "));";

                DataTable cabecera = Persistencia.SentenciasSQL.select(sqlSelectCabe);

                id_comunidad_cargado = cabecera.Rows[0][0].ToString();

                if (cabecera.Rows[0][3].ToString() == "1")
                {
                    if (cabecera.Rows[0][10].ToString() == "")
                    {
                        sqlInsertCabe = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion,IdRetencion, BaseRet, Retencion, Notas, IdEstado, ImpOp, ImpOpPte, NumMov, Guardada, IdURD, FAct) VALUES (" + cabecera.Rows[0][0].ToString() + "," + cabecera.Rows[0][1].ToString() + "," + cabecera.Rows[0][2].ToString() + "," + cabecera.Rows[0][3].ToString() + ",'" + fechaOp + "','" + textBox_documento.Text + "','" + textBox_nuevo_nombre.Text + "'," + cabecera.Rows[0][4].ToString() + "," + cabecera.Rows[0][5].ToString().Replace(',', '.') + "," + cabecera.Rows[0][6].ToString().Replace(',', '.') + ",'" + cabecera.Rows[0][7].ToString() + "',1," + textBox_importe.Text.Replace(',', '.') + "," + textBox_importe.Text.Replace(',', '.') + ",0,'No'," + Login.getId() + ",'" + fechaAhora + "')";
                    }
                    else
                    {
                        sqlInsertCabe = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion,IdRetencion, BaseRet, Retencion, Notas, IdEstado, IdExpte, ImpOp, ImpOpPte, NumMov, Guardada, IdURD, FAct) VALUES (" + cabecera.Rows[0][0].ToString() + "," + cabecera.Rows[0][1].ToString() + "," + cabecera.Rows[0][2].ToString() + "," + cabecera.Rows[0][3].ToString() + ",'" + fechaOp + "','" + textBox_documento.Text + "','" + textBox_nuevo_nombre.Text + "'," + cabecera.Rows[0][4].ToString() + "," + cabecera.Rows[0][5].ToString().Replace(',', '.') + "," + cabecera.Rows[0][6].ToString().Replace(',', '.') + ",'" + cabecera.Rows[0][7].ToString() + "',1," + cabecera.Rows[0][10].ToString() + "," + textBox_importe.Text.Replace(',', '.') + "," + textBox_importe.Text.Replace(',', '.') + ",0,'No'," + Login.getId() + ",'" + fechaAhora + "')";
                    }
                    id_op = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertCabe);
                    if (Convert.ToDouble(cabecera.Rows[0][6].ToString()) > 0.00)
                        tieneRetencion(id_op.ToString(), fechaOp);

                    //CREAMOS IVA
                    String sqlSelectIva = "SELECT aux_iva.`%IVA`, com_opdetiva.IdIVA FROM com_opdetiva INNER JOIN aux_iva ON com_opdetiva.IdIVA = aux_iva.IdIVA WHERE(((com_opdetiva.IdOp) = " + id_op_bbdd + "));";

                    DataTable iva = Persistencia.SentenciasSQL.select(sqlSelectIva);
                    if (iva.Rows.Count == 1)
                    {
                        int ivaPer = Convert.ToInt32(iva.Rows[0][0].ToString());
                        double ivaPerIntermedio = ivaPer / 100.00;
                        double baseIVA = Convert.ToDouble(textBox_importe.Text.Replace('.', ',')) / (ivaPerIntermedio + 1);

                        double ivaTotal = ((baseIVA * ivaPer) / 100.00);

                        String sqlInsert = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + id_op + "," + baseIVA.ToString().Replace(',', '.') + "," + iva.Rows[0][1].ToString() + "," + ivaTotal.ToString().Replace(',', '.') + ")";
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                    }
                    else
                    {
                        MessageBox.Show("La Operacion tiene mas de una linea de IVA, por tanto se tiene que añadir el IVA manualmente.");
                        String sqlTodosIvas = "SELECT Base, IdIVA, IVA FROM com_opdetiva WHERE IdOp = " + id_op_bbdd;
                        DataTable variosIvas = Persistencia.SentenciasSQL.select(sqlTodosIvas);
                        for (int a = 0; a < variosIvas.Rows.Count; a++)
                        {
                            String sqlInsertIvas = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + id_op + "," + variosIvas.Rows[a][0].ToString().Replace(',', '.') + "," + variosIvas.Rows[a][1].ToString() + "," + variosIvas.Rows[a][2].ToString().Replace(',', '.') + ")";
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertIvas);
                        }

                        masDeUnaLineaIVA = true;
                    }

                    //CREAMOS REPARTO
                    String sqlSelectReparto = "SELECT IdBloque, Porcentaje FROM com_opdetbloques WHERE IdOp = " + id_op_bbdd + ";";
                    DataTable repartos = Persistencia.SentenciasSQL.select(sqlSelectReparto);
                    for (int a = 0; a < repartos.Rows.Count; a++)
                    {

                        double porcentaje = Convert.ToDouble(repartos.Rows[a][1].ToString()) * 100;

                        double total = (Convert.ToDouble(textBox_importe.Text.Replace('.', ',')) * porcentaje) / 100;

                        String sqlInsertReparto = "INSERT INTO com_opdetbloques (IdOp, IdBloque, Porcentaje, Importe) VALUES (" + id_op + "," + repartos.Rows[a][0].ToString() + "," + repartos.Rows[a][1].ToString().Replace(',', '.') + "," + total.ToString().Replace(',', '.') + ")";
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertReparto);
                    }

                    //CREAMOS VENCIMIENTOS
                    String sqlEntidadVencimiento = "SELECT IdEntidad, Importe FROM com_opdetalles WHERE com_opdetalles.IdOp = " + id_op_bbdd + ";";
                    DataTable vencimientos = Persistencia.SentenciasSQL.select(sqlEntidadVencimiento);
                    String fechaAhora2 = (Convert.ToDateTime(fechaOp)).ToString("yyyy-MM-dd");

                    if (vencimientos.Rows.Count > 1)    {
                        double cantidad = 0.00;
                        for (int b = 0; b < vencimientos.Rows.Count; b++)   {
                            cantidad = cantidad + Convert.ToDouble(vencimientos.Rows[b][1].ToString());

                            String sqlInsertVencimiento = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, Importe, ImpOpDetPte) VALUES (" + id_op + "," + vencimientos.Rows[b][0].ToString() + ",'" + fechaAhora2 + "'," + Logica.FuncionesGenerales.ArreglarImportes(vencimientos.Rows[b][1].ToString()) + "," + Logica.FuncionesGenerales.ArreglarImportes(vencimientos.Rows[b][1].ToString()) + ")";
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertVencimiento);
                        }
                        if (!cantidad.Equals(Convert.ToDouble(textBox_importe.Text.ToString().Replace(".", ","))))  {
                            MessageBox.Show("EL IMPORTE NO SUMA CORRECTAMENTE LOS VENCIMIENTOS ¡ REVISAR !");
                            masDeUnaLineaVencimientos = true;
                        }
                    }
                    else if (vencimientos.Rows.Count == 1)  {
                        String sqlInsertVencimiento = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, Importe, ImpOpDetPte) VALUES (" + id_op + "," + vencimientos.Rows[0][0].ToString() + ",'" + fechaAhora2 + "'," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ")";
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertVencimiento);
                    } else
                        MessageBox.Show("La Operacion no tiene vencimientos");

                    //LIQUIDACIONES
                    String sqlSelectLiqui = "SELECT Porcentaje FROM com_opdetliquidacion WHERE com_opdetliquidacion.IdOp = " + id_op_bbdd + ";";
                    DataTable liquidaciones = Persistencia.SentenciasSQL.select(sqlSelectLiqui);

                    //COJO LA FECHA
                    String fecha = (Convert.ToDateTime(maskedTextBox_nueva_fecha.Text)).ToString("yyyy-MM-dd");

                    //Buscamos liquidacion a la que pertenece
                    String sqlSelectLiquidacionesActivas = "SELECT com_liquidaciones.IdLiquidacion FROM com_ejercicios INNER JOIN com_liquidaciones ON com_ejercicios.IdEjercicio = com_liquidaciones.IdEjercicio WHERE(((com_liquidaciones.Cerrada) <> -1) AND((com_ejercicios.IdComunidad) = " + id_comunidad_cargado + ") AND((com_liquidaciones.Ppal) = -1) AND((com_liquidaciones.FIni) <= '" + fecha + "' ) AND ((com_liquidaciones.FFin) >= '" + fecha + "' ));";


                    DataTable liquidacionesActivas = Persistencia.SentenciasSQL.select(sqlSelectLiquidacionesActivas);

                    if (liquidacionesActivas.Rows.Count > 0)
                    {
                        if (liquidaciones.Rows.Count == 1)
                        {
                            String sqlInsertarLiquidacionDet = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + id_op + "," + liquidacionesActivas.Rows[0][0].ToString() + "," + liquidaciones.Rows[0][0].ToString() + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ")";

                            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertarLiquidacionDet);
                        }
                        else
                            MessageBox.Show("La Operacion tiene mas de una linea de Liquidacion o ninguna, por tanto se tiene que añadir manualmente.");
                    }
                    else
                    {
                        String sqlLiqPpal = "SELECT com_liquidaciones.IdLiquidacion FROM com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio WHERE(((com_ejercicios.IdComunidad) = " + id_comunidad_cargado + ") AND((com_liquidaciones.Ppal) = -1));";
                        String LiqPpal = (Persistencia.SentenciasSQL.select(sqlLiqPpal)).Rows[0][0].ToString();
                        if (LiqPpal != "" || LiqPpal != null)
                        {
                            MessageBox.Show("¡¡ CUIDADO LA LIQUIDACIÓN SUGERIDA ESTA CERRADA !!");
                            String sqlInsertarLiquidacionDet = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + id_op + "," + LiqPpal + "," + liquidaciones.Rows[0][0].ToString() + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ")";
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertarLiquidacionDet);
                        }
                        else
                        {
                            MessageBox.Show("No hay liquidacion principal");
                        }
                    }

                    if (masDeUnaLineaIVA)  {
                        FromOperacionesVer nueva = new FromOperacionesVer(id_op.ToString(), 1, id_comunidad_cargado, textoBuscar);
                        FormOperacionesAddIVA nuevaIVA = new FormOperacionesAddIVA(nueva, id_comunidad_cargado, id_op.ToString(), textBox_importe.Text.Replace('.', ','), true);
                        nuevaIVA.Show();
                        nueva.Show();
                        nuevaIVA.TopMost = true;

                    } else if (masDeUnaLineaVencimientos) {
                        FromOperacionesVer nueva = new FromOperacionesVer(id_op.ToString(), 1, id_comunidad_cargado, textoBuscar);
                        FormOperacionesVencimientos nuevaVencimientos = new FormOperacionesVencimientos(nueva, id_comunidad_cargado, id_op.ToString(), textBox_importe.Text.Replace('.', ','), true);
                        nuevaVencimientos.Show();
                        nueva.Show();
                        nuevaVencimientos.TopMost = true;
                    }
                    else
                    {
                        FromOperacionesVer nueva = new FromOperacionesVer(id_op.ToString(), 1, id_comunidad_cargado, textoBuscar);
                        nueva.Show();
                    }
                }
                else if (cabecera.Rows[0][3].ToString() == "3")
                {
                    if (cabecera.Rows[0][10].ToString() == "")
                    {
                        sqlInsertCabe = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion,IdRetencion, BaseRet, Retencion,Notas, IdEstado, ImpOp, ImpOpPte, NumMov, Guardada, IdURD, FAct) VALUES (" + cabecera.Rows[0][0].ToString() + "," + cabecera.Rows[0][1].ToString() + "," + cabecera.Rows[0][2].ToString() + "," + cabecera.Rows[0][3].ToString() + ",'" + fechaOp + "','" + textBox_documento.Text + "','" + textBox_nuevo_nombre.Text + "'," + cabecera.Rows[0][4].ToString() + "," + cabecera.Rows[0][5].ToString().Replace(',', '.') + "," + cabecera.Rows[0][6].ToString().Replace(',', '.') + ",'" + cabecera.Rows[0][7].ToString() + "',1," + textBox_importe.Text.Replace(',', '.') + "," + textBox_importe.Text.Replace(',', '.') + ",0,'No'," + Login.getId() + ",'" + fechaAhora + "')";
                    }
                    else
                    {
                        sqlInsertCabe = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion,IdRetencion, BaseRet, Retencion,Notas, IdEstado, IdExpte, ImpOp, ImpOpPte, NumMov, Guardada, IdURD, FAct) VALUES (" + cabecera.Rows[0][0].ToString() + "," + cabecera.Rows[0][1].ToString() + "," + cabecera.Rows[0][2].ToString() + "," + cabecera.Rows[0][3].ToString() + ",'" + fechaOp + "','" + textBox_documento.Text + "','" + textBox_nuevo_nombre.Text + "'," + cabecera.Rows[0][4].ToString() + "," + cabecera.Rows[0][5].ToString().Replace(',', '.') + "," + cabecera.Rows[0][6].ToString().Replace(',', '.') + ",'" + cabecera.Rows[0][7].ToString() + "',1," + cabecera.Rows[0][10].ToString() + "," + textBox_importe.Text.Replace(',', '.') + "," + textBox_importe.Text.Replace(',', '.') + ",0,'No'," + Login.getId() + ",'" + fechaAhora + "')";
                    }
                    id_op = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertCabe);


                    //CREAMOS IVA
                    String sqlSelectIva = "SELECT aux_iva.`%IVA`, com_opdetiva.IdIVA FROM com_opdetiva INNER JOIN aux_iva ON com_opdetiva.IdIVA = aux_iva.IdIVA WHERE(((com_opdetiva.IdOp) = " + id_op_bbdd + "));";

                    DataTable iva = Persistencia.SentenciasSQL.select(sqlSelectIva);
                    if (iva.Rows.Count == 1)
                    {
                        int ivaPer = Convert.ToInt32(iva.Rows[0][0].ToString());
                        double ivaPerIntermedio = ivaPer / 100.00;
                        double baseIVA = Convert.ToDouble(textBox_importe.Text.Replace('.', ',')) / (ivaPerIntermedio + 1);

                        double ivaTotal = ((baseIVA * ivaPer) / 100.00);

                        String sqlInsert = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + id_op + "," + baseIVA.ToString().Replace(',', '.') + "," + iva.Rows[0][1].ToString() + "," + ivaTotal.ToString().Replace(',', '.') + ")";
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                    }
                    else
                    {
                        MessageBox.Show("La Operacion tiene mas de una linea de IVA, por tanto se tiene que añadir el IVA manualmente.");
                        String sqlTodosIvas = "SELECT Base, IdIVA, IVA FROM com_opdetiva WHERE IdOp = " + id_op_bbdd;
                        DataTable variosIvas = Persistencia.SentenciasSQL.select(sqlTodosIvas);
                        for (int a = 0; a < variosIvas.Rows.Count; a++)
                        {
                            String sqlInsertIvas = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + id_op + "," + variosIvas.Rows[a][0].ToString().Replace(',', '.') + "," + variosIvas.Rows[a][1].ToString() + "," + variosIvas.Rows[a][2].ToString().Replace(',', '.') + ")";
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertIvas);
                        }

                        masDeUnaLineaIVA = true;
                    }

                    //CREAMOS REPARTO
                    String sqlSelectReparto = "SELECT IdEntidad, Porcentaje FROM com_opdetbloques WHERE IdOp = " + id_op_bbdd + ";";
                    DataTable repartos = Persistencia.SentenciasSQL.select(sqlSelectReparto);
                    for (int a = 0; a < repartos.Rows.Count; a++)
                    {

                        double porcentaje = Convert.ToDouble(repartos.Rows[a][1].ToString()) * 100;

                        double total = (Convert.ToDouble(textBox_importe.Text.Replace('.', ',')) * porcentaje) / 100;

                        String sqlInsertReparto = "INSERT INTO com_opdetbloques (IdOp, IdEntidad, Porcentaje, Importe) VALUES (" + id_op + "," + repartos.Rows[a][0].ToString() + "," + repartos.Rows[a][1].ToString().Replace(',', '.') + "," + total.ToString().Replace(',', '.') + ")";
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertReparto);
                    }


                    //CREAMOS VENCIMIENTOS
                    String sqlEntidadVencimiento = "SELECT IdEntidad, Importe FROM com_opdetalles WHERE com_opdetalles.IdOp = " + id_op_bbdd + ";";
                    DataTable vencimientos = Persistencia.SentenciasSQL.select(sqlEntidadVencimiento);
                    String fechaAhora2 = (Convert.ToDateTime(fechaOp)).ToString("yyyy-MM-dd");

                    if (vencimientos.Rows.Count > 0)
                    {
                        for (int a = 0; a < vencimientos.Rows.Count; a++)
                        {
                            if (vencimientos.Rows.Count > 1)
                            {
                                String sqlInsertVencimiento = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, Importe, ImpOpDetPte) VALUES (" + id_op + "," + vencimientos.Rows[a][0].ToString() + ",'" + fechaAhora2 + "'," + Logica.FuncionesGenerales.ArreglarImportes(vencimientos.Rows[a][1].ToString()) + "," + Logica.FuncionesGenerales.ArreglarImportes(vencimientos.Rows[a][1].ToString()) + ")";
                                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertVencimiento);
                            }
                            else if (vencimientos.Rows.Count == 1)
                            {
                                String sqlInsertVencimiento = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, Importe, ImpOpDetPte) VALUES (" + id_op + "," + vencimientos.Rows[a][0].ToString() + ",'" + fechaAhora2 + "'," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ")";
                                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertVencimiento);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La Operacion no tiene vencimientos");
                    }

                    //LIQUIDACIONES
                    String sqlSelectLiqui = "SELECT Porcentaje FROM com_opdetliquidacion WHERE com_opdetliquidacion.IdOp = " + id_op_bbdd + ";";
                    DataTable liquidaciones = Persistencia.SentenciasSQL.select(sqlSelectLiqui);

                    //COJO LA FECHA
                    String fecha = (Convert.ToDateTime(maskedTextBox_nueva_fecha.Text)).ToString("yyyy-MM-dd");

                    //Buscamos liquidacion a la que pertenece
                    String sqlSelectLiquidacionesActivas = "SELECT com_liquidaciones.IdLiquidacion FROM com_ejercicios INNER JOIN com_liquidaciones ON com_ejercicios.IdEjercicio = com_liquidaciones.IdEjercicio WHERE(((com_liquidaciones.Cerrada) <> -1) AND((com_ejercicios.IdComunidad) = " + id_comunidad_cargado + ") AND((com_liquidaciones.Ppal) = -1) AND((com_liquidaciones.FIni) <= '" + fecha + "' ) AND ((com_liquidaciones.FFin) >= '" + fecha + "' ));";

                    DataTable liquidacionesActivas = Persistencia.SentenciasSQL.select(sqlSelectLiquidacionesActivas);

                    if (liquidacionesActivas.Rows.Count > 0)
                    {
                        if (liquidaciones.Rows.Count == 1)
                        {
                            String sqlInsertarLiquidacionDet = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + id_op + "," + liquidacionesActivas.Rows[0][0].ToString() + "," + liquidaciones.Rows[0][0].ToString() + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ")";

                            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertarLiquidacionDet);
                        }
                        else
                            MessageBox.Show("La Operacion tiene mas de una linea de Liquidacion o ninguna, por tanto se tiene que añadir manualmente.");
                    }
                    else
                    {
                        String sqlLiqPpal = "SELECT com_liquidaciones.IdLiquidacion FROM com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio WHERE(((com_ejercicios.IdComunidad) = " + id_comunidad_cargado + ") AND((com_liquidaciones.Ppal) = -1));";
                        String LiqPpal = (Persistencia.SentenciasSQL.select(sqlLiqPpal)).Rows[0][0].ToString();
                        if (LiqPpal != "" || LiqPpal != null)
                        {
                            String sqlInsertarLiquidacionDet = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + id_op + "," + LiqPpal + "," + liquidaciones.Rows[0][0].ToString() + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ")";
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertarLiquidacionDet);
                        }
                        else
                        {
                            MessageBox.Show("No hay liquidacion principal");
                        }
                    }
                    int numRecibo = 0;
                    String vencimientosRecibo = "SELECT com_opdetbloques.IdEntidad, com_operaciones.Fecha, com_opdetbloques.Importe, com_operaciones.Descripcion FROM com_operaciones INNER JOIN com_opdetbloques ON com_operaciones.IdOp = com_opdetbloques.IdOp WHERE(((com_operaciones.IdOp) = " + id_op + "));";
                    DataTable reparto = Persistencia.SentenciasSQL.select(vencimientosRecibo);
                    for (int a = 0; a < reparto.Rows.Count; a++)
                    {
                        String fechaRecibo = (Convert.ToDateTime(reparto.Rows[a][1].ToString())).ToString("yyyy-MM-dd");
                        numRecibo = Logica.FuncionesTesoreria.CreoReciboID(id_comunidad_cargado, reparto.Rows[a][0].ToString(), fechaRecibo, reparto.Rows[a][2].ToString(), reparto.Rows[a][2].ToString(), reparto.Rows[a][3].ToString());
                        String id_opdet = (Persistencia.SentenciasSQL.select("SELECT IdOpDet FROM com_opdetalles WHERE IdOp = " + id_op)).Rows[0][0].ToString();
                        Logica.FuncionesTesoreria.ActualizoIdReciboVencimiento(numRecibo.ToString(), id_opdet);
                    }

                    if (masDeUnaLineaIVA)
                    {
                        FromOperacionesVer nueva = new FromOperacionesVer(id_op.ToString(), 1, id_comunidad_cargado, textoBuscar);
                        FormOperacionesAddIVA nuevaIVA = new FormOperacionesAddIVA(nueva, id_comunidad_cargado, id_op.ToString(), textBox_importe.Text.Replace('.', ','), true);
                        nuevaIVA.Show();
                        nueva.Show();
                        nuevaIVA.TopMost = true;
                    }
                    else
                    {
                        FromOperacionesVer nueva = new FromOperacionesVer(id_op.ToString(), 1, id_comunidad_cargado, textoBuscar);
                        nueva.Show();
                    }
                }
            }
        }
        private void repartoTipo3()
        {

        }
        private bool IsInRange(DateTime vFechaIni, DateTime vFechaFin, DateTime vFechaSeleccionada)
        {
            if (vFechaSeleccionada.ToUniversalTime() >= vFechaIni.ToUniversalTime() && vFechaSeleccionada.ToUniversalTime() <= vFechaFin.ToUniversalTime())
                return true;

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maskedTextBox_nueva_fecha.Text = DateTime.Now.ToShortDateString();
        }

        private void textBox_importe_TextChanged(object sender, EventArgs e)
        {
            textBox_importe.Text = Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text);
        }

        private void maskedTextBox_nueva_fecha_Enter(object sender, EventArgs e)
        {
            maskedTextBox_nueva_fecha.Focus();
            maskedTextBox_nueva_fecha.SelectAll();
        }

        private void textBox_documento_Enter(object sender, EventArgs e)
        {
            textBox_documento.SelectAll();
        }

        private void textBox_importe_Enter(object sender, EventArgs e)
        {
            textBox_importe.SelectAll();
        }

        private void maskedTextBox_nueva_fecha_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBox_nueva_fecha.Text, sPattern))
                {
                    maskedTextBox_nueva_fecha.Text = maskedTextBox_nueva_fecha.Text + DateTime.Now.Year;
                }
                else if(Regex.IsMatch(maskedTextBox_nueva_fecha.Text, sPattern1)) {
                textBox_documento.SelectAll();
            }
                else 
                {
                maskedTextBox_nueva_fecha.Focus();
                maskedTextBox_nueva_fecha.Select();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String fecha = (Convert.ToDateTime(maskedTextBox_nueva_fecha.Text)).ToString("yyyy-MM-dd");
            String sqlUpdateFav = "UPDATE com_opfavoritas SET NomFavo='" + textBox_nuevo_nombre.Text + "', FechaFavo='" + fecha + "', DocFavo='" + textBox_documento.Text + "', ImpFavo=" + textBox_importe.Text.ToString().Replace(',','.') + " WHERE IdOpFav = " + id_op_fav;

            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdateFav);
            MessageBox.Show("Favorita Actualizada");
        }
        private void tieneRetencion(String idOpNueva, String fecha)
        {
            //BUSCO EL PERIODO QUE LE PERTENECE DE IVA Y SI ESTA CERRADO LE PONGO EL SIGUIENTE
            String sqlFechas = "SELECT com_ivaImpuestos.FIni, com_ivaImpuestos.FFin, com_ivaImpuestos.IdIvaImpuestos, com_ivaImpuestos.Cerrada, com_ivaImpuestos.Orden FROM com_ivaImpuestos WHERE IdComunidad = " + id_comunidad_cargado;
            DataTable periodos = Persistencia.SentenciasSQL.select(sqlFechas);

            for (int i = 0; i < periodos.Rows.Count; i++)
            {

                String fechaInicio = (Convert.ToDateTime(periodos.Rows[i][0] + "-" + DateTime.Now.Year.ToString())).ToString();
                String fechaFin = (Convert.ToDateTime(periodos.Rows[i][1] + "-" + DateTime.Now.Year.ToString())).ToString();

                if (Convert.ToDateTime(fechaInicio) <= Convert.ToDateTime(fecha) && Convert.ToDateTime(fechaFin) >= Convert.ToDateTime(fecha))
                {

                    if (periodos.Rows[i][3].ToString() != "True")
                    {
                        //MessageBox.Show(fecha + " | " + fechaInicio + " | " + fechaFin);
                        String sqlUpdateOperacion = "UPDATE com_operaciones SET IdPeridoIVA=" + periodos.Rows[i][2] + " WHERE IdOp = " + idOpNueva;
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdateOperacion);
                    }
                    else
                    {
                        int actual = Convert.ToInt32(periodos.Rows[i][4].ToString());
                        if (actual == 4) actual = 1;
                        else actual++;

                        String sqlSelect = "SELECT IdIvaImpuestos FROM com_ivaImpuestos WHERE IdComunidad = " + id_comunidad_cargado + " AND Orden = " + actual;
                        DataTable periodoNuevo = Persistencia.SentenciasSQL.select(sqlSelect);
                        if (periodoNuevo.Rows.Count > 0)
                        {
                            String sqlUpdateOperacion = "UPDATE com_operaciones SET IdPeridoIVA=" + periodoNuevo.Rows[0][0] + " WHERE IdOp = " + idOpNueva;
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdateOperacion);
                        }
                    }
                }
            }
        }
    }
}
