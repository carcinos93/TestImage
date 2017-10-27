using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
namespace WebService.Servicios
{
    public class DbFactory
    {
        public static SqlConnection Conn()
        {
            var connectionString = @"Data Source={0};Initial Catalog={1};User ID={2};Password={3}";
            HttpContext context = HttpContext.Current;
            var ip = "";
            var usuario = "";
            var empresa ="";
            var password = "";
            NameValueCollection parametros = null;
            if (context.Request.HttpMethod == "POST")
            {
                parametros = context.Request.Form;

            }
            else if (context.Request.HttpMethod == "GET")
            {
                parametros = context.Request.QueryString;
   
            }
            ip = parametros["IP"];
            usuario = parametros["USUARIO"];
            password = parametros["PASSWORD"];
            empresa = parametros["EMPRESA"];
            var connection = new SqlConnection(
                string.Format(connectionString, ip, empresa, usuario, password)
                );
            return connection;
        }
    }
}