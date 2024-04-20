using restaurante.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace restaurante.Controllers
{
    public class UsuarioLoginController : Controller
    {
        static string con = "Data Source=LAPTOP-R91Q5M6Q;Initial Catalog=pimienta;Integrated Security=true";
        // GET: UsuarioLogin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(usuario usuario)
        {
            //usuario.clave = ConvertirSha256(usuario.clave);

            using (SqlConnection cn = new SqlConnection(con))
            {

                SqlCommand cmd = new SqlCommand("ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("email", usuario.email);
                cmd.Parameters.AddWithValue("clave", usuario.clave);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                usuario.usuarioID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }

            if (usuario.usuarioID != 0)
            {
                Session["usuario"] = usuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "usuario no encontrado";
                return View();
            }
        }

        /*public static string ConvertirSha256(string texto)
        {
            //using System.Text;
            //USAR LA REFERENCIA DE "System.Security.Cryptography"

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
        */
    }
}
