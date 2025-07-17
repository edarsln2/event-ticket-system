using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

public class EmailSenderService
{
    private readonly IConfiguration _config;
    private readonly SmtpClient _smtpClient;
    private readonly string _fromEmail;

    public EmailSenderService(IConfiguration config)
    {
        _config = config;

        var host = _config["SmtpSettings:Host"];
        var port = int.Parse(_config["SmtpSettings:Port"]!);
        var email = _config["SmtpSettings:Email"];
        var password = _config["SmtpSettings:Password"];

        _fromEmail = email!;

        _smtpClient = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(email, password),
            EnableSsl = true
        };
    }

    public void SendTicketEmail(string toEmail, string eventName, int quantity, decimal totalPrice)
    {
        var subject = "Bilet Satın Alma";
        var templatePath = Path.Combine(AppContext.BaseDirectory, "Template", "EmailTemplate.html");
        var bodyTemplate = File.ReadAllText(templatePath, Encoding.UTF8);
        var body = bodyTemplate.Replace("{Event.Name}", eventName).Replace("{Quantity}", quantity.ToString()).Replace("{Total.Price}", totalPrice.ToString("0.00"));

        var mail = new MailMessage
        {
            From = new MailAddress(_fromEmail),
            Subject = subject,
            Body = body, 
            IsBodyHtml = true
        };

        mail.To.Add(toEmail);
        _smtpClient.Send(mail);
    }
}


