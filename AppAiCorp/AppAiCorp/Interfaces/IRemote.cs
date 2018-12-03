using System.Collections.Specialized;
using AppAiCorp.Enums;

namespace AppAiCorp.Interfaces
{
    /// <summary>
    /// Rem post.
    /// </summary>
    public interface IRemote
    {
        NameValueCollection InputValues { get; set; }
        DefaultMethod Method { get; set; }
    }
}
