using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System;

namespace InspectionReportWebApp
{
    public static class EmailHelper
    {
        public static async Task SendRequestEmail(string name, string department, string email, string reason)
        {
            // Brevo SMTP server settings
            string smtpHost = "smtp-relay.brevo.com"; // Replace with the actual SMTP server hostname
            int smtpPort = 587; // Replace with the appropriate SMTP port
            string smtpUsername = "sjcenrodocs2021@gmail.com"; // Replace with your SMTP username
            string smtpPassword = "kI1Rb6cQ0GAJZzfv"; // Replace with your SMTP password

            // Create an SMTP client
            using (var client = new SmtpClient(smtpHost))
            {
                client.Port = smtpPort;
                client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                client.EnableSsl = true; // Enable SSL/TLS encryption (recommended)

                // Handle SSL certificate validation (optional)
                ServicePointManager.ServerCertificateValidationCallback =
                    (s, certificate, chain, sslPolicyErrors) => true;

                // Create and configure the email message
                var message = new MailMessage
                {
                    From = new MailAddress("sjcenrodocs2021@gmail.com", "CENROInspection"),
                    Subject = "[Request] Login Credentials",
                    Body = $"Name: {name}\nDepartment: {department}\nEmail: {email}\nReason: {reason}"
                };

                message.To.Add(new MailAddress("idosedzelvan@gmail.com", "Edzel Van Idos"));

                try
                {
                    // Send the email
                    await client.SendMailAsync(message);
                    Console.WriteLine("Email sent successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
            }
        }
    }
}
