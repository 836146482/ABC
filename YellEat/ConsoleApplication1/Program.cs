using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = "smtp.exmail.qq.com";
            var emailPassword = "hgsoft123";
            var email = "yelleat@huagemsoft.com";
            var client = new SmtpClient(host);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(email, emailPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            var addressFrom = new MailAddress(email, "");
            var addressTo = new MailAddress("1101202419@qq.com", "Get Password");
            var message = new MailMessage(addressFrom, addressTo);
            message.Subject = "Get Password";
            message.Body = "Dear Sir or Madam,it's from Yelleat.Your password is '" +"123" + "' .Keep it please.";
            message.Sender = new MailAddress(email);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            client.SendAsync(message, "");
            Console.Read();
        }
    }
}
