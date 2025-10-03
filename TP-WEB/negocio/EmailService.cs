using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    internal class EmailService
    {
        private MailMessage email;
        private SmtpClient server;
        
        EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("ejemploprogramacion3equipo9a@gmail.com", "Programacion39A");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string destinatario, string nombre)
        {
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates/emailTemplate.html");
            string body = File.ReadAllText(templatePath);

            //variable
            body = body.Replace("{{nombre}}", nombre);

            email = new MailMessage();
            email.From = new MailAddress("noresponder@programacion3equipo9A.com");
            email.To.Add(destinatario);
            email.Subject = "Confirmación de tu participación - PROMO GANÁ!";
            email.IsBodyHtml = true;
            email.Body = body;
        }

        public void enviarCorreo()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
