using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using AppAiCorp.Enums;
using AppAiCorp.Helpers;
using AppAiCorp.Interfaces;
using NUnit.Framework;

namespace AppAiCorp.Implements
{
    /// <summary>
    /// Rem post.
    /// </summary>
   
    public class Remote : IRemote
    {
        private readonly HttpContext _httpContext;

        public NameValueCollection InputValues { get; set; }
        public DefaultMethod Method { get; set; }
        public string Url { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppAiCorp.Implements.RemPost"/> class.
        /// </summary>
        /// <param name="httpContext">Http context.</param>
        /// <param name="url">URL.</param>
        /// <param name="method">Method.</param>

        public Remote(HttpContext httpContext, string url, DefaultMethod method) : this(httpContext)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url Error!");

            if (httpContext.Equals(null))
                throw new ArgumentNullException("httpContext Error!");

            Url = url;
            Method = method;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppAiCorp.Implements.RemPost"/> class.
        /// </summary>
        /// <param name="httpContext">Http context.</param>
        public Remote(HttpContext httpContext)
        {
            InputValues = new NameValueCollection();
            _httpContext = httpContext;
        }

        /// <summary>
        /// Adds the input.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="value">Value.</param>
   
        public void AddInput(string name, object value)
        {
            InputValues.Add(name, value.ToString());
        }

        /// <summary>
        /// Post the specified formName.
        /// </summary>
        /// <param name="formName">Form name.</param>
      
        public void Post(string formName)
        {
            if (string.IsNullOrEmpty(formName))
                throw new ArgumentNullException("Form Name Error!");

            var html = new StringBuilder();

            html.AppendLine("<html><head>");
            html.AppendLineFormat("</head><body onload=\"document.{0}.submit()\">", formName);
            html.AppendLineFormat("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", formName, Method.ToString(), Url);

            for (int i = 0; i < InputValues.Keys.Count; i++)
            {
                html.AppendLineFormat("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">",
                    HttpUtility.HtmlEncode(InputValues.Keys[i]),
                    HttpUtility.HtmlEncode(InputValues[InputValues.Keys[i]])
                    );
            }

            html.AppendLine("</form>");
            html.AppendLine("</body></html>");
            _httpContext.Response.Clear();
            _httpContext.Response.Write(html.ToString());
            _httpContext.Response.End();

        }
    }
}
