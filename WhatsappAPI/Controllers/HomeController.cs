using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhatsappAPI.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

/*
 Please note that the purpose of this project is to create an sample application which is used to send
 automated messages to the client .
 I have used the code provided in C# after creating a developer ID . Also ,refer to documentation .
 
    Below is the controller for the twilio APP.
     */

namespace WhatsappAPI.Controllers
{
    public class HomeController : Controller
    {
        public List<Property> _listProperty = new List<Property>()
            {
                new Property{
                    PropertyID =1,
                    Postcode="PE15TT",
                    MobileNumber=0, //Please add number along with valid ISD code
                    AppointmentDate="01/01/2018",
                    HouseNumber=5,
                    SizeOfHouse=3,
                    AppointmentTime="10:00"

                },
                new Property{
                    PropertyID =2,
                    Postcode="LE27TG",
                    MobileNumber=0, //Please add number along with valid ISD code
                    AppointmentDate="02/01/2018",
                    HouseNumber=1,
                    SizeOfHouse=4,
                    AppointmentTime="11:00"

                },
                new Property{
                    PropertyID =3,
                    Postcode="LE27GG",
                    MobileNumber=0, //Please add number along with valid ISD code
                    AppointmentDate="03/01/2018",
                    HouseNumber=3,
                    SizeOfHouse=2,
                    AppointmentTime="13:00"

                }

            };
        public IActionResult Index()
        {
            return View(_listProperty);
        }

        public IActionResult SendWhatsappMessage(int? Id) {
            Property _property = _listProperty.Find(i => i.PropertyID == Id);
                    var accountSid = "ACc48bafc2e0983e5487bca53a0875dd02";
            var authToken = "657b2a1a81c6f6d9c1963545cd295e6f";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("whatsapp:+"+ _property.MobileNumber));
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");//provided by them.
            //messageOptions.Body = "Your appointment is coming up on July 21 at 3PM";
            messageOptions.Body = $"Dear User, your appointment has been finalised ,Time : {_property.AppointmentTime} ,Date:{_property.AppointmentDate}. House Details {_property.HouseNumber}, {_property.Postcode} ";
            var message = MessageResource.Create(messageOptions);
            ViewBag.Msg = $"You message has been sent to whatsap on {_property.MobileNumber}";
            return RedirectToAction("Index");
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
