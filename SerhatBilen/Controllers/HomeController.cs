using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SerhatBilen.Controllers
{
    
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
           
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Document()
        {
            List<Models.Makaleler> makaleListesi = new List<Models.Makaleler>();
            using (SqlConnection sqlConnection = new SqlConnection ("server=DESKTOP-2IPPHG8\\MSSQLSERVER1;database=Dbo_SerhatSite;Trusted_Connection=true"))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "Select * From tbl_makale With (nolock)";
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlCommand.ExecuteReader());

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow item in dataTable.Rows)
                    {
                        makaleListesi.Add(new Models.Makaleler()
                        {
                            baslik = item.Field<string>("makalebaslik"),
                            konu = item.Field<string>("makalekonu"),
                            icerik = item.Field<string>("makaleicerik"),
                            kaynak = item.Field<string>("makalekaynak")
                        });
                    }
                }
            }
            return View(makaleListesi);
        }
    }
}