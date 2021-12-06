using Microsoft.AspNetCore.Mvc;
using Optimizers.Order.Services.Contracts.DTO.User;

namespace Optimizers.Order.Services.Contracts.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>?> Get();
        Task<UserDTO?> GetById(long id);
        Task<UserDTO?> Create(CreateUserDTO dto);
        Task<UserDTO?> Update(long id, UpdateUserDTO dto);
        Task<UserDTO?> Delete(long id);
    }
}
