using System;

using CrowfoundingHn.Common;
using CrowfoundingHn.Presentation.Api.Requests;

using Machine.Specifications;

using Moq;

using Nancy.Testing;

using It = Machine.Specifications.It;

namespace CrowfoundingHn.Presentation.Specs.AuthSpecs
{
    public class when_creating_a_new_user
    {
        Establish context = () =>
            {
                _commandDisptacher = Mock.Of<ICommandDispatcher>();
                _browser = new Browser(x =>
                    {
                        x.Dependency(_commandDisptacher);
                        x.Dependency(_userRepository);
                    });
            };

        Because of = () => _browser.PostSecureJson("/auth/create", new ProfileRequest());

        It should_dispatch_create_user_command = () => { };

        static ICommandDispatcher  _commandDisptacher;

        static Browser _browser;

        static IUserRepositiory _userRepository;
    }

    public interface IUserRepositiory 
    {
    }
}