// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmtpEmailService.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Notifications
{
    #region usings

    using System.Net;
    using System.Net.Mail;

    #endregion

    /// <summary>
    ///     The smtp email service.
    /// </summary>
    public class SmtpEmailService : IEmailService
    {
        /// <summary>
        /// The send email.
        /// </summary>
        /// <param name="emailMessage">
        /// The email message.
        /// </param>
        /// <param name="notificationSettings">
        /// todo: describe notificationSettings parameter on SendEmail
        /// </param>
        public void SendEmail(EmailMessage emailMessage, NotificationSettings notificationSettings)
        {
            return;
            using (var smtpClient = new SmtpClient
                                        {
                                            Host = notificationSettings.SmtpServer,
                                            UseDefaultCredentials = false,
                                            Port = notificationSettings.SmtpPort,
                                            EnableSsl = notificationSettings.SmtpEnableSSL,
                                            DeliveryMethod = SmtpDeliveryMethod.Network,
                                            Credentials = new NetworkCredential(
                                                notificationSettings.SmtpUserName,
                                                notificationSettings.SmtpPassword)
                                        })
            {
                var mail = emailMessage.ToMailMessage();
                
                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                //smtpClient.Send(mail);
            }
        }
    }
}