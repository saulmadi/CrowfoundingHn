using System;

using AcklenAvenue.Testing.Moq;
using AcklenAvenue.Testing.Moq.ExpectedObjects;

using CrowfoundingHn.Common;
using CrowfoundingHn.Common.Authentication;
using CrowfoundingHn.Common.Authentication.Commands;
using CrowfoundingHn.Presentation.Api.Requests;
using CrowfoundingHn.Presentation.Api.Responses;

using FizzWare.NBuilder;

using Machine.Specifications;

using Moq;

using Nancy.Testing;

using It = Machine.Specifications.It;

namespace CrowfoundingHn.Presentation.Specs.AuthSpecs
{
    public class when_creating_a_new_user_sesion : given_a_auth_module_context
    {
        const string Email = "email@email.com";

        const string Password = "Password";

        static UserSessionRequest _userSessionRequest;

        static BrowserResponse _result;

        static TokenResponse _tokenResponse;

        static User _expectedUser;

        static string _encryptedPassword;

        static User _otherUser;

        static CreateUserSession _createUserSession;

        static Guid _id;

        Establish context = () =>
            {
                Guid token = Guid.NewGuid();
                SystemGuid.New = () => token;
                _userSessionRequest = new UserSessionRequest { Email = Email, Password = Password };
                _tokenResponse = new TokenResponse { Token = token };

                _encryptedPassword = "EncryptedPassword";
                _expectedUser =
                    Builder<User>.CreateNew()
                                 .With(user => user.Id, Guid.NewGuid())
                                 .With(user => user.Email, Email)
                                 .With(user => user.EncryptedPassword, _encryptedPassword)
                                 .Build();

                _otherUser = Builder<User>.CreateNew().Build();

                _createUserSession = Builder<CreateUserSession>.CreateNew()
                                                               .With(session => session.Id, token)
                                                               .With(session => session.UserId, _expectedUser.Id)
                                                               .Build();

                Mock.Get(UserRepository)
                    .Setup(
                        repository =>
                        repository.First(
                            ThatHas.AnExpressionFor<User>()
                                   .ThatMatches(_expectedUser)
                                   .ThatDoesNotMatch(_otherUser)
                                   .Build()))
                    .Returns(_expectedUser);

                Mock.Get(PaswordEncryptor)
                    .Setup(encryptor => encryptor.EncryptPassword(_userSessionRequest.Password))
                    .Returns(new EncryptedPassword(_encryptedPassword));
            };

        Because of = () => _result = Browser.PostSecureJson("auth/signin", _userSessionRequest);

        It should_dispatch_create_session_command =
            () =>
            Mock.Get(CommandDisptacher)
                .Verify(dispatcher => dispatcher.Dispatch(WithExpected.Object(_createUserSession)));

        It should_return_session_id = () => _result.Body<TokenResponse>().ShouldBeLike(_tokenResponse);
    }
}