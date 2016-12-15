using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

//Librería de parámetros - Lee el xml
//con la información de conexión
namespace libComunes.CapaDatos
{
    public class clsParametros
    {
        #region "Atributos"
            private string strServidor;
            private string strBaseDatos;
            private string strUsuario;
            private string strClave;
            private string strStringConexion;
            private string strSeguridadIntegrada;
            private string strError;
            private string strArchivoXml;
            private XmlDocument objDocumento = new XmlDocument();
            private XmlNode objNode;
        #endregion

        #region "Propiedades"
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

            public string SeguridadIntegrada
            {
                get
                {
                    return strSeguridadIntegrada;
                }
            }

            public string StringConexion
            {
                get
                {
                    return strStringConexion;
                }
            }

            public string Error
            {
                get
                {
                    return strError;
                }
            }

            public string ArchivoXml
            {
                get
                {
                    return strArchivoXml;
                }

                set
                {
                    strArchivoXml = value;

                }
            }
        #endregion

        #region "Metodos"
            public bool GenererString()
            {
                string strNombreAplicacion = AppDomain.CurrentDomain.BaseDirectory;
                strNombreAplicacion = strNombreAplicacion.Substring(1, strNombreAplicacion.Length - 2);
                strNombreAplicacion = strNombreAplicacion.Substring(strNombreAplicacion.LastIndexOf('\\') + 1, strNombreAplicacion.Length - (strNombreAplicacion.LastIndexOf('\\') + 1));
            
                strArchivoXml = Application.StartupPath + "\\CON_" + strNombreAplicacion + ".xml";
                // Obtiene la ruta de acceso del archivo ejecutable que inicia la seccion.

                try
                {
                    objDocumento.Load(strArchivoXml);
                    objNode = objDocumento.SelectSingleNode("//Servidor");
                    strServidor = objNode.InnerText;
                    objNode = objDocumento.SelectSingleNode("//Basedatos");
                    strBaseDatos = objNode.InnerText;
                    objNode = objDocumento.SelectSingleNode("//Usuario");
                    strUsuario = objNode.InnerText;
                    objNode = objDocumento.SelectSingleNode("//clave");
                    strClave = objNode.InnerText;
                    objNode = objDocumento.SelectSingleNode("//SeguridadIntegrada");
                    strSeguridadIntegrada = objNode.InnerText;

                    if (strSeguridadIntegrada == "Si")
                    {
                        strStringConexion = "Data Source=" + strServidor + ";Initial Catalog=" + strBaseDatos + "; Integrated Security = SSPI";
                    }
                    else
                    {
                        strStringConexion = "Data Source=" + strServidor + ";Initial Catalog=" + strBaseDatos + ";User Id =" + strUsuario + "; Password=" + strClave + ";"; 
                    }
                
                    objDocumento = null;
                    return true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    objDocumento = null;
                    return false;
                }
            }
        #endregion
    }
}
