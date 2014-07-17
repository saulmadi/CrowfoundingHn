using System;
using System.Configuration;

using Autofac;

using CrowfoundingHn.Common.Authentication;
using CrowfoundingHn.Common.Data.Authentication;

namespace CrowfoundingHn.Common.Bootstrapper.Authentication
{
    public class ConfigureAuthenticationDependencies : IBootstrapperTask<ContainerBuilder>
    {
        public Action<ContainerBuilder> Task
        {
            get
            {
                return builder =>
                    {
                        builder.RegisterType<PasswordEncryptor>().As<IPasswordEncryptor>();

                        builder.Register(
                            context =>
                                {
                                    var durationDays = Convert.ToInt32(ConfigurationManager.AppSettings["SessionDurationDays"]);
                                    return new SessionExpirationDateFactory(durationDays);
                                }).As<ISessionExpirationDateFactory>();

                        builder.Register(
                            context =>
                                {
                                    var mongocollectionFactory =
                                        context.Resolve<IMongoCollectionFactory>(new NamedParameter("key", "UserDb"));
                                    return new UserRepository(mongocollectionFactory.CreateCollection("Users"));
                                }).As<IUserRepository>();

                        builder.Register(
                            context =>
                                {
                                    var mongocollectionFactory =
                                        context.Resolve<IMongoCollectionFactory>(new NamedParameter("key", "UserDb"));
                                    return
                                        new UserSessionRepository(
                                            mongocollectionFactory.CreateCollection("UserSessions"));
                                }).As<IUserSessionRepository>();
                    };
            }
        }
    }
}