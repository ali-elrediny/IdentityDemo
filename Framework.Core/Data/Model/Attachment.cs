// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Attachment.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Data.Model
{
    #region usings

    using System;

    #endregion

    /// <summary>
    /// The Attachment interface.
    /// </summary>
    public interface IAttachment
    {
        /// <summary>
        /// Gets or sets the attachment type id.
        /// </summary>
        int AttachmentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the description ar.
        /// </summary>
        string DescriptionAr { get; set; }

        /// <summary>
        /// Gets or sets the description en.
        /// </summary>
        string DescriptionEn { get; set; }

        /// <summary>
        /// Gets or sets the extention.
        /// </summary>
        string Extention { get; set; }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        Guid Id { get; set; }
        
        /// <summary>
        /// Gets or sets the thumbnail.
        /// </summary>
        byte[] Thumbnail { get; set; }

        /// <summary>
        /// Gets or sets the title ar.
        /// </summary>
        string TitleAr { get; set; }

        /// <summary>
        /// Gets or sets the title en.
        /// </summary>
        string TitleEn { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        DateTime? UpdatedOn { get; set; }
    }
}