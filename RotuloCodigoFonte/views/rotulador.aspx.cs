using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RotuloCodigoFonte.views
{
    public partial class rotulador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rotulo rotulo = Rotulo.GetRotulo();

                grvResultado.DataSource = rotulo.ListResultado;
                grvResultado.DataBind();
            }
        }
    }
}