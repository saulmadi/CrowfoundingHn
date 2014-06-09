using CrowfoundingHn.Common;
using CrowfoundingHn.Common.Authentication;
using CrowfoundingHn.Presentation.Api.Modules;

using Machine.Specifications;

using Moq;

using Nancy.Testing;

namespace CrowfoundingHn.Presentation.Specs.AuthSpecs
{
    public class given_a_auth_module_context
    {
        protected static ICommandDispatcher CommandDisptacher;

        protected static Browser Browser;

        protected static IUserRepository UserRepository;

        protected static IPasswordEncryptor PaswordEncryptor;

        Establish context = () =>
            {
                CommandDisptacher = Mock.Of<ICommandDispatcher>();
                UserRepository = Mock.Of<IUserRepository>();
                PaswordEncryptor = Mock.Of<IPasswordEncryptor>();

                Browser = new Browser(
                    x =>
                        {
                            x.Module<AuthModule>();
                            x.Dependency(CommandDisptacher);
                            x.Dependency(UserRepository);
                            x.Dependency(PaswordEncryptor);
                        });
            };
    }
}