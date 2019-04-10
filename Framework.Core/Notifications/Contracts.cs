// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contracts.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Notifications
{
    #region usings

    using System.Threading.Tasks;

    #endregion

    /// <summary>
    /// The NotificationsManager interface.
    /// </summary>
    public interface INotificationsManager
    {
        /// <summary>
        /// The enqueue email.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="preferredLanguage">
        /// The preferred language.
        /// </param>
        void EnqueueEmail(EmailMessage message, NotificationLanguage? preferredLanguage = null);

        /// <summary>
        /// The enqueue mobile notification.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="preferredLanguage">
        /// The preferred language.
        /// </param>
        void EnqueueMobileNotification(MobileNotification message, NotificationLanguage? preferredLanguage = null);

        /// <summary>
        /// The enqueue sms.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="preferredLanguage">
        /// The preferred language.
        /// </param>
        void EnqueueSms(SmsMessage message, NotificationLanguage? preferredLanguage = null);

        /// <summary>
        /// The enqueue web notification.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="preferredLanguage">
        /// The preferred language.
        /// </param>
        void EnqueueWebNotification(WebNotification message, string redirectUrl, NotificationLanguage? preferredLanguage = null);
    }

    /// <summary>
    /// The NotificationService interface.
    /// </summary>
    public interface INotificationService
    {
    }

    /// <summary>
    ///     The EmailService interface.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// The send email.
        /// </summary>
        /// <param name="emailMessage">
        /// The email message.
        /// </param>
        /// <param name="notificationSettings">
        /// The notification Settings.
        /// </param>
        void SendEmail(EmailMessage emailMessage, NotificationSettings notificationSettings);
    }

    /// <summary>
    ///     The MobileNotificationService interface.
    /// </summary>
    public interface IMobileNotificationService
    {
        /// <summary>
        /// The send mobile notification.
        /// </summary>
        /// <param name="mobileNotification">
        /// The email message.
        /// </param>
        /// <param name="notificationSettings">
        /// The notification Settings.
        /// </param>
        void SendMobileNotification(MobileNotification mobileNotification, NotificationSettings notificationSettings);
    }

    /// <summary>
    ///     The SmsService interface.
    /// </summary>
    public interface ISmsService
    {
        /// <summary>
        /// The send sms.
        /// </summary>
        /// <param name="smsMessage">
        /// The email message.
        /// </param>
        /// <param name="notificationSettings">
        /// The notification Settings.
        /// </param>
        void SendSms(SmsMessage smsMessage, NotificationSettings notificationSettings);
    }

    /// <summary>
    ///     The WebNotificationService interface.
    /// </summary>
    public interface IWebNotificationService
    {
        /// <summary>
        /// The send web notification.
        /// </summary>
        /// <param name="webNotification">
        /// The mobile notification message.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task SendWebNotification(WebNotification webNotification);
    }
}