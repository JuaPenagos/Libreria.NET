using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalLibreria.Base_Datos;

namespace Libreria
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Llena el combo de tipo cliente
                LlenarComboTipoLibro();

            }
        }

        private void LlenarGrid()
        {
            clsLibro oLibro =
                new clsLibro();

            oLibro.grdCliente = grdLibro;
            if (!oLibro.LlenarGrid())
            {
                lblError.Text = oLibro.Error;
            }
            oLibro = null;
        }


        private void LlenarComboTipoLibro()
        {
            clsTipoLibro oTipoLibro = new clsTipoLibro();
            //Paso el combo vacío de la interfaz
            oTipoLibro.cboTipoLibro = cbTipoLibro;
            if (!oTipoLibro.LlenarCombo())
            {
                lblError.Text = oTipoLibro.Error;
            }
            oTipoLibro = null;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string sCodigoLibro, sNombreLibro, sCategoriaLibro, sAutorLibro;
            Int32 iTipoLibro;
            Double dValorLibro;

            sCodigoLibro = txtCodLibro.Text;
            sNombreLibro = txtNomLibro.Text;
            sCategoriaLibro = txtCatLibro.Text;
            sAutorLibro = txtAutLibro.Text;
            dValorLibro = Convert.ToDouble( txtValorLibro.Text);


            //Capturo el tipo de cliente del combo
            iTipoLibro = Convert.ToInt32(cbTipoLibro.SelectedValue);

            clsLibro oLibro = new clsLibro();

            oLibro.CodigoLibro = sCodigoLibro;
            oLibro.NombreLibro = sNombreLibro;
            oLibro.CategoriaLibro = sCategoriaLibro;
            oLibro.AutorLibro = sAutorLibro;
            oLibro.TipoLibro = iTipoLibro;
            oLibro.ValorLibro = dValorLibro;

            if (oLibro.Grabar())
            {
                lblError.Text = "Grabó";
                LlenarGrid();
            }
            else
            {
                lblError.Text = oLibro.Error;
            }
            oLibro = null;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string sDocumento;

            sDocumento = txtCodLibro.Text;

            clsLibro oLibro = new clsLibro();

            oLibro.CodigoLibro = sDocumento;

            if (oLibro.Consultar())
            {
                txtNomLibro.Text = oLibro.NombreLibro;
                txtCatLibro.Text = oLibro.CategoriaLibro;
                txtAutLibro.Text = oLibro.AutorLibro;
                txtValorLibro.Text = Convert.ToString(oLibro.ValorLibro);

                lblError.Text = "";
            }
            else
            {
                lblError.Text = oLibro.Error;

                txtNomLibro.Text = "";
                txtCatLibro.Text = "";
                txtAutLibro.Text = "";
                txtValorLibro.Text = "";
            }
        }


    }

}