// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUsersService.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Contracts
{
    #region usings

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The UsersService interface.
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Gets the current user id.
        /// </summary>
        Guid? CurrentUserId { get; }

        /// <summary>
        /// Gets the current user name.
        /// </summary>
        string CurrentUserName { get; }

        string CurrentUserFirstName { get; }

        /// <summary>
        /// The get users i ds in role.
        /// </summary>
        /// <param name="roleName">
        /// The role name.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        List<Guid> GetUsersIDsInRole(string roleName);     

        /// <summary>
        /// The get users in role.
        /// </summary>
        /// <param name="roleName">
        /// The role name.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        List<Guid> GetUsersInRole(string roleName);

        bool IsInRole(string role);


       Guid  GetRoleIdByCode(int code);


    }
}