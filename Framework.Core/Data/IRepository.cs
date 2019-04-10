// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Data
{
    #region usings

    #region

    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    #endregion

    #endregion

    /// <summary>
    /// http://codereview.stackexchange.com/questions/19037/entity-framework-generic-repository-pattern
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IRepository<T>
        where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        //Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        //Task<int> CountAsync(ISpecification<T> spec);
    }



}