using System;
using System.Web;
using System.Web.UI;

namespace litepost.WWW
{
    
    public partial class Default : System.Web.UI.Page
    {
        public string ExampleUrl;

        private void Page_Load(object sender, EventArgs e)
        {
            ExampleUrl = "HttpGet.aspx?action=appendline&file=MyFile.txt&text=HelloWorld&key=[MasterKey]";
        }

    }
}

