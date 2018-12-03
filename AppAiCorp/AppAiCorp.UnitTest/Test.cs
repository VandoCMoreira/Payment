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
        public void Crate_Payment_ok()
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
        public void Crate_Payment_Merch()
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
        public void Crate_Payment_http()
        {
            var MerchantId = "Progra-7702818";
            var http = HttpContext.Current;
            http = null;

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
        public void Crate_Payment_both()
        {
            var MerchantId = "";
            var http = HttpContext.Current;
            http = null;

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
        public void Crate_Remote_Http()
        {
            var postUrl = "";
            var _context = HttpContext.Current;
            var Default = DefaultMethod.Post;
        
            try
            {
                Remote remote = new Remote(_context, postUrl, Default);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.ArgumentNullException);
            }
        }

        [Test()]
        public void Crate_Remote_Context()
        {
            var postUrl = "https://mms.payvector.net/Pages/PublicPages/PaymentForm.aspx";
            var _context = HttpContext.Current;
            _context = null;
            var Default = DefaultMethod.Post;

            try
            {
                Remote remote = new Remote(_context, postUrl, Default);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.NullReferenceException);
            }
        }

        [Test()]
        public void Crate_Remote_Both()
        {
            var postUrl = "";
            var _context = HttpContext.Current;
            _context = null;
            var Default = DefaultMethod.Post;

            try
            {
                Remote remote = new Remote(_context, postUrl, Default);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is System.ArgumentNullException);
            }
        }

        [Test()]
        public void post_full()
        {
            var formName = "CardsavePaymentForm";
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
        public void post_formName()
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
        public void Query_String()
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
        public void Query_String_True()
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
    }
}
