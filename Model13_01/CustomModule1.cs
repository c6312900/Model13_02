using System;
using System.Web;

namespace Model13_01
{
    public class CustomModule1 : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
         //   context.LogRequest += new EventHandler(OnLogRequest);
            context.BeginRequest += new EventHandler(OnBeginRequest);
        }

        #endregion

        //public void OnLogRequest(Object source, EventArgs e)
        //{
        //    //custom logging logic can go here
        //}

        public void OnBeginRequest(Object source, EventArgs e)
        {
            //custom logging logic can go here
            HttpApplication context=(HttpApplication)source;
            string url = context.Context.Request.QueryString["url"];
            if (url !=null)
            {
                context.Context.Response.Redirect(url);
            }

        }
    }
}
