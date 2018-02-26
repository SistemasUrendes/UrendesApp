using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrdsAppGestión.Logica
{
    class ReciboRemesa
    {
        private String idRecibo;
        private String IdCuenta;
        private String Cuenta;
        private String importe;

        public string IdRecibo
        {
            get
            {
                return idRecibo;
            }

            set
            {
                idRecibo = value;
            }
        }

        public string IdCuenta1
        {
            get
            {
                return IdCuenta;
            }

            set
            {
                IdCuenta = value;
            }
        }

        public string Cuenta1
        {
            get
            {
                return Cuenta;
            }

            set
            {
                Cuenta = value;
            }
        }

        public string Importe
        {
            get
            {
                return importe;
            }

            set
            {
                importe = value;
            }
        }

        public ReciboRemesa(String IdRecibo, String IdCuenta, String Cuenta, String Importe) {
            this.idRecibo = IdRecibo;
            this.IdCuenta = IdCuenta;
            this.Cuenta = Cuenta;
            this.importe = Importe;
        }

    }
}
