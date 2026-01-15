using BMS.Core.DTOs;
using BMS.Core.Entities;


namespace BMS.Core.Interfaces
    {
        public interface IUserRepository
        {
            Task<IEnumerable<UserDto>> GetAllAsync();
            Task<UserDto?> GetByIdAsync(int id);
            Task<int> CreateAsync(CreateUserDto dto);
        }
    }
