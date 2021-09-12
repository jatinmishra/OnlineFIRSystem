using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace OnlineFIR.WebApp.Models
{
    public class SendVerificationSms
    {
        public void sendSMS()
        {
            // Your Account SID from twilio.com/console
            var accountSid = "AC691ae094b5a972d6c1dac852e3a10781";
            // Your Auth Token from twilio.com/console
            var authToken = "dec5299c3ef93e6515281e646ee0fcf0";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                to: new PhoneNumber("+919695053976"),
                from: new PhoneNumber("+15017250604"),
                body: "Hello from C#");
        }
    }
}