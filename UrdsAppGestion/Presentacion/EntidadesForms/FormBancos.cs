using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    public partial class FormBancos : Form
    {
        VerEntidad form_entidad;
        String id_cuenta = "0";
        String id_entidad_cargado;

        public FormBancos(VerEntidad form_entidad,String id_cuenta,String id_entidad_cargado)
        {
            InitializeComponent();
            this.id_cuenta = id_cuenta;
            this.id_entidad_cargado = id_entidad_cargado;
            this.form_entidad = form_entidad;
        }
        public FormBancos(VerEntidad form_entidad, String id_entidad_cargado)
        {
            InitializeComponent();
            this.id_entidad_cargado = id_entidad_cargado;
            this.form_entidad = form_entidad;
        }

        private void FormBancos_Load(object sender, EventArgs e)
        {
            if (id_cuenta != "0") {

                DataTable bancos = Persistencia.SentenciasSQL.select("SELECT * FROM ctos_detbancos WHERE IdCuenta = " + id_cuenta);

                if (bancos.Rows[0]["Ppal"].ToString() == "True") checkBox_principal.Checked = true;

                textBox_descripcion.Text = bancos.Rows[0][2].ToString();
                textBox_CC.Text = bancos.Rows[0][3].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (revisarCC())
            {
                String principal = "0";
                if (checkBox_principal.Checked) principal = "-1";

                if (id_cuenta != "0")
                {
                    String sql = "UPDATE ctos_detbancos SET Descripcion ='" + textBox_descripcion.Text + "', Ppal=" + principal + ", CC='" + textBox_CC.Text + "' WHERE IdCuenta = " + id_cuenta;

                    Persistencia.SentenciasSQL.InsertarGenerico(sql);
                    compruebaPrincipal(id_cuenta, principal);
                }
                else
                {
                    String sql = "INSERT INTO ctos_detbancos (IdEntidad,Descripcion,CC,Ppal) VALUES (" + id_entidad_cargado + ",'" + textBox_descripcion.Text + "','" + textBox_CC.Text + "'," + principal + ")";
                    int ultimo_id = Persistencia.SentenciasSQL.InsertarGenericoID(sql);
                    compruebaPrincipal(ultimo_id.ToString(), principal);
                    // form_entidad.cargoBanco();
                }
                if (form_entidad.dataGridView_bancos.Rows.Count > 0) {
                    MessageBox.Show("Puede que existan recibos emitidos");
                    FormRecibosEmitidos nueva = new FormRecibosEmitidos(id_entidad_cargado);
                    nueva.Show();
                }
                form_entidad.cargoBanco();
                this.Close();
            }
        }


        private void compruebaPrincipal(String id_direccion, String principal)
        {

            if (principal == "-1")
            {
                String sql2 = "UPDATE ctos_detbancos SET Ppal = 0 WHERE IdCuenta <> " + id_direccion + " AND IdEntidad = " + id_entidad_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sql2);
                //PREGUNTO POR LOS COMUNEROS
                MessageBox.Show("¡¡ ATENCIÓN SI ES UN COMUNERO CAMBIA LA CUENTA EN SU FICHA !!");
            }

            String sqlSelect = "SELECT IdCuenta FROM ctos_detbancos WHERE IdEntidad = " + id_entidad_cargado + " AND Ppal = -1 ";
            DataTable principales = Persistencia.SentenciasSQL.select(sqlSelect);

            if (principales.Rows.Count == 0) {
                MessageBox.Show("Debes marcar una cuenta como principal");
            }else if (principales.Rows.Count > 1) {
                MessageBox.Show("Solo puede existir una cuenta principal");
            }
        }

        private void textBox_CC_Leave(object sender, EventArgs e)
        {
            textBox_CC.ToString().ToUpper();
            revisarCC();
        }
        private Boolean revisarCC() {

            if (isIBAN(textBox_CC.Text)) { 
                textBox_CC.BackColor = Color.LightGreen;
                return true;
                }
            else  {
                MessageBox.Show("La cuenta es incorrecta.");
                textBox_CC.BackColor = Color.Red;
                textBox_CC.SelectAll();
                return false;
            }
        }
        public bool isIBAN(string iban)
        {
            string mysIBAN = iban.Replace(" ", "");

            if (mysIBAN.Length > 34 || mysIBAN.Length < 5)
                return false;
            else
            {
                string LaenderCode = mysIBAN.Substring(0, 2).ToUpper();
                string Pruefsumme = mysIBAN.Substring(2, 2).ToUpper();
                string BLZ_Konto = mysIBAN.Substring(4).ToUpper();
                if (!IsNumeric(Pruefsumme))
                    return false;

                if (!ISLaendercode(LaenderCode))
                    return false;
                string Umstellung = BLZ_Konto + LaenderCode + "00";
                string Modulus = IBANCleaner(Umstellung);

                if (98 - Modulo(Modulus, 97) != int.Parse(Pruefsumme))
                    return false; 
            }
            return true;
        }

        private bool ISLaendercode(string code)
        {
            if (code.Length != 2)
                return false;
            else
            {
                code = code.ToUpper();
                string[] Laendercodes = { "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI",
                "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV",
                "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI",
                "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV",
                "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI",
                "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV",
                "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI",
                "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV",
                "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI",
                "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV",
                "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI",
                "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV",
                "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI",
                "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV",
                "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI",
                "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV",
                "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II",
                "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV",
                "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI",
                "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV",
                "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI",
                "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV",
                "KW", "KX", "KY", "KZ", "LA", "LB", "LC", "LD", "LE", "LF", "LG", "LH", "LI",
                "LJ", "LK", "LL", "LM", "LN", "LO", "LP", "LQ", "LR", "LS", "LT", "LU", "LV",
                "LW", "LX", "LY", "LZ", "MA", "MB", "MC", "MD", "ME", "MF", "MG", "MH", "MI",
                "MJ", "MK", "ML", "MM", "MN", "MO", "MP", "MQ", "MR", "MS", "MT", "MU", "MV",
                "MW", "MX", "MY", "MZ", "NA", "NB", "NC", "ND", "NE", "NF", "NG", "NH", "NI",
                "NJ", "NK", "NL", "NM", "NN", "NO", "NP", "NQ", "NR", "NS", "NT", "NU", "NV",
                "NW", "NX", "NY", "NZ", "OA", "OB", "OC", "OD", "OE", "OF", "OG", "OH", "OI",
                "OJ", "OK", "OL", "OM", "ON", "OO", "OP", "OQ", "OR", "OS", "OT", "OU", "OV",
                "OW", "OX", "OY", "OZ", "PA", "PB", "PC", "PD", "PE", "PF", "PG", "PH", "PI",
                "PJ", "PK", "PL", "PM", "PN", "PO", "PP", "PQ", "PR", "PS", "PT", "PU", "PV",
                "PW", "PX", "PY", "PZ", "QA", "QB", "QC", "QD", "QE", "QF", "QG", "QH", "QI",
                "QJ", "QK", "QL", "QM", "QN", "QO", "QP", "QQ", "QR", "QS", "QT", "QU", "QV",
                "QW", "QX", "QY", "QZ", "RA", "RB", "RC", "RD", "RE", "RF", "RG", "RH", "RI",
                "RJ", "RK", "RL", "RM", "RN", "RO", "RP", "RQ", "RR", "RS", "RT", "RU", "RV",
                "RW", "RX", "RY", "RZ", "SA", "SB", "SC", "SD", "SE", "SF", "SG", "SH", "SI",
                "SJ", "SK", "SL", "SM", "SN", "SO", "SP", "SQ", "SR", "SS", "ST", "SU", "SV",
                "SW", "SX", "SY", "SZ", "TA", "TB", "TC", "TD", "TE", "TF", "TG", "TH", "TI",
                "TJ", "TK", "TL", "TM", "TN", "TO", "TP", "TQ", "TR", "TS", "TT", "TU", "TV",
                "TW", "TX", "TY", "TZ", "UA", "UB", "UC", "UD", "UE", "UF", "UG", "UH", "UI",
                "UJ", "UK", "UL", "UM", "UN", "UO", "UP", "UQ", "UR", "US", "UT", "UU", "UV",
                "UW", "UX", "UY", "UZ", "VA", "VB", "VC", "VD", "VE", "VF", "VG", "VH", "VI",
                "VJ", "VK", "VL", "VM", "VN", "VO", "VP", "VQ", "VR", "VS", "VT", "VU", "VV",
                "VW", "VX", "VY", "VZ", "WA", "WB", "WC", "WD", "WE", "WF", "WG", "WH", "WI",
                "WJ", "WK", "WL", "WM", "WN", "WO", "WP", "WQ", "WR", "WS", "WT", "WU", "WV",
                "WW", "WX", "WY", "WZ", "XA", "XB", "XC", "XD", "XE", "XF", "XG", "XH", "XI",
                "XJ", "XK", "XL", "XM", "XN", "XO", "XP", "XQ", "XR", "XS", "XT", "XU", "XV",
                "XW", "XX", "XY", "XZ", "YA", "YB", "YC", "YD", "YE", "YF", "YG", "YH", "YI",
                "YJ", "YK", "YL", "YM", "YN", "YO", "YP", "YQ", "YR", "YS", "YT", "YU", "YV",
                "YW", "YX", "YY", "YZ", "ZA", "ZB", "ZC", "ZD", "ZE", "ZF", "ZG", "ZH", "ZI",
                "ZJ", "ZK", "ZL", "ZM", "ZN", "ZO", "ZP", "ZQ", "ZR", "ZS", "ZT", "ZU", "ZV",
                "ZW", "ZX", "ZY", "ZZ" };

                if (Array.IndexOf(Laendercodes, code) == -1)
                    return false;
                else
                    return true;
            }
        }

        private string IBANCleaner(string sIBAN)
        {
            for (int x = 65; x < 90; x++)
            {
                int replacewith = x - 64 + 9;
                string replace = ((char)x).ToString();
                sIBAN = sIBAN.Replace(replace, replacewith.ToString());
            }
            return sIBAN;
        }

        private int Modulo(string sModulus, int iTeiler)
        {
            int iStart, iEnde, iErgebniss, iRestTmp, iBuffer;
            string iRest = "", sErg = "";

            iStart = 0;
            iEnde = 0;
            while (iEnde <= sModulus.Length - 1)
            {
                iBuffer = int.Parse(iRest + sModulus.Substring(iStart, iEnde - iStart + 1));

                if (iBuffer >= iTeiler)
                {
                    iErgebniss = iBuffer / iTeiler;
                    iRestTmp = iBuffer - iErgebniss * iTeiler;
                    iRest = iRestTmp.ToString();

                    sErg = sErg + iErgebniss.ToString();

                    iStart = iEnde + 1;
                    iEnde = iStart;
                }
                else
                {
                    if (sErg != "")
                        sErg = sErg + "0";

                    iEnde = iEnde + 1;
                }
            }
            if (iStart <= sModulus.Length)
                iRest = iRest + sModulus.Substring(iStart);
            return int.Parse(iRest);
        }
        private bool IsNumeric(string value)
        {
            try
            {
                int.Parse(value);
                return (true);
            }
            catch
            {
                return (false);
            }
        }
    }
}
