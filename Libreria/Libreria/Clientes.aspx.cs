using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalLibreria.Base_Datos;

namespace Libreria
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void LlenarGrid()
        {
            clsCliente oCliente =
                new clsCliente();

            oCliente.grdCliente = grdClientes;
            if (!oCliente.LlenarGrid())
            {
                lblError.Text = oCliente.Error;
            }
            oCliente = null;
        }




           

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
 string sDocumento, sNombre, sApellido, sTelefonoFijo;
            string sTelefonoCelular, sCorreo;


            sDocumento = txtDocumento.Text;
            sNombre = txtNombre.Text;
            sApellido = txtApellido.Text;
            sTelefonoFijo = txtTelefonoFijo.Text;
            sTelefonoCelular = txtTelefonoCelular.Text;
            sCorreo = txtCorreo.Text;
            //Capturo el tipo de cliente del combo

            clsCliente oCliente= new clsCliente();

            oCliente.Cedula = sDocumento;
            oCliente.Nombre = sNombre;
            oCliente.Apellidos = sApellido;
            oCliente.TelefonoFijo = sTelefonoFijo;
            oCliente.TelefonoCelular = sTelefonoCelular;
            oCliente.CorreoElectronico= sCorreo;


            if (oCliente.Grabar())
            {
                lblError.Text = "Grabó";
                LlenarGrid();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
            oCliente = null;
        }
        }


        
    }
