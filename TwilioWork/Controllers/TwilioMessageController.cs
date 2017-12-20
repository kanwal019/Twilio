using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwilioWork.Controllers
{
    public class TwilioMessageController : Controller
    {
        // GET: TwilioMessage
        public ActionResult Index()
        {
            return View();
        }

        public string SendMessage(string toNumber, string messageDesc)
        {
            try
            {
                string accountSid = System.Configuration.ConfigurationManager.AppSettings["ClientId"];
                string authToken = System.Configuration.ConfigurationManager.AppSettings["ClientSecret"];
                string fromNumber = System.Configuration.ConfigurationManager.AppSettings["PhoneNumber"];
                TwilioClient.Init(accountSid, authToken);

                var to = new PhoneNumber(toNumber);
                var message = MessageResource.Create(to, from: new PhoneNumber(fromNumber), body: messageDesc);

                return ("Message Sent : " + message.Sid + " !!");
            }
            catch(Exception ex)
            {
                return ("Error : " + ex.Message + " !!"); ;
            }
        }
    }
}