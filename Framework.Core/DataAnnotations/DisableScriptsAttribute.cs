// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisableScriptsAttribute.cs" company="Usama Nada">
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
    ///     The disable scripts attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DisableScriptsAttribute : RegularExpressionAttribute
    {
        /// <summary>
        ///     The pattern.
        /// </summary>
        private new const string Pattern = @"^[^<>{}]+$";

        /// <summary>
        ///     Initializes a new instance of the <see cref="DisableScriptsAttribute" /> class.
        /// </summary>
        public DisableScriptsAttribute()
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
            return string.Format(CommonMessages.ScriptsNotAllowedErrorMessage, name);
        }
    }

    /// <summary>
    /// The disable scripts attribute adaptor.
    /// </summary>
    public class DisableScriptsAttributeAdaptor : RegularExpressionAttributeAdapter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisableScriptsAttributeAdaptor"/> class.
        /// </summary>
        /// <param name="attribute">
        /// The attribute.
        /// </param>
        /// <param name="stringLocalizer">
        /// The string localizer.
        /// </param>
        public DisableScriptsAttributeAdaptor(RegularExpressionAttribute attribute, IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {
        }
    }
}