using MediatR;

namespace Application.UseCases.CreateUser;

public abstract record CreateUserRequest(
    string Email, string Name) :
    IRequest<CreateUserResponse>;