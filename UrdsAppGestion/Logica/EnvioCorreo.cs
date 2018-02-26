using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrdsAppGestión.Logica
{
    public class EnvioCorreo {
        private String IdComunidad;
        private String IdEntidad;
        private String IdEmail;
        private String correo;

        public string IdComunidad1
        {
            get
            {
                return IdComunidad;
            }

            set
            {
                IdComunidad = value;
            }
        }

        public string IdEntidad1
        {
            get
            {
                return IdEntidad;
            }

            set
            {
                IdEntidad = value;
            }
        }

        public string IdEmail1
        {
            get
            {
                return IdEmail;
            }

            set
            {
                IdEmail = value;
            }
        }

        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }

        public EnvioCorreo(String IdComunidad, String IdEntidad, String IdEmail, String correo) {
            this.IdComunidad = IdComunidad;
            this.IdEmail = IdEmail;
            this.IdEntidad = IdEntidad;
            this.correo = correo;
        }
        public EnvioCorreo(String IdComunidad, String IdEntidad, String IdEmail) {
            this.IdComunidad = IdComunidad;
            this.IdEmail = IdEmail;
            this.IdEntidad = IdEntidad;
        }

    }
}
