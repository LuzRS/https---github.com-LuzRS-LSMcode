using System.Net.Mail;
public class Correo{
    public  string Destinatario{get;set;}=string.Empty;
    public string Asunto {get;set;}=string.Empty;
    public string Mensaje {get;set;}=string.Empty;
    public void Enviar(){
        MailMessage correo = new MailMessage();
    correo.From = new MailAddress("reynalizbethhdz@gmail.com", null, System.Text.Encoding.UTF8);//Correo de salida
    correo.To.Add(this.Destinatario); //Correo destino?
    correo.Subject = this.Asunto;
    correo.Body = this.Mensaje; //Mensaje del correo
    correo.IsBodyHtml = true;
    correo.Priority = MailPriority.Normal;
    SmtpClient smtp = new SmtpClient();
    smtp.UseDefaultCredentials = false;
    smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
    smtp.Port = 25; //Puerto de salida
    smtp.EnableSsl=true;
    smtp.Credentials = new System.Net.NetworkCredential("reynalizbethhdz@gmail.com", "tuat zvfr vujg fnek");//Cuenta de correo
    smtp.Send(correo);
    }
}