// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidatePhoneNumberAttribute.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.DataAnnotations
{
    #region usings

    using System;
    using System.ComponentModel.DataAnnotations;

    using Framework.Core.Utils;

    using Microsoft.AspNetCore.Mvc.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
    using Microsoft.Extensions.Localization;

    #endregion

    /// <summary>
    ///     The phone number attribute.
    /// </summary>
    public class ValidatePhoneNumberAttribute : ValidationAttribute
    {
        /// <summary>
        ///     The default error message.
        /// </summary>
        /// <summary>
        ///     Gets or sets the country code.
        /// </summary>
        public string CountryCode { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the number type.
        /// </summary>
        public NumberType NumberType { get; set; } = NumberType.MOBILE;

        // public override bool
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
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var numberType = this.NumberType; // .ToString().ToEnum<Utils.NumberType>();

            var isValid = PhoneNumbers.IsValidNumber(value as string, numberType, this.CountryCode);

            if (isValid)
            {
                validationContext.ObjectType.GetProperty(validationContext.MemberName).SetValue(
                    validationContext.ObjectInstance,
                    PhoneNumbers.FormatPhoneNumber(value.ToString(), this.CountryCode),
                    null);
                return ValidationResult.Success;
            }

            return new ValidationResult(this.ErrorMessage);
        }
    }

    /// <summary>
    ///     The validate phone number attribute adapter.
    /// </summary>
    public class ValidatePhoneNumberAttributeAdapter : AttributeAdapterBase<ValidatePhoneNumberAttribute>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatePhoneNumberAttributeAdapter"/> class.
        /// </summary>
        /// <param name="attribute">
        /// The attribute.
        /// </param>
        /// <param name="stringLocalizer">
        /// The string localizer.
        /// </param>
        public ValidatePhoneNumberAttributeAdapter(
            ValidatePhoneNumberAttribute attribute,
            IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {
            this.CurrentAttribute = attribute;
        }

        /// <summary>
        ///     Gets or sets the current attribute.
        /// </summary>
        public ValidatePhoneNumberAttribute CurrentAttribute { get; set; }

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
            MergeAttribute(context.Attributes, "data-val-checkisvalidnumber", this.GetErrorMessage(context));
            MergeAttribute(
                context.Attributes,
                "data-val-checkisvalidnumber-countrycode",
                this.CurrentAttribute.CountryCode);
            MergeAttribute(
                context.Attributes,
                "data-val-checkisvalidnumber-numbertype",
                this.CurrentAttribute.NumberType.ToString());
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