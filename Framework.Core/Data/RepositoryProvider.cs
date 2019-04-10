using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Data
{
   public static class RepositoryProvider
    {
        public static TRepository GetRepositoryInstance<T, TRepository>()
          where TRepository : IRepository<T> where T : class
        {
                       return (TRepository)Activator.CreateInstance(typeof(TRepository));
        }

    }
}
