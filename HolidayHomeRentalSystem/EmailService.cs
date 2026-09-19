using System;
using System.Net;
using System.Net.Mail;

namespace HolidayHomeRentalSystem
{
    internal static class EmailService
    {
     
        private const string SenderEmail = "a.v.tkachenko538@gmail.com";
        private const string AppPassword = "jdwa psgg uuve jxih";
        private const string SenderName = "Holiday Home Rental System";

        public static void SendEmail(string toAddress, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(SenderEmail, SenderName);
            mail.To.Add(toAddress);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(SenderEmail, AppPassword);
            smtp.EnableSsl = true;
            smtp.Timeout = 10000;

            smtp.Send(mail);
        }

        public static void SendBookingConfirmation(string toEmail, string renterName,
            string propertyTitle, DateTime checkIn, DateTime checkOut,
            int guests, decimal totalPrice)
        {
            string subject = "Booking Confirmation - " + propertyTitle;

            string body =
                "Dear " + renterName + ",\n\n" +
                "Your booking has been confirmed!\n\n" +
                "Booking Details:\n" +
                "  Property: " + propertyTitle + "\n" +
                "  Check-in: " + checkIn.ToString("dd-MMM-yyyy") + "\n" +
                "  Check-out: " + checkOut.ToString("dd-MMM-yyyy") + "\n" +
                "  Guests: " + guests + "\n" +
                "  Total Price: " + totalPrice.ToString("C2") + "\n\n" +
                "Thank you for using Holiday Home Rental System!\n\n" +
                "Kind regards,\n" +
                "Holiday Home Rental Team";

            SendEmail(toEmail, subject, body);
        }

        public static void SendCancellationConfirmation(string toEmail, string renterName,
            string propertyTitle, DateTime checkIn, DateTime checkOut)
        {
            string subject = "Booking Cancelled - " + propertyTitle;

            string body =
                "Dear " + renterName + ",\n\n" +
                "Your booking has been cancelled.\n\n" +
                "Cancelled Booking:\n" +
                "  Property: " + propertyTitle + "\n" +
                "  Check-in: " + checkIn.ToString("dd-MMM-yyyy") + "\n" +
                "  Check-out: " + checkOut.ToString("dd-MMM-yyyy") + "\n\n" +
                "Kind regards,\n" +
                "Holiday Home Rental Team";

            SendEmail(toEmail, subject, body);
        }
    }
}