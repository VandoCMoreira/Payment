using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;

namespace AppAiCorp.Helpers
{
    /// <summary>
    /// Extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Appends the line format.
        /// </summary>
        /// <returns>The line format.</returns>
        /// <param name="sb">Sb.</param>
        /// <param name="format">Format.</param>
        /// <param name="args">Arguments.</param>
        public static StringBuilder AppendLineFormat(this StringBuilder sb, string format, params object[] args)
        {
            sb.AppendLine(string.Format(format, args));
            return sb;
        }

        /// <summary>
        /// Add the specified collection, name and value.
        /// </summary>
        /// <param name="collection">Collection.</param>
        /// <param name="name">Name.</param>
        /// <param name="value">Value.</param>
        public static void Add(this NameValueCollection collection, string name, object value)
        {
            collection.Add(name, (value == null ? "" : value.ToString()));
        }

        /// <summary>
        /// Adds the property.
        /// </summary>
        /// <param name="collection">Collection.</param>
        /// <param name="entity">Entity.</param>
        /// <param name="e">E.</param>
        /// <param name="value">Value.</param>
        /// <typeparam name="TEntity">The 1st type parameter.</typeparam>
        /// <typeparam name="TProperty">The 2nd type parameter.</typeparam>
        public static void AddProperty<TEntity, TProperty>(this NameValueCollection collection, TEntity entity, Expression<Func<TEntity, TProperty>> e, object value = null)
        {
            MemberExpression body = e.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("Expression does not refer to a member");

            PropertyInfo member = body.Member as PropertyInfo;
            if (member == null)
               throw new ArgumentException("Expression does not refer to a property");


            collection.Add(member.Name, value ?? member.GetValue(entity, null));
        }

        /// <summary>
        /// Tos the query string.
        /// </summary>
        /// <returns>The query string.</returns>
        /// <param name="collection">Collection.</param>
        /// <param name="omitEmpty">If set to <c>true</c> omit empty.</param>
        /// <param name="encode">If set to <c>true</c> encode.</param>
        /// <param name="delimiter">Delimiter.</param>
        public static string ToQueryString(this NameValueCollection collection, bool omitEmpty = false, bool encode = true, string delimiter = "&")
        {
            var items = new List<string>();
            foreach (string key in collection.AllKeys)
            {
                var values = collection.GetValues(key);
                foreach (var value in values)
                    if ((omitEmpty ? !string.IsNullOrEmpty(value) : true))
                        items.Add(string.Concat(key, "=", (encode ? HttpUtility.UrlEncode(value) : value)));
            }
            return string.Join(delimiter, items.ToArray());
        }
    }
}
