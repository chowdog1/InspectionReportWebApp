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
            string smtpPassword = "xsmtpsib-1576bac15f1bf34f275c2d537150dda0408d79291862c0715d83549613af61b6-RkBjv3h7pA9dSmgW"; // Replace with your SMTP password

            // Create an SMTP client
            using (var client = new SmtpClient(smtpHost))
            {
                client.Port = smtpPort;
                client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                client.EnableSsl = false; // Enable SSL/TLS encryption (recommended)

                // Handle SSL certificate validation (optional)
                ServicePointManager.ServerCertificateValidationCallback =
                    (s, certificate, chain, sslPolicyErrors) => true;

                // Create and configure the email message
                var message = new MailMessage
                {
                    From = new MailAddress("sjcenrodocs2021@gmail.com", "CENROInspection"),
                    Subject = "[Request] Login Credentials",
                    Body = $@"
                    Dear Sir/Madam,

                    I am writing to request access credentials for the IRMS within our department. I believe access to this system is crucial for the following reasons:

                    Name: {name}
                    Department: {department}
                    Email: {email}
                    Reason for Access: {reason}

                    I would appreciate your prompt attention to this matter.

                    Thank you.

                    Sincerely,
                    {name}"
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
