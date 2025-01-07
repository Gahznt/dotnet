using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.CreateUser;

public class CreateUserHandler(
    IUnitOfWork unitOfWork,
    IUserRepository userRepository,
    IMapper mapper)
    :
        IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    public async Task<CreateUserResponse> Handle(CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);

        userRepository.Create(user);

        await unitOfWork.Commit(cancellationToken);

        return mapper.Map<CreateUserResponse>(user);
    }
}