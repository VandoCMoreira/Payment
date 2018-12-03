using System.Web;
using AppAiCorp.Enums;
using AppAiCorp.Implements;
using AppAiCorp.Resource;
using AppAiCorp.Helpers;
using NUnit.Framework;
using System.Collections.Specialized;

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
    }
}
