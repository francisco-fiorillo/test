using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {       
        public class Persona
        {
            public String Nombre { get; set; }
            public String Apellido { get; set; }
            public int Edad { get; set; }

            public Persona(String Nombre, String Apellido, int Edad)
            {
                this.Nombre = Nombre;
                this.Apellido = Apellido;
                this.Edad = Edad;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sblMensaje = new StringBuilder();

            NorthwindDataContext db = new NorthwindDataContext(@"server=GLB5536\SQLEXPRESS;uid=sa;pwd=Globant01;database=Northwind;Trusted_Connection=no;");            

            var queryCustomers = from cust in db.Customers
                                 where cust.City  == "London"
                                 select cust;

            foreach (Customer c in queryCustomers)
            {
                sblMensaje.Append("Nombre: ").Append(c.ContactName).Append(" -- Country: ").Append(c.Country).Append(" -- City: ").Append(c.City).Append("<br/>");
            }                                    

            Persona[] arrPersonas = new Persona[5];
            arrPersonas[0] = new Persona("Jose", "Gomez", 40);
            arrPersonas[1] = new Persona("Ramiro", "Bolaños", 25);
            arrPersonas[2] = new Persona("Armando", "Paredes", 17);
            arrPersonas[3] = new Persona("Alberto", "Fleitas", 18);
            arrPersonas[4] = new Persona("Herminio", "Sanchez", 38);

            var queryMenores = from item in arrPersonas
                               where item.Edad < 18
                               select item;

            var queryEmpiezaConA = from item in arrPersonas
                                   where item.Nombre.ToLower().StartsWith("a")
                                   select item;

            var queryTerminaConA = from item in arrPersonas
                                   where item.Nombre.ToLower().EndsWith("a")
                                   select item;
                                    
            if (queryMenores.Count() < 1)
                sblMensaje.Append("No hay menores en el grupo.</br>");
            foreach (Persona p in queryMenores)
            {
                sblMensaje.Append(p.Nombre).Append(" ").Append(p.Apellido).Append(" es menor de edad (").Append(p.Edad).Append(")<br/> ");
            }

            if (queryEmpiezaConA.Count() < 1)
                sblMensaje.Append("No hay personas cuyo nombre empiece con \"A\".</br>");
            foreach (Persona p in queryEmpiezaConA)
            {
                sblMensaje.Append(p.Nombre).Append(" ").Append(p.Apellido).Append(" - Su nombre comienza con \"A\"<br/>");
            }

            if (queryTerminaConA.Count() < 1)
                sblMensaje.Append("No hay personas cuyo nombre termine con \"A\".</br>");
            foreach (Persona p in queryTerminaConA)
            {
                sblMensaje.Append(p.Nombre).Append(" ").Append(p.Apellido).Append(" - Su nombre termina con \"A\"<br/>");
            }

            ltrlList.Text = sblMensaje.ToString();
            
        }
    }
}
