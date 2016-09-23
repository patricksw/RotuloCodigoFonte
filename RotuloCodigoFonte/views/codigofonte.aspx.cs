using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RotuloCodigoFonte.views
{
    public partial class codigofonte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pathFile = HttpContext.Current.Server.MapPath("~/data/CodigoFonte.cs");
                if (File.Exists(pathFile))
                {
                    string content = File.ReadAllText(pathFile);
                    txtCodigoFonte.Text = content;
                }
            }
        }

        protected void btnRotular_Click(object sender, EventArgs e)
        {
            //criar thread
            Rotulo rotulo = new Rotulo();
            rotulo.AnalizaCodigo(rotulo.GetLines(txtCodigoFonte.Text));

            Response.Redirect("~/views/rotulador.aspx");
        }
    }
}