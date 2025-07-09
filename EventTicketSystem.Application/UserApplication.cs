using EventTicketSystem.Service;
using EventTicketSystem.Application.ResponseGenerators;
using EventTicketSystem.Dto.Request.UserRequest;
using EventTicketSystem.Dto.Response.UserResponse;
using EventTicketSystem.Infrastructure;


public class UserApplication
{
    private readonly UserService _userService;
    private readonly JwtTokenGeneratorService _tokenGenerator; 

    public UserApplication(UserService userService, JwtTokenGeneratorService tokenGenerator)
    {
        _userService = userService;
        _tokenGenerator = tokenGenerator;
    }

    public RegisterUserResponse RegisterUser(RegisterUserRequest request)
    {
        var user = _userService.RegisterUser(request.UserName, request.Email, request.Password);
        return UserResponseGenerator.ToRegisterUserResponse(user);
    }

    public LoginResponse Login(LoginRequest request)
    {
        var user = _userService.Login(request.Email, request.Password);
        var token = _tokenGenerator.GenerateToken(user);
        return new LoginResponse { Token = token };
    }

}
