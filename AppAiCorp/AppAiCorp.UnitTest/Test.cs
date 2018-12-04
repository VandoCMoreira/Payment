using System.Web;
using AppAiCorp.Enums;
using AppAiCorp.Implements;
using AppAiCorp.Resource;
using AppAiCorp.Helpers;
using NUnit.Framework;
using System.Collections.Specialized;
using System.Web.Configuration;

namespace AppAiCorp.UnitTest
{
    [TestFixture()]
    public class TransactionTest
    {

        [Test()]
        public void Crate_Payment_Success()
        {
            var MerchantId = "Progra-7702818";
            var http = HttpContext.Current;

            try
            {
                Payment SubmitProcessPayment = new Payment(MerchantId, http);

            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.NullReferenceException);
            }

        }

        [Test()]
        public void Crate_Payment_MerchantId_Empty()
        {
            var MerchantId = "";
            var http = HttpContext.Current;

            try
            {
                Payment SubmitProcessPayment = new Payment(MerchantId, http);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.ArgumentNullException);
            }
        }

        [Test()]
        public void Crate_Payment_Http_Empty()
        {
            var MerchantId = "Progra-7702818";
            HttpContext http = null;

            try
            {
                Payment SubmitProcessPayment = new Payment(MerchantId, http);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.NullReferenceException);
            }
        }

        [Test()]
        public void Crate_Payment_All_Empty()
        {
            var MerchantId = "";
            HttpContext http = null;

            try
            {
                Payment SubmitProcessPayment = new Payment(MerchantId, http);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.ArgumentNullException);
            }

        }

        [Test()]
        public void Create_Remote_PostUrl_Empty()
        {
            var postUrl = "";
            var context = HttpContext.Current;
            var Default = DefaultMethod.Post;

            try
            {
                Remote remote = new Remote(context, postUrl, Default);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.ArgumentNullException);
            }
        }

        [Test()]
        public void Crate_Remote_Context_Empty()
        {
            var postUrl = "https://mms.payvector.net/Pages/PublicPages/PaymentForm.aspx";
            var context = HttpContext.Current = null;
            var Default = DefaultMethod.Post;

            try
            {
                Remote remote = new Remote(context, postUrl, Default);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.NullReferenceException);
            }
        }

        [Test()]
        public void Crate_Remote_Context_Default_Empty()
        {
            var postUrl = "";
            var context = HttpContext.Current = null;
            var Default = DefaultMethod.Post;

            try
            {
                Remote remote = new Remote(context, postUrl, Default);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.ArgumentNullException);
            }

        }

        [Test()]
        public void Post_Sucess()
        {
            var formName = "CardsavePaymentForm";
            var postUrl = "https://mms.payvector.net/Pages/PublicPages/PaymentForm.aspx";
            var context = HttpContext.Current;
            var Default = DefaultMethod.Post;

            try
            {
                Remote remote = new Remote(context, postUrl, Default);
                remote.Post(formName);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.NullReferenceException);
            }

        }

        [Test()]
        public void Post_FormName_Empty()
        {
            var formName = "";
            var postUrl = "https://mms.payvector.net/Pages/PublicPages/PaymentForm.aspx";
            var _context = HttpContext.Current;
            var Default = DefaultMethod.Post;


            try
            {
                Remote remote = new Remote(_context, postUrl, Default);
                remote.Post(formName);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.NullReferenceException);
            }
        }

        [Test()]
        public void Post_PostUrl_Empty()
        {
            var formName = "CardsavePaymentForm";
            var postUrl = "";
            var context = HttpContext.Current;
            var Default = DefaultMethod.Post;


            try
            {
                Remote remote = new Remote(context, postUrl, Default);
                remote.Post(formName);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.ArgumentNullException);
            }
        }

        [Test()]
        public void Post_Context_Empty()
        {
            var formName = "CardsavePaymentForm";
            var postUrl = "https://mms.payvector.net/Pages/PublicPages/PaymentForm.aspx";
            var context = HttpContext.Current = null;
            var Default = DefaultMethod.Post;


            try
            {
                Remote remote = new Remote(context, postUrl, Default);
                remote.Post(formName);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.NullReferenceException);
            }
        }

        [Test()]
        public void Post_All_Empty()
        {
            var formName = "CardsavePaymentForm";
            var postUrl = "https://mms.payvector.net/Pages/PublicPages/PaymentForm.aspx";
            var context = HttpContext.Current = null;
            var Default = DefaultMethod.Post;


            try
            {
                Remote remote = new Remote(context, postUrl, Default);
                remote.Post(formName);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.NullReferenceException);
            }
        }

        [Test()]
        public void Query_String_Success()
        {
            Transaction request = new Transaction();
            var nvCollection = new NameValueCollection();

            try
            {
                nvCollection.ToQueryString(false, false);

            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.NullReferenceException);
            }
        }

        [Test()]
        public void Query_String_True_True()
        {
            Transaction request = new Transaction();
            var nvCollection = new NameValueCollection();

            try
            {
                nvCollection.ToQueryString(true, true);

            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.NullReferenceException);
            }
        }

        [Test()]
        public void Query_String_False_True()
        {
            Transaction request = new Transaction();
            var nvCollection = new NameValueCollection();

            try
            {
                nvCollection.ToQueryString(false, true);

            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.NullReferenceException);
            }
        }
        [Test()]
        public void Query_String_True_False()
        {
            Transaction request = new Transaction();
            var nvCollection = new NameValueCollection();

            try
            {
                nvCollection.ToQueryString(true, false);

            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.NullReferenceException);
            }
        }

        [Test()]
        public void Submit_Sucess()
        {

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
            var PostUrl = "https://mms.payvector.net/Pages/PublicPages/PaymentForm.aspx";
            var MerchantId = "Progra-7702818";
            var MerchantPwd = "G6CH6Z90I2";
            var PreSharedKey = "5XNm04UE0/EaXDSeKa4Fw29hTzieAl32uO4=";

            //submit "POST"s
            var http = HttpContext.Current;
            //validate MerchantID
            try
            {
                var SubmitProcessPayment = new Payment(MerchantId, http);
                SubmitProcessPayment.Submit(sSubmit, MerchantPwd, PreSharedKey, PostUrl);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.NullReferenceException);
            }
        }


        [Test()]
        public void Submit_Submit_Empty()
        {

            Transaction sSubmit = null;

               //acess to server api according with instructions
               //of access
            var PostUrl = "https://mms.payvector.net/Pages/PublicPages/PaymentForm.aspx";
            var MerchantId = "Progra-7702818";
            var MerchantPwd = "G6CH6Z90I2";
            var PreSharedKey = "5XNm04UE0/EaXDSeKa4Fw29hTzieAl32uO4=";

            //submit "POST"s
            var http = HttpContext.Current;
            //validate MerchantID
            try
            {
                var SubmitProcessPayment = new Payment(MerchantId, http);
                SubmitProcessPayment.Submit(sSubmit, MerchantPwd, PreSharedKey, PostUrl);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.NullReferenceException);
            }
        }
        [Test()]
        public void Submit_PostUrl_Empty()
        {

            Transaction sSubmit = null;

            //acess to server api according with instructions
            //of access
            var PostUrl = "";
            var MerchantId = "Progra-7702818";
            var MerchantPwd = "G6CH6Z90I2";
            var PreSharedKey = "5XNm04UE0/EaXDSeKa4Fw29hTzieAl32uO4=";

            //submit "POST"s
            var http = HttpContext.Current;
            //validate MerchantID
            try
            {
                var SubmitProcessPayment = new Payment(MerchantId, http);
                SubmitProcessPayment.Submit(sSubmit, MerchantPwd, PreSharedKey, PostUrl);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.NullReferenceException);
            }
        }

        [Test()]
        public void Submit_MerchantId_Empty()
        {

            Transaction sSubmit = null;

            //acess to server api according with instructions
            //of access
            var PostUrl = "";
            var MerchantId = "";
            var MerchantPwd = "G6CH6Z90I2";
            var PreSharedKey = "5XNm04UE0/EaXDSeKa4Fw29hTzieAl32uO4=";

            //submit "POST"s
            var http = HttpContext.Current;
            //validate MerchantID
            try
            {
                var SubmitProcessPayment = new Payment(MerchantId, http);
                SubmitProcessPayment.Submit(sSubmit, MerchantPwd, PreSharedKey, PostUrl);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.ArgumentNullException);
            }
        }
        [Test()]
        public void Submit_MerchantPwd_Empty()
        {

            Transaction sSubmit = null;

            //acess to server api according with instructions
            //of access
            var PostUrl = "";
            var MerchantId = "";
            var MerchantPwd = "";
            var PreSharedKey = "5XNm04UE0/EaXDSeKa4Fw29hTzieAl32uO4=";

            //submit "POST"s
            var http = HttpContext.Current;
            //validate MerchantID
            try
            {
                var SubmitProcessPayment = new Payment(MerchantId, http);
                SubmitProcessPayment.Submit(sSubmit, MerchantPwd, PreSharedKey, PostUrl);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.ArgumentNullException);
            }
        }
        [Test()]
        public void Submit_PreSharedKey_Empty()
        {

            Transaction sSubmit = null;

            //acess to server api according with instructions
            //of access
            var PostUrl = "";
            var MerchantId = "";
            var MerchantPwd = "";
            var PreSharedKey = "";

            //submit "POST"s
            var http = HttpContext.Current;
            //validate MerchantID
            try
            {
                var SubmitProcessPayment = new Payment(MerchantId, http);
                SubmitProcessPayment.Submit(sSubmit, MerchantPwd, PreSharedKey, PostUrl);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.ArgumentNullException);
            }
        }
        [Test()]
        public void Submit_http_Empty()
        {

            Transaction sSubmit = null;

            //acess to server api according with instructions
            //of access
            var PostUrl = "";
            var MerchantId = "";
            var MerchantPwd = "";
            var PreSharedKey = "";

            //submit "POST"s
            var http = HttpContext.Current = null;
            //validate MerchantID
            try
            {
                var SubmitProcessPayment = new Payment(MerchantId, http);
                SubmitProcessPayment.Submit(sSubmit, MerchantPwd, PreSharedKey, PostUrl);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.ArgumentNullException);
            }
        }
        [Test()]
        public void Submit_All_Empty()
        {
            try
            {
                var SubmitProcessPayment = new Payment(null, null);
                SubmitProcessPayment.Submit(null, null, null, null);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.ArgumentNullException);
            }
        }
    }
    }