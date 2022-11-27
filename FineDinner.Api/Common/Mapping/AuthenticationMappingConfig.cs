using FineDinner.Application.Authentication.Commands.Register;
using FineDinner.Application.Authentication.Common;
using FineDinner.Application.Authentication.Queries.Login;
using FineDinner.Contracts.Authentication;
using Mapster;

namespace FineDinner.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest, src => src.User);

        // following mappings are redundant, but keeping them here
        // to make very clear where to adapt mappings, if changes are needed
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
    }
}
