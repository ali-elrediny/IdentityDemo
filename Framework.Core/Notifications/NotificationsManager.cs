// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationsManager.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Notifications
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Framework.Core.Data;
    using Framework.Core.Extensions;
    using Framework.Core.Notifications.Hubs;

    using Hangfire;

    #endregion

    /// <summary>
    ///     The notifications helper.
    /// </summary>
    public class NotificationsManager : INotificationsManager
    {
        /// <summary>
        /// The common uow.
        /// </summary>
      //  private readonly CommonsUnitOfWork CommonUow;

        /// <summary>
        /// The notification settings.
        /// </summary>
        private readonly NotificationSettings notificationSettings;

        /// <summary>
        /// The use hub.
        /// </summary>
        private readonly IUseHub useHub;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationsManager"/> class.
        /// </summary>
        /// <param name="useHub">
        /// The use hub.
        /// </param>
        /// <param name="CommonUow">
        /// The common uow.
        /// </param>
        //public NotificationsManager(IUseHub useHub, CommonsUnitOfWork commonUow)
        //{
        //    this.useHub = useHub;
        //    this.CommonUow = commonUow;
        //    this.notificationSettings = this.LoadNotificationsSettings();
        //}

        /// <summary>
        ///     The current language suffix.
        /// </summary>
        private NotificationLanguage CurrentLangSuffix =>
            Thread.CurrentThread.CurrentCulture.Name.Split('-')[0].ToPascalCase().To<NotificationLanguage>();

        /// <summary>
        /// The enqueue email.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="preferredLanguage">
        /// The preferred language.
        /// </param>
        public void EnqueueEmail(EmailMessage message, NotificationLanguage? preferredLanguage = null)
        {
            var notification = this.BuildNotification<EmailMessage>(
                message,
                NotificationTypes.Email,
                preferredLanguage);
            BackgroundJob.Enqueue<IEmailService>(s => s.SendEmail(notification, this.notificationSettings));
        }

        /// <summary>
        /// The enqueue mobile notification.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="preferredLanguage">
        /// The preferred language.
        /// </param>
        public void EnqueueMobileNotification(
            MobileNotification message,
            NotificationLanguage? preferredLanguage = null)
        {
            var obj = this.BuildNotification<MobileNotification>(
                message,
                NotificationTypes.WebNotification,
                preferredLanguage);
            BackgroundJob.Enqueue<IMobileNotificationService>(
                s => s.SendMobileNotification(obj, this.notificationSettings));
        }

        /// <summary>
        /// The send notification.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="preferredLanguage">
        /// The preferred language.
        /// </param>
        public void EnqueueSms(SmsMessage message, NotificationLanguage? preferredLanguage = null)
        {
            var notification = this.BuildNotification<SmsMessage>(message, NotificationTypes.Sms, preferredLanguage);
            BackgroundJob.Enqueue<ISmsService>(s => s.SendSms(notification, this.notificationSettings));
        }

        /// <summary>
        /// The enqueue web notification.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="redirectUrl">
        /// The redirect Url.
        /// </param>
        /// <param name="preferredLanguage">
        /// The preferred language.
        /// </param>
        public void EnqueueWebNotification(WebNotification message, string redirectUrl, NotificationLanguage? preferredLanguage = null)
        {
            // TODO:(Ahmed Gaduo)Add the other actions send to groups / send to group / send to users
            var messageAr = new WebNotification
                                {
                                    UserId = message.UserId,
                                    Body = message.Body,
                                    ApplicationId = message.ApplicationId,
                                    GroupName = message.GroupName,
                                    GroupsNames = message.GroupsNames,
                                    TemplateData = message.TemplateData,
                                    TemplateName = message.TemplateName,
                                    CreatedBy = message.CreatedBy,
                                    UsersIds = message.UsersIds
                                };
            var messageEn = new WebNotification
                                {
                                    UserId = message.UserId,
                                    Body = message.Body,
                                    ApplicationId = message.ApplicationId,
                                    GroupName = message.GroupName,
                                    GroupsNames = message.GroupsNames,
                                    TemplateData = message.TemplateData,
                                    TemplateName = message.TemplateName,
                                    CreatedBy = message.CreatedBy,
                                    UsersIds = message.UsersIds
                                };

            var notificationAr = this.BuildNotification<WebNotification>(
                messageAr,
                NotificationTypes.WebNotification,
                NotificationLanguage.Ar);
            var notificationEn = this.BuildNotification<WebNotification>(
                messageEn,
                NotificationTypes.WebNotification,
                NotificationLanguage.En);

            if (message.UserId != null)
            {
                // just one user
                this.useHub.SendMessageToUser(message.UserId, notificationAr.Body, notificationEn.Body, redirectUrl);
            }
            else if (message.GroupName != null)
            {
                // just one group/role
                this.useHub.SendMessageToGroup(message.GroupName, message.UsersIds, notificationAr.Body, notificationEn.Body, redirectUrl);
            }
            else if (message.GroupsNames != null && message.GroupsNames.Count > 1)
            {
                // multiple group/role
                this.useHub.SendMessageToGroups(message.GroupsNames, message.UsersIds, notificationAr.Body, notificationEn.Body, redirectUrl);
            }
            else
            {
                // here some users without groups or roles
                this.useHub.SendMessageToUsers(message.UsersIds.Select(a => a.ToString()).ToList(), notificationAr.Body, notificationEn.Body, redirectUrl);
            }
        }

        /// <summary>
        /// The build notification.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="notificationType">
        /// The notification type.
        /// </param>
        /// <param name="preferredLanguage">
        /// The preferred language.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        /// <exception cref="ArgumentException">
        /// </exception>
        /// <exception cref="NotificationException">
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        private T BuildNotification<T>(
            NotificationMessageBase message,
            NotificationTypes notificationType,
            NotificationLanguage? preferredLanguage = null)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (!(message is EmailMessage) && !(message is SmsMessage) && !(message is MobileNotification)
                && !(message is WebNotification))
            {
                throw new ArgumentException(
                    "message type must be of any: (EmailMessage, SmsMessage, FireBaseMessage, SignalRWebNotification)");
            }

            var messageContent = string.Empty;

            // the web notification has no template .. no need
            // if (notificationType != NotificationTypes.WebNotification)
            // {
            preferredLanguage = preferredLanguage ?? this.CurrentLangSuffix;
            var mainContainerTemplateName = $"Common{notificationType}Structure{preferredLanguage}";

            var templateName = message.TemplateName + preferredLanguage;
            message.TemplateData = message.TemplateData ?? new Dictionary<string, string>();

            var mainContainerTemplateContent = string.Empty;
            string templateContent;

            if (notificationType != NotificationTypes.WebNotification)
            {
                mainContainerTemplateContent = this.CommonUow.NotificationTemplates.GetTemplate(
                    mainContainerTemplateName,
                    NotificationTypes.Email);
            }

            templateContent = this.CommonUow.NotificationTemplates.GetTemplate(templateName, notificationType);

            if (string.IsNullOrEmpty(mainContainerTemplateContent)
                && (notificationType != NotificationTypes.WebNotification))
            {
                throw new NotificationException(
                    $"The template {mainContainerTemplateName} is not available, Check table common.NotificationTemplate");
            }

            if (string.IsNullOrEmpty(templateContent))
            {
                throw new NotificationException(
                    $"The template '{templateName}' is not available, Check table common.NotificationTemplate");
            }

            // replace values in design template
            templateContent = message.TemplateData.Keys.Aggregate(
                templateContent,
                (current, key) => current.Replace($"{"{" + key + "}"}", message.TemplateData[key]));

            // replace values in common template
            mainContainerTemplateContent = message.TemplateData.Keys.Aggregate(
                mainContainerTemplateContent,
                (current, key) => current.Replace($"{"{" + key + "}"}", message.TemplateData[key]));

            messageContent = (notificationType == NotificationTypes.WebNotification)
                                 ? templateContent
                                 : mainContainerTemplateContent.Replace("{Body}", templateContent);

            // }
            switch (notificationType)
            {
                case NotificationTypes.Email:
                    var email = (EmailMessage)message;

                    email.Body = messageContent;
                    email.Subject = email.Subject ?? this.notificationSettings.EmailSubject;
                    email.From = email.From ?? this.notificationSettings.EmailFromAddress;
                    return (T)Convert.ChangeType(email, typeof(T));

                // break;
                case NotificationTypes.Sms:
                    var sms = (SmsMessage)message;
                    return (T)Convert.ChangeType(sms, typeof(T));

                // break;
                case NotificationTypes.WebNotification:
                    var webNotification = (WebNotification)message;
                    webNotification.Body = messageContent;
                    return (T)Convert.ChangeType(webNotification, typeof(T));

                // break;
                case NotificationTypes.MobileNotification:
                    var mobileNotification = (MobileNotification)message;
                    return (T)Convert.ChangeType(mobileNotification, typeof(T));

                // break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(notificationType), notificationType, null);
            }
        }

        public NotificationSettings LoadNotificationsSettings()
        {
            return new NotificationSettings
                       {
                           EmailFromName = this.CommonUow.SystemSettings.GetValue<string>("EmailFromName"),
                           EmailFromAddress = this.CommonUow.SystemSettings.GetValue<string>("EmailFromAddress"),
                           GoogleFCMSenderId = this.CommonUow.SystemSettings.GetValue<string>("GoogleFCMSenderId"),
                           IsSmtpAuthenticated = this.CommonUow.SystemSettings.GetValue<bool>("IsSmtpAuthenticated"),
                           SenderId = this.CommonUow.SystemSettings.GetValue<string>("SenderId"),
                           ServerKey = this.CommonUow.SystemSettings.GetValue<string>("ServerKey"),
                           SmtpEnableSSL = this.CommonUow.SystemSettings.GetValue<bool>("SmtpEnableSSL"),
                           SmtpPassword = this.CommonUow.SystemSettings.GetValue<string>("SmtpPassword"),
                           SmtpPort = this.CommonUow.SystemSettings.GetValue<int>("SmtpPort"),
                           SmtpUserName = this.CommonUow.SystemSettings.GetValue<string>("SmtpUserName"),
                           SmtpServer = this.CommonUow.SystemSettings.GetValue<string>("SmtpServer"),
                           GoogleFCMServerKey = this.CommonUow.SystemSettings.GetValue<string>("GoogleFCMServerKey"),
                           EmailSubject = this.CommonUow.SystemSettings.GetValue<string>("EmailSubject")
                       };
        }
    }
}