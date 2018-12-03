using System;
using System.Web;
using System.Web.Configuration;
using AppAiCorp.Enums;
using AppAiCorp.Implements;
using AppAiCorp.Resource;
using NUnit.Framework;

namespace AppAiCorp
{

    /// <summary>
    /// Default.
    /// </summary>
    ///

    public partial class Default : System.Web.UI.Page
    {

        public void SubmitPay()
        {
            //create instance object Transaction
            Transaction sSubmit = new Transaction
            {
                //Order Details
                Amount = 1000,
                CurrencyCode = "978", //EUR  - ISO 421

                EchoAVSCheckResult = true,
                EchoCV2CheckResult = true,
                EchoThreeDSecureAuthenticationCheckResult = true,
                EchoCardType = true,

                AVSOverridePolicy = "PPP",
                CV2Overridepolicy = "PP",

                ThreeDSecureOverridePolicy = true,
                OrderID = "Order-1234",
                TransactionType = TransType.SALE,
                OrderDescription = "A test order",

                CallbackURL = WebConfigurationManager.AppSettings["CallBackUrl"],
                ServerResultURL = "",

                //Payment Details
                CustomerName = "A Customer",

                //Billing Address
                Address1 = "1 Some Street",
                Address2 = "",
                Address3 = "",
                Address4 = "",
                City = "Some City",
                State = "Some State",
                PostCode = "PO54 3DD",
                CountryCode = "826", //UK

                //Customer Details
                EmailAddress = "test@test.com",
                PhoneNumber = "12345678",
                EmailAddressEditable = false,
                PhoneNumberEditable = false,
                CV2Mandatory = true,
                Address1Mandatory = true,
                CityMandatory = true,
                PostCodeMandatory = true,
                StateMandatory = true,
                CountryMandatory = true,
                PaymentFormDisplaysResult = false
            };

            //acess to server api according with instructions
            //of access
            string PostUrl = WebConfigurationManager.AppSettings["PostUrl"];
            string MerchantId = WebConfigurationManager.AppSettings["MerchantId"];
            string MerchantPwd = WebConfigurationManager.AppSettings["MerchantPassword"];
            string PreSharedKey = WebConfigurationManager.AppSettings["PreSharedKey"];

            //submit "POST"s
            var http = HttpContext.Current;
            //validate MerchantID
            var SubmitProcessPayment = new Payment(MerchantId, http);

            SubmitProcessPayment.Submit(sSubmit, MerchantPwd, PreSharedKey, PostUrl);
        }

        /// <summary>
        /// Buttons the payment clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguments.</param>

        public void BtnPaymentClicked(object sender, EventArgs args)
        {
            SubmitPay();
        }
    }
}
