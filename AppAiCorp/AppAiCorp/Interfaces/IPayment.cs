using AppAiCorp.Enums;
using AppAiCorp.Resource;

namespace AppAiCorp.Interfaces
{
    /// <summary>
    /// Pay process.
    /// </summary>

    public interface IPayment
    {
        string MerchantId { get; }
        void Submit(Transaction request, string merchantPwd, string preSharedKey, string postUrlHashMethod, HashOption hashMethod = HashOption.Sha1);
    }

}
