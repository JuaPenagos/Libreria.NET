using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libComunes.CapaObjetos;//Para el objeto clsGrid (Para llenar el grid)
using System.Web.UI.WebControls;//Para el objeto gridview (Interfaz)

namespace FinalLibreria.Base_Datos
{
    public class clsTipoLibro
    {
        #region "Atributos"
        private DropDownList ocboTipoLibro;
        private string sSQL;
        private string sError;
        #endregion

        #region "Propiedades"
        public DropDownList cboTipoLibro
        {
            get { return ocboTipoLibro; }
            set { ocboTipoLibro = value; }
        }

        public string Error
        {
            get { return sError; }
        }
        #endregion

        #region "Metodos"
        private bool Validar()
        {
            if (ocboTipoLibro == null)
            {
                sError = "No definió el combo a llenar";
                return false;
            }
            return true;
        }

        public bool LlenarCombo()
        {
            sSQL = "TipoLibro_Combo";

            //Creamos el objeto combo
            clsCombos oCombo = new clsCombos();

            oCombo.SQL = sSQL;
            //Pasa el combo vacío
            oCombo.cboGenericoWeb = ocboTipoLibro;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            //Invoca el llenar combo
            if (oCombo.LlenarComboWeb())
            {
                //Asigna el combo lleno
                ocboTipoLibro = oCombo.cboGenericoWeb;
                oCombo = null;
                return true;
            }
            else
            {
                sError = oCombo.Error;
                oCombo = null;
                return false;
            }
        }
        #endregion
    }
}
