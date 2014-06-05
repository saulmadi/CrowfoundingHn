using AcklenAvenue.Testing.Moq.ExpectedObjects;

using CrowfoundingHn.Common;
using CrowfoundingHn.Common.Authentication;
using CrowfoundingHn.Common.Authentication.Commands;
using CrowfoundingHn.Presentation.Api.Modules;
using CrowfoundingHn.Presentation.Api.Requests;

using FizzWare.NBuilder;

using Machine.Specifications;

using Moq;

using Nancy;
using Nancy.Testing;

using It = Machine.Specifications.It;

namespace CrowfoundingHn.Presentation.Specs.AuthSpecs
{
    public class when_creating_a_new_user
    {
        static ICommandDispatcher _commandDisptacher;

        static Browser _browser;

        static IUserRepository _userRepository;

        static UserRequest _userRequest;

        static CreateUser _excpectedCommand;

        static BrowserResponse _response;

        Establish context = () =>
            {
                _commandDisptacher = Mock.Of<ICommandDispatcher>();
                _userRepository = Mock.Of<IUserRepository>();
                _browser = new Browser(
                    x =>
                        {
                            x.Module<AuthModule>();
                            x.Dependency(_commandDisptacher);
                        });

                _userRequest = new UserRequest
                                      {
                                          Email = "test@test.com",
                                          Password = "Password",
                                          Name = "Test Name",
                                          Ocupation = "Ocupation",
                                          Address = "Addres",
                                          Phone = "504-1234444"
                                      };

                _excpectedCommand =
                    Builder<CreateUser>.CreateNew()
                                          .With(profile => profile.Name, _userRequest.Name)
                                          .With(profile => profile.Address, _userRequest.Address)
                                          .With(profile => profile.Email, _userRequest.Email)
                                          .With(profile => profile.Password, _userRequest.Password)
                                          .With(profile => profile.Ocupation, _userRequest.Ocupation)
                                          .With(profile => profile.Phone, _userRequest.Phone)
                                          .Build();
            };

        Because of = () => _response = _browser.PostSecureJson("/auth/create", _userRequest);

        It should_dispatch_create_user_command =
            () =>
            Mock.Get(_commandDisptacher)
                .Verify(dispatcher => dispatcher.Dispatch(WithExpected.Object(_excpectedCommand)));

        It should_return_200_status = () => _response.StatusCode.ShouldEqual(HttpStatusCode.OK);
    }
}