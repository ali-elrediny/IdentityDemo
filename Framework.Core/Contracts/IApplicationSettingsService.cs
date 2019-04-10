// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApplicationSettingsService.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Contracts
{
    #region usings

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The ApplicationSettingsService interface.
    /// </summary>
    public interface IApplicationSettingsService
    {
        /// <summary>
        /// Gets the application url.
        /// </summary>
        string ApplicationUrl { get; }

        /// <summary>
        /// Gets the attachments allowed height.
        /// </summary>
        int AttachmentsAllowedHeight { get; }

        /// <summary>
        /// Gets the attachments allowed types.
        /// </summary>
        string AttachmentsAllowedTypes { get; }

        /// <summary>
        /// Gets the attachments allowed width.
        /// </summary>
        int AttachmentsAllowedWidth { get; }

        /// <summary>
        /// Gets the attachments max size.
        /// </summary>
        int AttachmentsMaxSize { get; }

        string ActiveDirectoryDomainName { get; }

        /// <summary>
        /// Gets the attachments path.
        /// </summary>
        string AttachmentsPath { get; }

        /// <summary>
        /// Gets the cache item policy duration in hours.
        /// </summary>
        int CacheItemPolicyDurationInHours { get; }

        /// <summary>
        /// Gets the certificate authentication url.
        /// </summary>
        string CertificateAuthenticationUrl { get; }

        /// <summary>
        /// Gets the competencies api url.
        /// </summary>
        string CompetenciesAppUrl { get; }

        /// <summary>
        /// Gets the contact us email.
        /// </summary>
        string ContactUsEmail { get; }

        /// <summary>
        /// Gets the date format.
        /// </summary>
        string DateFormat { get; }

        /// <summary>
        /// Gets the date time format.
        /// </summary>
        string DateTimeFormat { get; }

        /// <summary>
        /// Gets the default pager page size.
        /// </summary>
        int DefaultPagerPageSize { get; }

        /// <summary>
        /// Gets the download file url.
        /// </summary>
        string DownloadFileUrl { get; }

        /// <summary>
        /// Gets the email subject.
        /// </summary>
        string EmailSubject { get; }

        /// <summary>
        /// Gets or sets the email subject ar.
        /// </summary>
        string EmailSubjectAr { get; set; }

        /// <summary>
        /// Gets or sets the email subject en.
        /// </summary>
        string EmailSubjectEn { get; set; }

        /// <summary>
        /// Gets the eservices draft statuses.
        /// </summary>
        List<int> EservicesDraftStatuses { get; }

        /// <summary>
        /// Gets the events api url.
        /// </summary>
        string EventsAppUrl { get; }

        /// <summary>
        /// Gets the exams api url.
        /// </summary>
        string ExamsAppUrl { get; }

        /// <summary>
        /// Gets the export no of items.
        /// </summary>
        int ExportNoOfItems { get; }

        /// <summary>
        /// Gets the portal contact us url.
        /// </summary>
        string PortalContactUsURL { get; }

        /// <summary>
        /// Gets the portal lists count per page.
        /// </summary>
        int PortalListsCountPerPage { get; }

        /// <summary>
        /// Gets the portal linked in url.
        /// </summary>
        string PortalLinkedInURL { get; }

        /// <summary>
        /// Gets the portal twitter url.
        /// </summary>
        string PortalTwitterURL { get; }

        /// <summary>
        /// Gets the portal url.
        /// </summary>
        string PortalURL { get; }

        /// <summary>
        /// Gets the portal you tube url.
        /// </summary>
        string PortalYouTubeURL { get; }

        /// <summary>
        /// Gets the rooms api url.
        /// </summary>
        string RoomsAppUrl { get; }

        /// <summary>
        /// Gets User Management URL.
        /// </summary>
        string UserManagementUrl { get; }

        string CdnUrl { get; }

        string AdminAppUrl
        {
            get;
        }

        /// <summary>
        /// Gets App Frontend URL.
        /// </summary>
        string FrontendAppUrl { get; }

        string K2WebApiUrl { get; }

        /// <summary>
        /// Gets a value indicating whether save files to database.
        /// </summary>
        bool SaveFilesToDatabase { get; }

        /// <summary>
        /// Gets the search results portal url.
        /// </summary>
        string SearchResultsPortalURL { get; }

        /// <summary>
        /// Gets the portal en part url.
        /// </summary>
        string PortalEnPartURL { get; }

        /// <summary>
        /// Gets the portal register url.
        /// </summary>
        string PortalRegisterURL { get; }

        /// <summary>
        /// Gets the portal login url.
        /// </summary>
        string PortalLoginURL { get; }

        /// <summary>
        /// Gets the portal eservices url.
        /// </summary>
        string PortalEservicesURL { get; }

        /// <summary>
        /// Gets or sets a value indicating whether simulate web services.
        /// </summary>
        bool SimulateWebServices { get; set; }

        /// <summary>
        /// Gets the time format.
        /// </summary>
        string TimeFormat { get; }

        /// <summary>
        /// Gets the verification code max attempts.
        /// </summary>
        int VerificationCodeMaxAttempts { get; }
        
        /// <summary>
        /// The reload settings.
        /// </summary>
        void ReloadSettings();

        #region Payment

        /// <summary>
        /// Get VAT
        /// </summary>
        decimal Vat { get;  set; }

        decimal MinPaidPrice { get; set; }
        
         string PaymentURL { get; set; }

         string PaymentAuthKey { get; set; }

         string PaymentCurrency { get; set; }

        string PaymentStore { get; set; }

        string PaymentAuthCallbackUrl { get; set; }

        string PaymentSimulation { get; set; }
        
        int PaymentCurrencyId { get; set; }
        
        #endregion

    }
}