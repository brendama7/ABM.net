using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using CapaNegocio;

namespace ADO.NET
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private readonly CNTerritories objN = new CNTerritories();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CargarGrilla();

        }
        public void CargarGrilla()
        {
            this.GridView1.DataSource = objN.GetList();
            this.GridView1.DataBind();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            objN.Insertar(TextBox1.Text, TextBox2.Text, DropDownList1.Text);
            CargarGrilla();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            objN.Modificar(TextBox1.Text, TextBox2.Text, DropDownList1.Text);
            CargarGrilla();
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            try
            {
                objN.Eliminar(TextBox1.Text);
                CargarGrilla();
            }
            catch (Exception)
            {
                Response.Write("<script language=javascript>alert('Error al ELIMINAR TerroryID');</script>");
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}