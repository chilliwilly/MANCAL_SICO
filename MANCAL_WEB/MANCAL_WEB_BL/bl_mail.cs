using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace MANCAL_WEB_BL
{
    public class bl_mail
    {
        public bool envioMailRenueva(String usr_name)
        {
            String para = usr_name + "@dts.cl";
            String cuerpo = "Estimado: <br>" +
                            "Se le ha enviado este mail ya que solicito renovacion de su contraseña. Su contraseña temporal es <h1>password</h1>, recuerde cambiarla por la que estime conveniente. <br>" +
                            "Favor no responder a este mail. <br>" +
                            "Gracias.";


            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(para);
            msg.From = new MailAddress("sicomantocal@dts.cl", "Admin Manto - Cal", System.Text.Encoding.UTF8);
            msg.Subject = "Renovación Contraseña";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cuerpo;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "post2";
            client.EnableSsl = false;

            try
            {
                client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }
        }

        public bool envioMailCambia(String usr_name)
        {
            String para = usr_name + "@dts.cl";
            String cuerpo = "Estimado: <br>" +
                            "Se ha realizado exitosamente el cambio de su contraseña. <br>" +
                            "Favor no responder a este mail. <br>" +
                            "Gracias.";


            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(para);
            msg.From = new MailAddress("sicomantcal@dts.cl", "Admin Manto - Cal", System.Text.Encoding.UTF8);
            msg.Subject = "Cambio de Contraseña";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cuerpo;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "post2";
            client.EnableSsl = false;

            try
            {
                client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }
        }
    }
}
