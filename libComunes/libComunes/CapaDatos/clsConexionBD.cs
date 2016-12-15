using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

/*  ejecuta la sentecia  la  sentencia  SQL
    consulta la  informacion (DATAREADER)
    llenar el DATASET = (es  una simulacion de base  de datos)
 */
namespace libComunes.CapaDatos
{
	public class clsConexionDB
	{
		#region "Constructor"
            public clsConexionDB()
		    {
			    //datos del constructor
			    objCommand = new SqlCommand();
			    objConexionBD = new SqlConnection();
			    objDataSet = new DataSet();
			    objParametro = new SqlParameter();
			    objAdapter = new SqlDataAdapter();
                oParametro = new SqlParameter();
		    }
		#endregion

		#region "Destructor"
		~clsConexionDB()
		{
			CerrarConexion();
		}

		#endregion

		//ATRIBUTOS
		#region "Atributos"

		    private string strSQL;
		    private string strStringConexion;
		    private SqlCommand objCommand;
		    private SqlConnection objConexionBD;
		    private SqlDataReader objReader;
            private SqlParameter oParametro = new SqlParameter();
		    private string strServidor;
		    private string strBaseDatos;
		    private string strUsuario;
		    private string strClave;
		    private string strError;
		    private bool blnAbrio;
		    private string strNombreTabla;
		    private SqlDataAdapter objAdapter;
		    private DataSet objDataSet;
		    private SqlParameter objParametro;
		#endregion

		//PROPIEDADES
		#region "Propiedades"
		    public string NombreTabla
		    {
			    get
			    {
				    return strNombreTabla;
			    }
			    set
			    {
				    strNombreTabla = value;
			    }
		    }

            public SqlCommand MiCommand
            {
                get
                {
                    return objCommand; 
                }
            }

		    public DataSet MiDataSet
		    {
			    get
			    {
				    return objDataSet;
			    }
		    }

		    public string SQL
		    {
			    get
			    {
				    return strSQL;
			    }
			    set
			    {
				    strSQL = value;
			    }
		    }
		    public string StringConexion
		    {
			    get
			    {
				    return strStringConexion;
			    }
			    set
			    {
				    strStringConexion = value;
			    }
		    }
		    public SqlDataReader Reader
		    {
			    get
			    {
				    return objReader;
			    }
		    }
		    public string Servidor
		    {
			    get
			    {
				    return strServidor;
			    }
		    }
		    public string BaseDatos
		    {
			    get
			    {
				    return strBaseDatos;
			    }
		    }
		    public string Usuario
		    {
			    get
			    {
				    return strUsuario;
			    }
		    }
		    public string Clave
		    {
			    get
			    {
				    return strClave;
			    }
		    }	
		    public SqlParameter miobjParametro
		    {
			    get
			    {
				    return (objParametro);
			    }
		    }
		    public string Error
		    {
			    get
			    {
				    return strError;
			    }
		    }
		#endregion

		#region "Metodos Privados"
		    private bool GenerarString()
		    {
            
			    clsParametros objParametros = new clsParametros();//creamos una instancia de la clase parametros osea el objeto
			    if (objParametros.GenererString())
			    {
				    strStringConexion = objParametros.StringConexion;//asignamos a los atributos el objeto creado parametros 
				    strServidor = objParametros.Servidor;
				    strBaseDatos = objParametros.BaseDatos;
				    strUsuario = objParametros.Usuario;
				    strClave = objParametros.Clave;
				    objParametros = null;
				    return true;
			    }
			    else
			    {
				    strError = objParametros.Error;
				    objParametros = null;
				    return false;
			    }
		    }

		    private bool AbrirConexion()
		    {
			    if (GenerarString())
			    {
				    objConexionBD.ConnectionString = strStringConexion;
				    try //es como preparace si hay problemas si encuentran problemas me llame errores
				    {
					    objConexionBD.Open();
					    blnAbrio = true;
					    return true;
				    }
				    catch (Exception exception)
				    {
					    strError = exception.Message;
					    blnAbrio = false;
					    return false;
				    }
			    }
			    else
			    {
				    return false;
			    }
		    }
		#endregion

		#region "Metodos Publicos"
            public bool EjecutarSentencia()
		    {
			    if (strSQL == "")
			    {
				    strError = "No definio la instrucción SQL";
				    return false;
			    }
			    if (blnAbrio == false)
			    {

				    if (AbrirConexion() == false)
				    {
					    return false;
				    }
			    }
                
                if (objCommand.Parameters.Count > 0)
                {
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    objCommand.CommandType = System.Data.CommandType.Text;
                }

                objCommand.Connection = objConexionBD;
                //Define el tipo de parámetro a ejecutar, instruccion SQL o Stored Procedure

                objCommand.CommandText = strSQL;
			    try//es como preparace si hay problemas si encuentran problemas me llame errores
			    {
				    objCommand.ExecuteNonQuery();
				    //CerrarConexion();
				    return true;
			    }
			    catch (Exception exception)
			    {
				    strError = exception.Message;
				    //CerrarConexion();
				    return false;
			    }
		    }

		    public bool CerrarConexion()
		    {
			    try
			    {
				    objConexionBD.Close();
			    }
			    catch (Exception ex) //Error #1
			    {
				    strError = "No cerró la conexion" + ex.Message;
			    }
			    try//es como preparace si hay problemas si encuentran problemas me llame errores
			    {
				    objConexionBD = null;
			    }
			    catch (Exception ex1)
			    {
				    strError = "No liberó la conexion" + ex1.Message;//error #2
			    }
			    return true;
		    }

		    public bool LlenarDataSet()
		    {
			    if (strSQL == "")
			    {
				    strError = "No definio la instrucción SQL";
				    return false;
			    }
			    if (string.IsNullOrEmpty(strNombreTabla))
			    {
				    strError = "No definio el nombre de la tabla";
				    return false;
			    }

			    if (!blnAbrio)
			    {
				    if (AbrirConexion() == false)
				    {
					    return false;
				    }
			    }

                objCommand.CommandType = CommandType.Text;

			    objCommand.Connection = objConexionBD;
			    objCommand.CommandText = strSQL;

			    try
			    {
				    objAdapter.SelectCommand = objCommand;
				    objAdapter.Fill(objDataSet, strNombreTabla);
				    return true;
			    }
			    catch (Exception ex)
			    {
				    strError = ex.Message;
				    return false;
			    }
		    }

		    public bool Consultar()
		    {
			    if (strSQL == "")
			    {
				    strError = "No definio la instrucción SQL";
				    return false;
			    }
			    if (blnAbrio == false)
			    {
				    if (AbrirConexion()== false)
				    {
					    return false;
				    }
			    }

                if (objCommand.Parameters.Count > 0)
                {
                    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    objCommand.CommandType = System.Data.CommandType.Text;
                }

			    objCommand.Connection = objConexionBD;
			    objCommand.CommandText = strSQL;
			    try//para controlar el error
			    {
				    objReader = objCommand.ExecuteReader();//objReader permite capturar datos en una base de datos
				    return true;
			    }
			    catch (Exception ex)
			    {
				    strError = ex.Message;
				    return false;
			    }
		    }

            public bool AgregarParametro(string sNombreParametro, SqlDbType TipoDato, Int32 Tamano, object Valor)
            {
                try
                {
                    oParametro.ParameterName = sNombreParametro;
                    oParametro.SqlDbType = TipoDato;
                    oParametro.Value = Valor;
                    oParametro.Size = Tamano;
                    objCommand.Parameters.Add(oParametro);
                    oParametro = new SqlParameter();
                    return (true);
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    return (false);
                }
            }
        #endregion
	}
}
