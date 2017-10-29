using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using log4net;
using WebService.Servicios;
using Dapper;
using System.Data;
using System.Data.SqlClient;
namespace WebService.Servicios
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "CLINSW")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private static ILog log = LogManager.GetLogger(typeof(WebService1));
        [WebMethod]
        public RespuestaServicio HelloWorld(
            string IP,
            string USUARIO,
            string PASSWORD,
            string EMPRESA,
            string TABLA,
            string VALORLLAVE,
            string CAMPO1,
            string VALOR1,
            string CAMPO2,
            string VALOR2,
            string CAMPO3,
            string VALOR3,
            string CAMPO4,
            string VALOR4,
            string CAMPO5,
            string VALOR5
            )
        {
            try
            {
                using (var conn = DbFactory.Conn())
                {
                    conn.Open();
                    var affectedRows = conn.Execute("WS_ACTUALIZAR_CAMPOS",
                        new { 
                            CTABLA  = TABLA,
                            CVALORLLAVE = VALORLLAVE,
                            CCAMPO1 = (string.IsNullOrEmpty(CAMPO1) ? "ND" : CAMPO1),
                            CVALOR1 = VALOR1,
                            CCAMPO2 = (string.IsNullOrEmpty(CAMPO2) ? "ND" : CAMPO2),
                            CVALOR2 = VALOR2,
                            CCAMPO3 = (string.IsNullOrEmpty(CAMPO3) ? "ND" : CAMPO3),
                            CVALOR3 = VALOR3,
                            CCAMPO4 = (string.IsNullOrEmpty(CAMPO4) ? "ND" : CAMPO4),
                            CVALOR4 = VALOR4,
                            CCAMPO5 = (string.IsNullOrEmpty(CAMPO5) ? "ND" : CAMPO5),
                            CVALOR5 = VALOR5
                        },
                        commandType: CommandType.StoredProcedure);
                    return new RespuestaServicio
                    {
                        Codigo = "100",
                        Mensaje = string.Format("Se proceso {0}", affectedRows)
                    };
                }
            }
            catch (SqlException ex)
            {
                log.Info("Error en el evento", ex);
                return new RespuestaServicio
                {
                    Codigo = ex.ErrorCode.ToString(),
                    Mensaje = ex.Message
                };
            }
            catch (Exception ex)
            {
                log.Info("Error en el evento", ex);
                return new RespuestaServicio
                {
                    Codigo = "97",
                    Mensaje = ex.Message
                };
            }
        }
    }
}
