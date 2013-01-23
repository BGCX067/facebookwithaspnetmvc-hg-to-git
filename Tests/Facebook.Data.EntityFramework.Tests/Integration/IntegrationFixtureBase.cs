using System;
using Facebook.Business.Domain.Facade.Internals;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using Facebook.Infrastructure.Ioc;
using NUnit.Framework;

namespace Facebook.Data.EntityFramework.Tests.Integration
{
    
    class IntegrationFixtureBase 
    {
        static IntegrationFixtureBase()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<FacebookContext>());
            Container.Instance.RegisterType<IKeyGenerationService, KeyGenerationService>();
            Container.Instance.RegisterType<IUnitOfWork, UnitOfWork>();
        }
    }
}
