using Chabagan.Fisheries.Common.SMTP;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Chabagan.Fisheries.WebApi.Utilities
{
    public class Emailer
    {

        private string fromEmail = "";
        private string fromName = "";
        private string UserName = "";
        private string Password = "";
        private string Host = "";
        private int Port = 587;

        public Emailer(SMTPSettings sMTPSettings)
        {
            this.Host = sMTPSettings.Host;
            this.Port = sMTPSettings.Port;
            this.UserName = sMTPSettings.UserName;
            this.Password = sMTPSettings.Password;
            this.fromName = sMTPSettings.FromName;
            this.fromEmail = sMTPSettings.FromEmail;
        }
        ///   </summary>
        ///  <param name="toEmail">Destination email address</param>
        /// <param name="subject">Subject line of the email</param>
        /// <param name="body">Main Email message body text</param>
        /// <param name="attachmentPathList">List of attachments from the local file system</param>
        ///   <param name="fromEmail">Address to set as the From address</param>
        ///  <param name="fromName">Name to set as the From name</param>
        ///<param name="mailAttachment">Stream object containing an attachment</param>
        ///   <returns>True if email is sent, False otherwise</returns>
        public bool SendMail(string toEmail, string subject, string body, string fromEmail = null, string fromName = null, List<string> attachmentFilePathList = null, Stream mailStreamAttachment = null, string ccEmail = null, string bccEmail = null)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage mailMsg = new MailMessage();

            //MailAddressCollection addressCollection = new MailAddressCollection();
            //addressCollection.Add("ramsacc@outlook.com");

            try
            {


                if (String.IsNullOrEmpty(fromEmail) == true)
                {
                    fromEmail = this.fromEmail;
                }

                if (String.IsNullOrEmpty(fromName) == true)
                {
                    fromName = this.fromName;
                }


                //Attach file in email, if have any


                if (attachmentFilePathList != null && attachmentFilePathList.Count > 0)
                {
                    foreach (string filePath in attachmentFilePathList)
                    {
                        Attachment attachFile = new Attachment(filePath);
                        mailMsg.Attachments.Add(attachFile);
                    }
                }


                mailMsg.From = new MailAddress(fromEmail, fromName);
                mailMsg.To.Add(toEmail);
                mailMsg.Subject = subject;
                mailMsg.IsBodyHtml = true;
                mailMsg.BodyEncoding = Encoding.UTF8;
                mailMsg.Body = body;
                mailMsg.Priority = MailPriority.Normal;

                if (!string.IsNullOrEmpty(ccEmail))
                {
                    string[] CCId = ccEmail.Split(',');
                    foreach (string CCEmail in CCId)
                    {
                        if (!string.IsNullOrEmpty(CCEmail))
                        {
                            MailAddress addressCC = new MailAddress(CCEmail);
                            mailMsg.CC.Add(addressCC);
                        }
                    }
                }


                //Smtp configuration
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(this.UserName, this.Password);
                smtpClient.Host = this.Host;
                smtpClient.Port = this.Port;
                smtpClient.EnableSsl = true;

                //Finally Send email
                smtpClient.Send(mailMsg);
                return true;
            }
            catch (SmtpException smtpEx)
            {
                throw smtpEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }//end function

        public bool SendMailWithStreamFileAttachment(string attachmentFileName, Stream mailStreamAttachment, string toEmail, string subject, string body, string fromEmail = null, string fromName = null, string ccEmail = null, string bccEmail = null)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage mailMsg = new MailMessage();


            try
            {


                if (String.IsNullOrEmpty(fromEmail) == true)
                {
                    fromEmail = this.fromEmail;
                }

                if (String.IsNullOrEmpty(fromName) == true)
                {
                    fromName = this.fromName;
                }


                //Attach file stream in email, if have any
                Attachment attachment = new System.Net.Mail.Attachment(mailStreamAttachment, attachmentFileName);
                mailMsg.Attachments.Add(attachment);


                mailMsg.From = new MailAddress(fromEmail, fromName);
                mailMsg.To.Add(toEmail);
                mailMsg.Subject = subject;
                mailMsg.IsBodyHtml = true;
                mailMsg.BodyEncoding = Encoding.UTF8;
                mailMsg.Body = body;
                mailMsg.Priority = MailPriority.Normal;

                if (string.IsNullOrEmpty(bccEmail) == false)
                {
                    MailAddress addressBCC = new MailAddress(bccEmail);
                    mailMsg.Bcc.Add(addressBCC);
                }

                if (string.IsNullOrEmpty(ccEmail) == false)
                {
                    MailAddress addressCC = new MailAddress(ccEmail);
                    mailMsg.CC.Add(addressCC);
                }


                //Smtp configuration
                smtpClient.Credentials = new NetworkCredential(this.UserName, this.Password);
                smtpClient.Host = this.Host;
                smtpClient.Port = this.Port;
                smtpClient.EnableSsl = true;

                //Finally Send email
                smtpClient.Send(mailMsg);
                return true;
            }
            catch (SmtpException smtpEx)
            {
                throw smtpEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }//end function



    }//end class

}
