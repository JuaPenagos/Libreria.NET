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
    public class clsLibro
    {
        
        #region "Constructor"
        public clsLibro()
        {

        }
        #endregion

        #region "Atributos"
        private string sCodigoLibro;
        private string sNombreLibro;
        private string sCategoriaLibro;
        private string sAutorlibro;
        private Int32 iTipoLibro;
        private Double dValorLibro;
        private string sError;
        private string sSQL;
        private GridView ogrdLibro;
        #endregion

        #region "Propiedades"
        public string CodigoLibro
        {
            get { return sCodigoLibro; }
            set { sCodigoLibro = value; }
        }

        public string NombreLibro
        {
            get { return sNombreLibro; }
            set { sNombreLibro = value; }
        }

        public string CategoriaLibro
        {
            get { return sCategoriaLibro; }
            set { sCategoriaLibro = value; }
        }

        public string AutorLibro
        {
            get { return sAutorlibro; }
            set { sAutorlibro = value; }
        }

        public Int32 TipoLibro
        {
            get { return iTipoLibro; }
            set { iTipoLibro = value; }
        }
        public Double ValorLibro
        {
            get { return dValorLibro; }
            set { dValorLibro = value; }
        }
        public string Error
        {
            get { return sError; }
        }
        public GridView grdCliente
        {
            get { return ogrdLibro; }
            set { ogrdLibro = value; }
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
            oConexion.SQL = "Libro_Consultar";

            //Se definen los parámetros del procedimiento almacenado
            oConexion.AgregarParametro("@pr_CodigoLibro",
                                        System.Data.SqlDbType.VarChar,
                                        50, sCodigoLibro);

            //Se ejecuta la instrucción
            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    sNombreLibro = oConexion.Reader.GetString(0);
                    sCategoriaLibro = oConexion.Reader.GetString(1);
                    sAutorlibro = oConexion.Reader.GetString(2);
                    iTipoLibro = oConexion.Reader.GetInt32(3);
                    dValorLibro = oConexion.Reader.GetDouble(4);

                    oConexion.CerrarConexion();
                    oConexion = null;
                    return true;
                }
                else
                {
                    sError = "No hay un libro con el Codigo consultado";
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

            oConexion.SQL = "Libro_Insertar";

            //Parámetros
            oConexion.AgregarParametro("@pr_CodigoLibro",
                                        System.Data.SqlDbType.VarChar,
                                        20, sCodigoLibro);

            oConexion.AgregarParametro("@pr_NombreLibro",
                                        System.Data.SqlDbType.VarChar,
                                        50, sNombreLibro);

            oConexion.AgregarParametro("@pr_CategoriaLibro",
                                        System.Data.SqlDbType.VarChar,
                                        50, sCategoriaLibro);

            oConexion.AgregarParametro("@pr_AutorLibro",
                                        System.Data.SqlDbType.VarChar,
                                        50, sAutorlibro);

            oConexion.AgregarParametro("@pr_CodTipoLibro",
                                        System.Data.SqlDbType.Int,
                                        4, iTipoLibro);

            oConexion.AgregarParametro("@pr_ValorLibro",
                                        System.Data.SqlDbType.Float,
                                        50, dValorLibro);


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
            if (ogrdLibro == null)
            {
                sError = "No definió el grid del Libro";
                return false;
            }
            sSQL = "Libro_Grid";

            clsGrid oGrid = new clsGrid();

            oGrid.SQL = sSQL;
            oGrid.gridGenerico = ogrdLibro;

            if (oGrid.LlenarGridWeb())
            {
                ogrdLibro = oGrid.gridGenerico;
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


