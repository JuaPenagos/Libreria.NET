using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;//Para el objeto clsGrid (Para llenar el grid)
using System.Web.UI.WebControls;//Para el objeto gridview (Interfaz)

namespace FinalLibreria.Base_Datos
{
    public class clsCliente
    {
        #region "Constructor"
        public clsCliente()
        {

        }
        #endregion

        #region "Atributos"
        private string sCedula;
        private string sNombre;
        private string sApelidos;
        private string sTelefonoFijo;
        private string sTelefonoCelular;
        private string sCorreoElectronico;
        private string sError;
        private string sSQL;
        private GridView ogrdCliente;
        #endregion

        #region "Propiedades"
        public string Cedula
        {
            get { return sCedula; }
            set { sCedula = value; }
        }

        public string Nombre
        {
            get { return sNombre; }
            set { sNombre = value; }
        }

        public string Apellidos
        {
            get { return sApelidos; }
            set { sApelidos = value; }
        }

        public string TelefonoFijo
        {
            get { return sTelefonoFijo; }
            set { sTelefonoFijo = value; }
        }

        public string TelefonoCelular
        {
            get { return sTelefonoCelular; }
            set { sTelefonoCelular = value; }
        }
        public string CorreoElectronico
        {
            get { return sCorreoElectronico; }
            set { sCorreoElectronico = value; }
        }
        public string Error
        {
            get { return sError; }
        }
        public GridView grdCliente
        {
            get { return ogrdCliente; }
            set { ogrdCliente = value; }
        }
        #endregion

        #region "Metodos"
        public  bool Consultar()
        {
            //Se requiere utilizar la clase Conexion
            clsConexionDB oConexion = new clsConexionDB();

            //Para los procedimientos almacenados, la instrucción
            //SQL que se asigna, es el nombre del procedimiento
            //almacenado
            oConexion.SQL = "Cliente_Consultar";

            //Se definen los parámetros del procedimiento almacenado
            oConexion.AgregarParametro("@pr_Documento",
                                        System.Data.SqlDbType.VarChar,
                                        50, sCedula);

            //Se ejecuta la instrucción
            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    sNombre = oConexion.Reader.GetString(0);
                    sApelidos = oConexion.Reader.GetString(1);
                    sTelefonoFijo = oConexion.Reader.GetString(2);
                    sTelefonoCelular = oConexion.Reader.GetString(3);
                    sCorreoElectronico = oConexion.Reader.GetString(4);

                    oConexion.CerrarConexion();
                    oConexion = null;
                    return true;
                }
                else
                {
                    sError = "No hay un cliente con el documento consultado";
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return false;
                }
            }
            else
            {
                sError = oConexion.Error;
                oConexion.CerrarConexion();
                oConexion = null;
                return false;
            }
        }

        public  bool Grabar()
        {
            clsConexionDB oConexion = new clsConexionDB();

            oConexion.SQL = "Cliente_Insertar";

            //Parámetros
            oConexion.AgregarParametro("@pr_Documento",
                                        System.Data.SqlDbType.VarChar,
                                        20, sCedula);

            oConexion.AgregarParametro("@pr_Nombre",
                                        System.Data.SqlDbType.VarChar,
                                        50, sNombre);

            oConexion.AgregarParametro("@pr_Apellido",
                                        System.Data.SqlDbType.VarChar,
                                        50, sApelidos);

            oConexion.AgregarParametro("@pr_TelefonoFijo",
                                        System.Data.SqlDbType.VarChar,
                                        50, sTelefonoFijo);

            oConexion.AgregarParametro("@pr_TelefonoCelular",
                                        System.Data.SqlDbType.VarChar,
                                        200, sTelefonoCelular);

            oConexion.AgregarParametro("@pr_CorreoElectronico",
                                        System.Data.SqlDbType.VarChar,
                                        50, sCorreoElectronico);


            if (oConexion.EjecutarSentencia())
            {
                oConexion = null;
                return true;
            }
            else
            {
                sError = oConexion.Error;
                oConexion = null;
                return false;
            }
        }



        public bool LlenarGrid()
        {
            if (ogrdCliente == null)
            {
                sError = "No definió el grid del cliente";
                return false;
            }
            sSQL = "Cliente_Grid";

            clsGrid oGrid = new clsGrid();

            oGrid.SQL = sSQL;
            oGrid.gridGenerico = ogrdCliente;

            if (oGrid.LlenarGridWeb())
            {
                ogrdCliente = oGrid.gridGenerico;
                oGrid = null;
                return true;
            }
            else
            {
                sError = oGrid.Error;
                oGrid = null;
                return false;
            }
        }
        #endregion
    }
}

