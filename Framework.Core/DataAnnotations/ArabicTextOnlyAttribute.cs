// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArabicTextOnlyAttribute.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.DataAnnotations
{
    #region usings

    using System;
    using System.ComponentModel.DataAnnotations;

    using Framework.Core.Resources;

    using Microsoft.AspNetCore.Mvc.DataAnnotations.Internal;
    using Microsoft.Extensions.Localization;

    #endregion

    /// <summary>
    /// The arabic text only attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ArabicTextOnlyAttribute : RegularExpressionAttribute
    {
        /// <summary>
        /// The pattern.
        /// </summary>
        private new const string Pattern = @"^[\u0600-\u06FF\u003A\0-9s]{0,4000}$";

        /// <summary>
        /// Initializes a new instance of the <see cref="ArabicTextOnlyAttribute"/> class.
        /// </summary>
        public ArabicTextOnlyAttribute()
            : base(Pattern)
        {
        }

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
            return string.Format(CommonMessages.ArabicLettersOnlyErrorMessage, name);
        }
    }

    /// <summary>
    /// The arabic text only attribute adaptor.
    /// </summary>
    public class ArabicTextOnlyAttributeAdaptor : RegularExpressionAttributeAdapter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArabicTextOnlyAttributeAdaptor"/> class.
        /// </summary>
        /// <param name="attribute">
        /// The attribute.
        /// </param>
        /// <param name="stringLocalizer">
        /// The string localizer.
        /// </param>
        public ArabicTextOnlyAttributeAdaptor(RegularExpressionAttribute attribute, IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {
        }
    }
}