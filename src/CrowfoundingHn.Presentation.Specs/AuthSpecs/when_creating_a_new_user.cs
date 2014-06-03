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

        static IUserRepositiory _userRepository;

        static ProfileRequest _profileRequest;

        static CreateProfile _excpectedCommand;

        static BrowserResponse _response;

        Establish context = () =>
            {
                _commandDisptacher = Mock.Of<ICommandDispatcher>();
                _userRepository = Mock.Of<IUserRepositiory>();
                _browser = new Browser(
                    x =>
                        {
                            x.Module<AuthModule>();
                            x.Dependency(_commandDisptacher);
                        });

                _profileRequest = new ProfileRequest
                                      {
                                          Email = "test@test.com",
                                          Password = "Password",
                                          Name = "Test Name",
                                          Ocuapation = "Ocupation",
                                          Address = "Addres",
                                          Phone = "504-1234444"
                                      };

                _excpectedCommand =
                    Builder<CreateProfile>.CreateNew()
                                          .With(profile => profile.Name, _profileRequest.Name)
                                          .With(profile => profile.Address, _profileRequest.Address)
                                          .With(profile => profile.Email, _profileRequest.Email)
                                          .With(profile => profile.Password, _profileRequest.Password)
                                          .With(profile => profile.Ocuapation, _profileRequest.Ocuapation)
                                          .With(profile => profile.Phone, _profileRequest.Phone)
                                          .Build();
            };

        Because of = () => _response = _browser.PostSecureJson("/auth/create", _profileRequest);

        It should_return_200_status = () => _response.StatusCode.ShouldEqual(HttpStatusCode.OK);
        It should_dispatch_create_user_command =
            () =>
            Mock.Get(_commandDisptacher)
                .Verify(dispatcher => dispatcher.Dispatch(WithExpected.Object(_excpectedCommand)));
    }
}