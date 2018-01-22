using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chpt26.WS.Models;

namespace Chpt26.WS
{
    /// <summary>
    /// Summary description for ws
    /// </summary>
    public class ws : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            if (context.IsWebSocketRequest)
            {
                var chatUser = new ChatUser();
                chatUser.UserName = context.Request.QueryString["name"];

            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}