using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Data
{
    public static class RepositoryFactory
    {
        public static TRepository GetRepositoryInstance<T, TRepository>(object callerRepository)
            where TRepository : IRepository<T> where T : class
        {
            if (callerRepository is RepositoryBase<T> baseRepo)
            {
                object[] args =
                    {
                        baseRepo.Context, baseRepo.NotificationService, baseRepo.LookupsService,
                        baseRepo.ApplicationSettingsService, baseRepo.UsersService, baseRepo.CachingService
                    };

                return (TRepository)Activator.CreateInstance(typeof(TRepository), args);
            }

            return (TRepository)Activator.CreateInstance(typeof(TRepository));
        }

        ////public TRepository GetInstance<TRepository>()
        ////    where TRepository : IRepository<T>
        ////{
        ////    return (TRepository)Activator.CreateInstance(
        ////        typeof(TRepository),
        ////        this.Context,
        ////        this.NotificationService,
        ////        this.LookupsService,
        ////        this.ApplicationSettingsService,
        ////        this.UsersService,
        ////        this.CachingService);
        ////}
    }
}
