﻿using System;

using CrowfoundingHn.Common;
using CrowfoundingHn.Common.Authentication;
using CrowfoundingHn.Common.Authentication.Commands;
using CrowfoundingHn.Presentation.Api.Requests;
using CrowfoundingHn.Presentation.Api.Responses;

using Nancy;
using Nancy.ModelBinding;

namespace CrowfoundingHn.Presentation.Api.Modules
{
    public class AuthModule : NancyModule
    {
        public AuthModule(
            ICommandDispatcher commandDispatcher, IUserRepository userRepository, IPasswordEncryptor passwordEncryptor)
            : base("/auth")
        {
            Post["/create"] = x =>
                {
                    var request = this.Bind<UserRequest>();

                    commandDispatcher.Dispatch(
                        new CreateUser(
                            request.Email,
                            request.Password,
                            request.Name,
                            request.Ocupation,
                            request.Address,
                            request.Phone));

                    return null;
                };

            Post["/signin"] = x =>
                {
                    try
                    {
                        var request = this.Bind<UserSessionRequest>();

                        Guid token = SystemGuid.New();
                        EncryptedPassword encryptedPassord = passwordEncryptor.EncryptPassword(request.Password);

                        User userForSesion =
                            userRepository.First(
                                user =>
                                user.Email == request.Email && user.EncryptedPassword == encryptedPassord.Password);

                        commandDispatcher.Dispatch(new CreateUserSession(token, userForSesion.Id));

                        return new TokenResponse { Token = token };
                    }
                    catch (EntityNotFoundException<User>)
                    {
                        return new TokenResponse { Token = null };
                    }
                };
        }
    }
}