using System;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.IO;

namespace litepost.WWW
{
    
    public partial class HttpGet : System.Web.UI.Page
    {
        public string Message;

        private void Page_Load(object sender, EventArgs e)
        {
            if (UserIsAuthorised ()) {
                var action = Request.QueryString ["action"];

                var contentDirectory = Path.GetFullPath (ConfigurationSettings.AppSettings ["ContentPath"]);

                var fileName = Request.QueryString ["file"];
                var text = Request.QueryString ["text"];

                // Not using a switch statement here allows the enumeration to be case insensitive and to not require parsing
                if (action.ToLower () == PostAction.Append.ToString ().ToLower ()) {
                    new FileAppender (contentDirectory).Append (fileName, text);
                    Message = "File append complete.";
                } else if (action.ToLower () == PostAction.AppendLine.ToString ().ToLower ()) {
                    new FileAppender (contentDirectory).Append (fileName, text + Environment.NewLine);
                    Message = "File append complete (with newline).";
                } else if (action.ToLower () == PostAction.Write.ToString ().ToLower ()) {
                    new FileOverwriter (contentDirectory).Overwrite (fileName, text);
                    Message = "File overwrite complete.";
                }
                else{
                    Message = "Invalid action: " + action;
                }
            } else
                Unauthorised ();
        }

        private bool UserIsAuthorised()
        {
            if (ConfigurationSettings.AppSettings ["RequireAuthentication"] != false.ToString ()) {
                Console.WriteLine ("Authentication is required.");
                var providedKey = Request.QueryString ["key"];

                var actualKey = ConfigurationSettings.AppSettings ["MasterKey"];

                var isAuthenticated = providedKey.Equals (actualKey);

                Console.WriteLine ("Is authenticated: " + isAuthenticated);

                return isAuthenticated;
            } else {
                Console.WriteLine ("Authentication is not required.");
                return true;
            }
        }

        private void Unauthorised()
        {
            Message = "The user is not authorised.";
        }
    }
}

