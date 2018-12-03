using System;
using System.Collections.Specialized;
using System.Web;
using AppAiCorp.Enums;
using AppAiCorp.Helpers;
using AppAiCorp.Interfaces;
using AppAiCorp.Resource;

namespace AppAiCorp.Implements
{

    /// <summary>
    /// Pay process.
    /// </summary>
    public class Payment : IPayment
    {
        private readonly HttpContext _context;

        public string MerchantId { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppAiCorp.Implements.PayProcess"/> class.
        /// </summary>
        /// <param name="merchantId">Merchant identifier.</param>
        /// <param name="context">Context.</param>

        public Payment(string merchantId, HttpContext context)
        {
            if (string.IsNullOrEmpty(merchantId))
                throw new ArgumentNullException("MerchantId Error!");

            if (context.Equals(null))
                throw new ArgumentNullException("context Error!");

            _context = context;
            MerchantId = merchantId;
        }


        public void ValidateTypeFieldsTransaction(Transaction request)
        {

            if (request == null)
                throw new ArgumentNullException("Request Error!");

            //var http = HttpContext.Current;
            var requestNVCol = request.ToNameValueCollection();

            for (int i = 0; i < requestNVCol.AllKeys.Length; i++)
            {
                var key = requestNVCol.AllKeys[i];
                var type = requestNVCol.AllKeys[i].GetType();

                //String
                if (type == typeof(String))
                {
                    if (string.IsNullOrEmpty(requestNVCol.GetValues(key)[0]))
                        throw new ArgumentNullException(key + " Error!" + "Type of Field: " + type);
                }
                //Boolean
                if (type == typeof(Boolean))
                {
                    if (string.IsNullOrEmpty(requestNVCol.GetValues(key)[0]))
                        throw new ArgumentNullException(key + " Error!" + "Type of Field: " + type);
                }

            }
        }

        /// <summary>
        /// Subs the trans.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="merchantPwd">Merchant password.</param>
        /// <param name="preSharedKey">Pre shared key.</param>
        /// <param name="postUrl">Post URL.</param>
        /// <param name="hashMethod">Hash method.</param>  
        public void Submit(Transaction request, string merchantPwd, string preSharedKey, string postUrl, HashOption hashMethod = HashOption.Sha1)
        {
             //before submit - Validade Fields of Request Transaction
            //ValidateTypeFieldsTransaction(request);


            string[] strArrays = { merchantPwd, preSharedKey, postUrl };

            var remPost = new Remote(_context, postUrl, DefaultMethod.Post);

            var nvCollection = new NameValueCollection();

            nvCollection.Add("PreSharedKey", preSharedKey);
            nvCollection.Add("MerchantID", MerchantId);
            nvCollection.Add("Password", merchantPwd);

            var requestNVCol = request.ToNameValueCollection();

            for (int i = 0; i < requestNVCol.AllKeys.Length; i++)
            {
                var key = requestNVCol.AllKeys[i];
                nvCollection.Add(key, requestNVCol.GetValues(key)[0]);
                remPost.AddInput(key, requestNVCol.GetValues(key)[0]);
            }

            var qStr = nvCollection.ToQueryString(false, false);

            if (qStr == null)
                throw new ArgumentNullException("qStr Error!");

            var digest = Hash.ComputeHashDigest(qStr, preSharedKey, hashMethod);

            if (digest == null)
                throw new ArgumentNullException("digest Error!");

            remPost.AddInput("ThreeDSecureCompatMode", "false");
            remPost.AddInput("ServerResultCompatMode", "false");
            remPost.AddInput("HashDigest", digest);
            remPost.AddInput("MerchantID", MerchantId);

            remPost.Post("CardsavePaymentForm");
        }
    }
}
