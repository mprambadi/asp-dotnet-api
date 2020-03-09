using System.Collections.Generic;
using System;
using MimeKit;
using MailKit.Net.Smtp;

namespace dotnet_mediatr.Infrastructure.MailServices
{
    public class Mail
    {
        public static void Send()
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("mprambadi", "mprambadi@gmail.com"));
            message.To.Add(new MailboxAddress("mprambadi", "mprambadi@gmail.com"));
            var builder = new BodyBuilder();


            var numbers = new int[] { 1, 2, 3, 4, 5, 6 };
            var random = new Random();
            var id = random.Next(1, 10);


            builder.HtmlBody = string.Format($@"<p>Hello mprambadi {id}</p>");
            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                try
                {
                    if (!client.IsConnected)
                    {
                        client.Connect("smtp.mailtrap.io", 587, false);
                        client.Authenticate("75ad4d2076ecae", "85e8851b30d94d");
                    }

                    client.Send(message);
                    Console.WriteLine("Mail Sended");
                    client.Disconnect(true);
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e.ToString());

                }


            }

        }


    }

}