// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidateFileUploadAttribute.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.DataAnnotations
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;
    using System.Linq;
    using System.Resources;
    using System.Text.RegularExpressions;

    using Framework.Core.Data;
    using Framework.Core.Resources;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
    using Microsoft.CodeAnalysis;
    using Microsoft.Extensions.Localization;

    #endregion

    /// <summary>
    ///     The validate file.
    /// </summary>
    public class ValidateFileUploadAttribute : ValidationAttribute
    {
        /// <summary>
        ///     The file image dimensions error message.
        /// </summary>
        internal readonly string fileImageDimensionsErrorMessage;

        /// <summary>
        ///     The file not valid image error message.
        /// </summary>
        internal readonly string fileNotValidImageErrorMessage;

        /// <summary>
        ///     The file size error message.
        /// </summary>
        internal readonly string fileSizeErrorMessage;

        /// <summary>
        ///     The file type error message.
        /// </summary>
        internal readonly string fileTypeErrorMessage;

        /// <summary>
        /// The file zero length error message.
        /// </summary>
        internal readonly string fileZeroLengthErrorMessage;

        /// <summary>
        /// The no of files error message.
        /// </summary>
        internal readonly string noOfFilesErrorMessage;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidateFileUploadAttribute" /> class.
        /// </summary>
        public ValidateFileUploadAttribute()
        {
            var resourceManager = new ResourceManager(this.ErrorMessageResourceType ?? typeof(CommonMessages));
            this.fileTypeErrorMessage = resourceManager.GetString(this.FileTypeErrorMessageResourceName);
            this.fileSizeErrorMessage = resourceManager.GetString(this.FileSizeErrorMessageResourceName);
            this.noOfFilesErrorMessage = resourceManager.GetString(this.NoOfFilesErrorMessageResourceName);

            this.fileImageDimensionsErrorMessage =
                resourceManager.GetString(this.FileImageDimensionsErrorMessageResourceName);
            this.fileNotValidImageErrorMessage =
                resourceManager.GetString(this.FileNotValidImageErrorMessageResourceName);

            // -- Yousra: Added default message error name, to fix the exception was occuring to 
            // when upload image attachment in the second time of creation, tested and doesn't effect other functionalities
            //this.ErrorMessageResourceName = "FileInValidErrorMessage";
            //this.ErrorMessageResourceType = typeof(CommonMessages);
            //this.ErrorMessage = null;

            // -----------------------------------------------------------
            this.fileZeroLengthErrorMessage = resourceManager.GetString(this.FileZeroLengthMessageResourceName);
            this.MaxAllowedNumberOfFiles = 1;
            
            using (var uow = new CommonsUnitOfWork())
            {
                this.MaxAllowedNumberOfFiles = 1;
                if (this.AttachmentTypeId != 0 && uow.AttachmentTypes.GetById(this.AttachmentTypeId) != null)
                {
                    var attType = uow.AttachmentTypes.GetById(this.AttachmentTypeId);
                    this.AllowedExtensions = attType.AllowedFilesExtension;
                    this.ImageMaxHeight = attType.ImageMaxHeight ?? 0;
                    this.ImageMaxWidth = attType.ImageMaxWidth ?? 0;
                    this.MaxSizeInMegabytes = attType.MaxSizeInMegabytes;
                }
                else
                {
                    this.AllowedExtensions = uow.SystemSettings.GetValue<string>("AttachmentsAllowedTypes");
                    this.ImageMaxHeight = uow.SystemSettings.GetValue<int>("ImageMaxHeight");
                    this.ImageMaxWidth = uow.SystemSettings.GetValue<int>("ImageMaxWidth");
                    this.MaxSizeInMegabytes = uow.SystemSettings.GetValue<int>("AttachmentsMaxSize");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the allowed extensions.
        /// </summary>
        public string AllowedExtensions { get; set; }

        /// <summary>
        ///     Gets the allowed extensions regex.
        /// </summary>
        public string AllowedExtensionsRegex
        {
            get
            {
                if (string.IsNullOrEmpty(this.AllowedExtensions))
                {
                    return null;
                }

                var allowedTypesArr = this.AllowedExtensions.Split(
                    new[] { ";", "|", ":", "," },
                    StringSplitOptions.RemoveEmptyEntries);

                var extensions = allowedTypesArr.Select(
                    type => type.Aggregate(
                        string.Empty,
                        (current, c) => current + $"[{c.ToString().ToLower()}{c.ToString().ToUpper()}]"));
                var allowedExtensionsRegex = @"(.*?)\.(" + string.Join("|", extensions) + ")$";
                return allowedExtensionsRegex;
            }
        }

        /// <summary>
        ///     Gets or sets the attachment type id.
        /// </summary>
        public int AttachmentTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the file image dimensions error message resource name.
        /// </summary>
        public string FileImageDimensionsErrorMessageResourceName { get; set; } = "FileImageDimensionsErrorMessage";

        /// <summary>
        ///     Gets or sets the file not valid image error message resource name.
        /// </summary>
        public string FileNotValidImageErrorMessageResourceName { get; set; } = "FileNotValidImageErrorMessage";

        /// <summary>
        ///     Gets or sets the file size error message resource name.
        /// </summary>
        public string FileSizeErrorMessageResourceName { get; set; } = "FileSizeErrorMessage";

        /// <summary>
        ///     Gets or sets the file type error message resource name.
        /// </summary>
        public string FileTypeErrorMessageResourceName { get; set; } = "FileTypeErrorMessage";

        /// <summary>
        /// Gets or sets the file zero length message resource name.
        /// </summary>
        public string FileZeroLengthMessageResourceName { get; set; } = "FileZeroLengthErrorMessage";

        /// <summary>
        ///     Gets or sets the image max height.
        /// </summary>
        public int ImageMaxHeight { get; set; }

        /// <summary>
        ///     Gets or sets the image max width.
        /// </summary>
        public int ImageMaxWidth { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is image.
        /// </summary>
        public bool IsImage { get; set; }

        /// <summary>
        /// Gets or sets the max allowed number of files.
        /// </summary>
        public int MaxAllowedNumberOfFiles { get; set; }

        /// <summary>
        ///     Gets or sets the max size in megabytes.
        /// </summary>
        public int MaxSizeInMegabytes { get; set; }

        /// <summary>
        /// Gets or sets the no of files error message resource name.
        /// </summary>
        public string NoOfFilesErrorMessageResourceName { get; set; } = "NoOfFilesErrorMessage";

        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="validationContext">
        /// The validation context.
        /// </param>
        /// <returns>
        /// The <see cref="ValidationResult"/>.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var errorMessages = new List<string>();
            var isValid = true;

            if (this.MaxAllowedNumberOfFiles == 1 && value is List<IFormFile> && (value as List<IFormFile>).Count > 1)
            {
                errorMessages.Add(string.Format(this.noOfFilesErrorMessage, this.MaxAllowedNumberOfFiles));
                this.ErrorMessage = string.Join("\r\n", errorMessages);
                return new ValidationResult(this.ErrorMessage);
            }

            var file = value as IFormFile;

            if (file == null)
            {
                return ValidationResult.Success;
            }

            if (!string.IsNullOrEmpty(this.AllowedExtensions))
            {
                var regex = new Regex(this.AllowedExtensionsRegex);
                var match = regex.Match(file.FileName);
                if (!match.Success)
                {
                    errorMessages.Add(string.Format(this.fileTypeErrorMessage, this.AllowedExtensions));
                    isValid = false;
                }
            }

            // if(this.size)
            if (file.Length == 0)
            {
                errorMessages.Add(this.fileSizeErrorMessage);
                isValid = false;
            }

            if (this.MaxSizeInMegabytes > 0)
            {
                if (file.Length > this.MaxSizeInMegabytes * 1024 * 1024)
                {
                    errorMessages.Add(string.Format(this.fileSizeErrorMessage, this.MaxSizeInMegabytes));
                    isValid = false;
                }
            }

            if (this.IsImage)
            {
                try
                {
                    var image = Image.FromStream(file.OpenReadStream());
                    image.Dispose();

                    // bellow two lines are required to make file stream return from beginning
                    // so that MVC binding read file correctly
                    // If the below 2 lines removed the file will be read incorrectly and will be corrupted
                    file.OpenReadStream().Position = 0;

                    // file.OpenReadStream().Flush();
                    if (this.ImageMaxHeight > 0 && image.Height > this.ImageMaxHeight
                        || this.ImageMaxWidth > 0 && image.Width > this.ImageMaxWidth)
                    {
                        errorMessages.Add(
                            string.Format(
                                this.fileImageDimensionsErrorMessage,
                                this.ImageMaxHeight,
                                this.ImageMaxWidth));

                        isValid = false;
                    }
                }
                catch (Exception ex)
                {
                    isValid = false;
                    errorMessages.Add(this.fileNotValidImageErrorMessage);
                }
            }

            if (!isValid)
            {
                this.ErrorMessage = string.Join("\r\n", errorMessages);
                return new ValidationResult(this.ErrorMessage);
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }

    /// <summary>
    ///     The validate file upload attribute adapter.
    /// </summary>
    public class ValidateFileUploadAttributeAdapter : AttributeAdapterBase<ValidateFileUploadAttribute>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateFileUploadAttributeAdapter"/> class.
        /// </summary>
        /// <param name="attribute">
        /// The attribute.
        /// </param>
        /// <param name="stringLocalizer">
        /// The string localizer.
        /// </param>
        public ValidateFileUploadAttributeAdapter(
            ValidateFileUploadAttribute attribute,
            IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {
            this.CurrentAttribute = attribute;
        }

        /// <summary>
        ///     Gets or sets the current attribute.
        /// </summary>
        public ValidateFileUploadAttribute CurrentAttribute { get; set; }

        /// <summary>
        /// The add validation.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-checkisvalidfile", this.GetErrorMessage(context));
            MergeAttribute(
                context.Attributes,
                "data-val-checkisvalidfile-maxallowednumberoffiles",
                this.CurrentAttribute.MaxAllowedNumberOfFiles.ToString());
            MergeAttribute(
                context.Attributes,
                "data-val-checkisvalidfile-allowedextensions",
                this.CurrentAttribute.AllowedExtensions);
            MergeAttribute(
                context.Attributes,
                "data-val-checkisvalidfile-isimage",
                this.CurrentAttribute.IsImage.ToString());
            MergeAttribute(
                context.Attributes,
                "data-val-checkisvalidfile-maxsizeinmegabytes",
                this.CurrentAttribute.MaxSizeInMegabytes.ToString());
            MergeAttribute(
                context.Attributes,
                "data-val-checkisvalidfile-allowedextensionsregex",
                this.CurrentAttribute.AllowedExtensionsRegex);
            MergeAttribute(
                context.Attributes,
                "data-val-checkisvalidfile-fileimagedimensionserrormessage",
                this.CurrentAttribute.fileImageDimensionsErrorMessage);
            MergeAttribute(
                context.Attributes,
                "data-val-checkisvalidfile-filenotvalidimageerrormessage",
                this.CurrentAttribute.fileNotValidImageErrorMessage);
            MergeAttribute(
                context.Attributes,
                "data-val-checkisvalidfile-filesizeerrormessage",
                this.CurrentAttribute.fileSizeErrorMessage);
            MergeAttribute(
                context.Attributes,
                "data-val-checkisvalidfile-filetypeerrormessage",
                this.CurrentAttribute.fileTypeErrorMessage);
            MergeAttribute(
                context.Attributes,
                "data-val-checkisvalidfile-filezerolengtherrormessage",
                this.CurrentAttribute.fileZeroLengthErrorMessage);
            MergeAttribute(
                context.Attributes,
                "data-val-checkisvalidfile-noOfFilesErrorMessage",
                this.CurrentAttribute.noOfFilesErrorMessage);
        }

        /// <summary>
        /// The get error message.
        /// </summary>
        /// <param name="validationContext">
        /// The validation context.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException(nameof(validationContext));
            }

            return this.GetErrorMessage(
                validationContext.ModelMetadata,
                validationContext.ModelMetadata.GetDisplayName());
        }
    }
}