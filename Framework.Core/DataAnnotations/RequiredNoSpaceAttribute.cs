// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequiredNoSpaceAttribute.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.DataAnnotations
{
    #region usings

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    using Microsoft.AspNetCore.Mvc.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
    using Microsoft.Extensions.Localization;

    #endregion

    /// <summary>
    /// The required no space attribute.
    /// </summary>
    public class RequiredNoSpaceAttribute : ValidationAttribute
    {
        /// <summary>
        /// The format error message.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, this.ErrorMessageString, name);
        }

        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }

            if (value.GetType() != typeof(string))
            {
                throw new InvalidOperationException("can only be used on boolean properties.");
            }

            return (bool)value;
        }
    }

    /// <summary>
    /// The required no space attribute adapter.
    /// </summary>
    public class RequiredNoSpaceAttributeAdapter : AttributeAdapterBase<RequiredNoSpaceAttribute>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredNoSpaceAttributeAdapter"/> class.
        /// </summary>
        /// <param name="attribute">
        /// The attribute.
        /// </param>
        /// <param name="stringLocalizer">
        /// The string localizer.
        /// </param>
        public RequiredNoSpaceAttributeAdapter(RequiredNoSpaceAttribute attribute, IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {
        }

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
            MergeAttribute(context.Attributes, "data-val-required", this.GetErrorMessage(context));
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