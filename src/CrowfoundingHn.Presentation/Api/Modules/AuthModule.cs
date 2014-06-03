using CrowfoundingHn.Common;
using CrowfoundingHn.Common.Authentication.Commands;
using CrowfoundingHn.Presentation.Api.Requests;

using Nancy;
using Nancy.ModelBinding;

namespace CrowfoundingHn.Presentation.Api.Modules
{
    public class AuthModule : NancyModule
    {
        public AuthModule(ICommandDispatcher commandDispatcher)
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
                            request.Ocuapation,
                            request.Address,
                            request.Phone));

                    return null;
                };
        }
    }
}