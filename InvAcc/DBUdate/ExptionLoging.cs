using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
/// <summary>    
/// Summary description for ExceptionLogging    
/// </summary>    
public static class ExceptionLogging
{
#pragma warning disable CS0649 // Field 'ExceptionLogging.exurl' is never assigned to, and will always have its default value null
#pragma warning disable CS0414 // The field 'ExceptionLogging.ToMail' is assigned but its value is never used
    private static String ErrorlineNo, Errormsg, ErrorLocation, extype, exurl, Frommail, ToMail, Sub, HostAdd, EmailHead, EmailSing;
#pragma warning restore CS0414 // The field 'ExceptionLogging.ToMail' is assigned but its value is never used
#pragma warning restore CS0649 // Field 'ExceptionLogging.exurl' is never assigned to, and will always have its default value null
    public static void SendErrorTomail(Exception exmail)
    {
        try
        {
            var newline = "<br/>";
            ErrorlineNo = exmail.StackTrace.Substring(exmail.StackTrace.Length - 7, 7);
            Errormsg = exmail.GetType().Name.ToString();
            extype = exmail.GetType().ToString();
            //  exurl = context.Current.Request.Url.ToString();
            ErrorLocation = exmail.Message.ToString();
            EmailHead = "<b>Dear Team,</b>" + "<br/>" + "An exception occurred in a Application Url" + " " + exurl + " " + "With following Details" + "<br/>" + "<br/>";
            EmailSing = newline + "Thanks and Regards" + newline + "    " + "     " + "<b>Application Admin </b>" + "</br>";
            Sub = "Exception occurred" + " " + "in Application" + " " + exurl;
            HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
            string errortomail = EmailHead + "<b>Log Written Date: </b>" + " " + DateTime.Now.ToString() + newline + "<b>Error Line No :</b>" + " " + ErrorlineNo + "\t\n" + " " + newline + "<b>Error Message:</b>" + " " + Errormsg + newline + "<b>Exception Type:</b>" + " " + extype + newline + "<b> Error Details :</b>" + " " + ErrorLocation + newline + "<b>Error Page Url:</b>" + " " + exurl + newline + newline + newline + newline + EmailSing;
            using (MailMessage mailMessage = new MailMessage())
            {
                Frommail = "mrzz00001@gmail.com";
                ToMail = "aldmrd008@gmail.com";
                mailMessage.From = new MailAddress(Frommail);
                mailMessage.Subject = Sub;
                mailMessage.Body = errortomail;
                mailMessage.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();  // creating object of smptpclient    
                smtp.Host = HostAdd;              //host of emailaddress for example smtp.gmail.com etc    
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = mailMessage.From.Address;
                NetworkCred.Password = "ebrahim2007";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage); //sending Email  
            }
        }
#pragma warning disable CS0168 // The variable 'em' is declared but never used
        catch (Exception em)
#pragma warning restore CS0168 // The variable 'em' is declared but never used
        {

        }
    }
}