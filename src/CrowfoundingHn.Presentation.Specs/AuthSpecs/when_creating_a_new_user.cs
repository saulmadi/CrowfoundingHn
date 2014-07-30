using AcklenAvenue.Testing.Moq.ExpectedObjects;

using CrowfoundingHn.Common.Authentication.Commands;
using CrowfoundingHn.Presentation.Api.Requests;

using FizzWare.NBuilder;

using Machine.Specifications;

using Moq;

using Nancy;
using Nancy.Testing;

using It = Machine.Specifications.It;

namespace CrowfoundingHn.Presentation.Specs.AuthSpecs
{
    public class when_creating_a_new_user : given_a_auth_module_context
    {
        static UserRequest _userRequest;

        static CreateUser _excpectedCommand;

        static BrowserResponse _response;

        Establish context = () =>
            {
                

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

        Because of = () => _response = Browser.PostSecureJson("/auth/create", _userRequest);

        It should_dispatch_create_user_command =
            () =>
            Mock.Get(CommandDisptacher)
                .Verify(dispatcher => dispatcher.Dispatch(WithExpected.Object(_excpectedCommand)));

        It should_return_200_status = () => _response.StatusCode.ShouldEqual(HttpStatusCode.OK);
    }
}