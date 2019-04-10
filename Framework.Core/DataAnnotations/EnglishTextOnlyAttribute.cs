// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnglishTextOnlyAttribute.cs" company="Usama Nada">
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
    ///     The english text only attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class EnglishTextOnlyAttribute : RegularExpressionAttribute
    {
        /// <summary>
        ///     The pattern.
        /// </summary>
        private new const string Pattern = @"^[A-Za-z0-9\s!@#$%^&*()_+=-`~\\\]\[{}|';:/.,?]*$";

        /// <summary>
        /// Initializes a new instance of the <see cref="EnglishTextOnlyAttribute"/> class.
        /// </summary>
        public EnglishTextOnlyAttribute()
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
            return string.Format(CommonMessages.EnglishLettersOnlyErrorMessage, name);
        }
    }

    /// <summary>
    /// The english text only attribute adaptor.
    /// </summary>
    public class EnglishTextOnlyAttributeAdaptor : RegularExpressionAttributeAdapter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnglishTextOnlyAttributeAdaptor"/> class.
        /// </summary>
        /// <param name="attribute">
        /// The attribute.
        /// </param>
        /// <param name="stringLocalizer">
        /// The string localizer.
        /// </param>
        public EnglishTextOnlyAttributeAdaptor(RegularExpressionAttribute attribute, IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {
        }
    }
}