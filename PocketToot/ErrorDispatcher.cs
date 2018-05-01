using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace PocketToot
{
    public static class ErrorDispatcher
    {
        public static void ShowError(Exception e, string where)
        {
            var title = "Error";
            if (e is WebException)
                title = "HTTP Error";
            else if (e is JsonSerializationException)
                title = "Serialization Error";
            else if (e is ApiException)
                title = "API Error";
            title += " in " + where;

            MessageBox.Show(e.Message,
                title, 
                MessageBoxButtons.OK,
                MessageBoxIcon.Hand,
                MessageBoxDefaultButton.Button1);
        }
    }
}
