using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using AppAiCorp.Enums;
using AppAiCorp.Helpers;

namespace AppAiCorp.Resource
{
    /// <summary>
    /// Trans request.
    /// </summary>
    public class Transaction
    {
        [Required]
        public string HashDigest { get; set; } //- needs to be calculated as part of the task
        [Required]
        public string MerchantID { get; set; } //- (see above)
        [Required]
        public int Amount { get; set; } //- any transaction amount
        [Required]
        public string CurrencyCode { get; set; } //- valid code for UK pounds, EUROs or USD
        [Required]
        public string OrderID { get; set; }//- "Order-1234"
        [Required]
        public string TransactionDateTime { get; set; }//- a valid date/time
        [Required]
        public string CallbackURL { get; set; }//- "http://www.somedomain.com/callback.php"
        [Required]
        public ResultMethod ResultDeliveryMethod { get; set; }
        public TransType TransactionType { get; set; }

        public bool EchoAVSCheckResult { get; set; } //- true or false
        public bool EchoCV2CheckResult { get; set; } //- true or false
        public bool EchoThreeDSecureAuthenticationCheckResult { get; set; } //- true or false
        public bool EchoCardType { get; set; } //- true or false
        public string AVSOverridePolicy { get; set; } //- "PPPP"
        public string CV2Overridepolicy { get; set; }//- "PP"
        public bool ThreeDSecureOverridePolicy { get; set; }//- "true"
        public string OrderDescription { get; set; } //- "A test order"
        public string CustomerName { get; set; } //- "A Customer"
        public string Address1 { get; set; } //- "1 Some Street"
        public string Address2 { get; set; } //- ""
        public string Address3 { get; set; } //- ""
        public string Address4 { get; set; }//- ""
        public string City { get; set; }//- "Some City"
        public string State { get; set; }//- "Some State"
        public string PostCode { get; set; }//- "PO54 3DD"
        public string CountryCode { get; set; }//- Valid code for UK
        public string EmailAddress { get; set; }//- "test@test.com"
        public string PhoneNumber { get; set; }//- "12345678"
        public bool EmailAddressEditable { get; set; }//– true or false
        public bool PhoneNumberEditable { get; set; }//- true or false
        public bool CV2Mandatory { get; set; }// - true or false
        public bool Address1Mandatory { get; set; }//- true or false
        public bool CityMandatory { get; set; }//- true or false
        public bool PostCodeMandatory { get; set; }//- true or false
        public bool StateMandatory { get; set; }//- true or false
        public bool CountryMandatory { get; set; }//- true or false
        public string ServerResultURL { get; set; }//- ""
        public bool PaymentFormDisplaysResult { get; set; }// - ""

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppAiCorp.Resource.TransRequest"/> class.
        /// </summary>

        public Transaction()
        {
            TransactionType = TransType.SALE;
            ResultDeliveryMethod = ResultMethod.POST;
            CV2Mandatory = true;
            TransactionDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss zzzz");
        }
        /// <summary>
        /// Tos the name value collection.
        /// </summary>
        /// <returns>The name value collection.</returns>

        public NameValueCollection ToNameValueCollection()
        {

            NameValueCollection valueCollection = new NameValueCollection();

            valueCollection.AddProperty(this, r => r.Amount);
            valueCollection.AddProperty(this, r => r.CurrencyCode);
            valueCollection.AddProperty(this, r => r.EchoAVSCheckResult);
            valueCollection.AddProperty(this, r => r.EchoCV2CheckResult);
            valueCollection.AddProperty(this, r => r.EchoThreeDSecureAuthenticationCheckResult);
            valueCollection.AddProperty(this, r => r.EchoCardType);
            valueCollection.AddProperty(this, r => r.OrderID);
            valueCollection.AddProperty(this, r => r.TransactionType);
            valueCollection.AddProperty(this, r => r.TransactionDateTime);
            valueCollection.AddProperty(this, r => r.CallbackURL);
            valueCollection.AddProperty(this, r => r.OrderDescription);
            valueCollection.AddProperty(this, r => r.CustomerName);
            valueCollection.AddProperty(this, r => r.Address1);
            valueCollection.AddProperty(this, r => r.Address2);
            valueCollection.AddProperty(this, r => r.Address3);
            valueCollection.AddProperty(this, r => r.Address4);
            valueCollection.AddProperty(this, r => r.City);
            valueCollection.AddProperty(this, r => r.State);
            valueCollection.AddProperty(this, r => r.PostCode);
            valueCollection.AddProperty(this, r => r.CountryCode);
            valueCollection.AddProperty(this, r => r.EmailAddress);
            valueCollection.AddProperty(this, r => r.PhoneNumber);
            valueCollection.AddProperty(this, r => r.EmailAddressEditable);
            valueCollection.AddProperty(this, r => r.PhoneNumberEditable);
            valueCollection.AddProperty(this, r => r.CV2Mandatory);
            valueCollection.AddProperty(this, r => r.Address1Mandatory);
            valueCollection.AddProperty(this, r => r.CityMandatory);
            valueCollection.AddProperty(this, r => r.PostCodeMandatory);
            valueCollection.AddProperty(this, r => r.StateMandatory);
            valueCollection.AddProperty(this, r => r.CountryMandatory);
            valueCollection.AddProperty(this, r => r.ResultDeliveryMethod);
            valueCollection.AddProperty(this, r => r.ServerResultURL);
            valueCollection.AddProperty(this, r => r.PaymentFormDisplaysResult);

            return valueCollection;
        }


    }

}
