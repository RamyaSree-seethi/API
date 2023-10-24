//using Microsoft.AspNetCore.Mvc;
//using Twilio;
//using Twilio.Rest.Api.V2010.Account;
//using Twilio.Types;

//[Route("api/[controller]")]
//[ApiController]
//public class BookingsController : ControllerBase
//{
//    private const string TwilioAccountSid = "YOUR_TWILIO_ACCOUNT_SID";
//    private const string TwilioAuthToken = "YOUR_TWILIO_AUTH_TOKEN";
//    private const string TwilioPhoneNumber = "YOUR_TWILIO_PHONE_NUMBER";

//    [HttpPost]
//    public IActionResult BookEvent([FromBody] BookingModel bookingDetails)
//    {
//        // Process the booking and save it to your database

//        // Send an SMS
//        var message = MessageResource.Create(
//            body: $"Booking successful! Details: {bookingDetails}",
//            from: new PhoneNumber(TwilioPhoneNumber),
//            to: new PhoneNumber("8247510370")
//        );

//        // Handle the response from Twilio here

//        return Ok("Booking successful");
//    }
//}
