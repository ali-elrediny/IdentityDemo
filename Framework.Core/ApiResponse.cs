// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiResponse.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core
{
    #region usings

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The api response.
    /// </summary>
    public class ApiResponse
    {
        // Yousra: this property to indicate that the returned message 
        // is waiting for user confirmation or just an alert information
        /// <summary>
        /// Gets or sets a value indicating whether confirm.
        /// </summary>
        public bool Confirm { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the model state errors.
        /// </summary>
        public ICollection<Item> ModelStateErrors { get; set; } = new List<Item>();

        /// <summary>
        /// Gets or sets a value indicating whether success.
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }
    }

    public class ApiResponse<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether confirm.
        /// </summary>
        public bool Confirm { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the model state errors.
        /// </summary>
        public ICollection<Item> ModelStateErrors { get; set; } = new List<Item>();

        /// <summary>
        /// Gets or sets a value indicating whether success.
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public T Value { get; set; }
    }

}