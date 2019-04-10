// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MathExpression.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Utils
{
    #region usings

    using System;
    using System.Collections.Generic;

    using Framework.Core.Extensions;

    using NCalc;

    #endregion

    /// <summary>
    ///     The math expression.
    ///     based on NCalc https://github.com/sklose/NCalc2
    /// </summary>
    public static class MathExpression
    {
        /// <summary>
        /// The evaluate expression.
        /// </summary>
        /// <param name="expressionString">
        /// The expression string.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public static T EvaluateExpression<T>(string expressionString, Dictionary<string, object> parameters = null)
        {
            if (expressionString == null)
            {
                throw new ArgumentNullException(nameof(expressionString));
            }

            var expression = new Expression(expressionString);
            if (parameters != null)
            {
                expression.Parameters = parameters;
            }

            var results = expression.Evaluate();
            return results.To<T>();
        }
    }
}