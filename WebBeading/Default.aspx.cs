using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace WebBeading
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                CanvasOptionsRequest request = new CanvasOptionsRequest();

                if (TryUpdateModel(request, new FormValueProvider(ModelBindingExecutionContext)))
                {
                    Console.WriteLine("Hello world!\n");
                }
            }
        }
    }
}