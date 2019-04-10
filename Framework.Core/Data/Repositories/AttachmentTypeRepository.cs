// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachmentTypeRepository.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Data.Repositories
{
    #region usings

    using Framework.Core.Data.Model;

    #region

    using Microsoft.EntityFrameworkCore;

    #endregion

    #endregion

    /// <summary>
    ///     The attachment type repository.
    /// </summary>
    internal class AttachmentTypeRepository : RepositoryBase<AttachmentType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentTypeRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public AttachmentTypeRepository(DbContext context)
            : base(context)
        {
        }
    }
}