using AutoMapper;
using Optimizers.Order.Infrastructure.Contracts;
using Optimizers.Order.Services.Contracts.DTO.User;
using Optimizers.Order.Services.Contracts.Interfaces;

namespace Optimizers.Order.Services.User
{
    public class UserService : IUserService
    {
        private readonly IMapper _autoMapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Domain.User.User> _repository;

        public UserService(IMapper autoMapper, IUnitOfWork unitOfWork, IRepository<Domain.User.User> repository)
        {
            _autoMapper = autoMapper;
            this._unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<List<UserDTO>?> Get()
        {
            var users = _repository.Get();
            if (!users.Any())
                return null;

            return _autoMapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO?> GetById(long id)
        {
            var user = await GetUserByIdAsync(id);
            if (user == null)
                return null;

            return _autoMapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> Create(CreateUserDTO dto)
        {
            var user = _autoMapper.Map<Domain.User.User>(dto);
            _repository.Insert(user);
            _unitOfWork.Save();

            return _autoMapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO?> Delete(long id)
        {
            var user = await GetUserByIdAsync(id);
            if (user == null)
                return null;

            var dto = _autoMapper.Map<UserDTO>(user);

            _repository.Delete(user);
            _unitOfWork.Save();

            return dto;
        }

        public async Task<UserDTO?> Update(long id, UpdateUserDTO dto)
        {
            var user = await GetUserByIdAsync(id);
            if (user == null)
                return null;

            // Ideally this would result in a BadRequest()
            if (dto.OldPassword != user.Password)
                throw new UnauthorizedAccessException("Incorrect password");

            _autoMapper.Map(dto, user);
            _unitOfWork.Save();

            return _autoMapper.Map<UserDTO>(user);
        }

        private async Task<Domain.User.User?> GetUserByIdAsync(long id) => _repository.Get().FirstOrDefault(o => o.Id == id);
    }
}
