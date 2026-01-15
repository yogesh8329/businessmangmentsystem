    using BMS.Core.DTOs;
    using BMS.Core.Entities;
    using BMS.Core.Interfaces;
    using global::BMS.Core.DTOs;
    using global::BMS.Core.Entities;
    using global::BMS.Core.Interfaces;

    namespace BMS.Api.Repositories
    {
        public class UserRepository : IUserRepository
        {
            private static readonly List<User> _users = new();

            public Task<IEnumerable<UserDto>> GetAllAsync()
            {
                var result = _users.Select(u => new UserDto
                {
                    Id = u.Id,
                    FullName = u.FirstName + " " + u.LastName,

                    Email = u.Email
                });

                return Task.FromResult(result);
            }

            public Task<UserDto?> GetByIdAsync(int id)
            {
                var user = _users.FirstOrDefault(x => x.Id == id);

                if (user == null) return Task.FromResult<UserDto?>(null);

                return Task.FromResult<UserDto?>(new UserDto
                {
                    Id = user.Id,
                    FullName = user.FirstName + " " + user.LastName,

                    Email = user.Email
                });
            }

            public Task AddAsync(User user)
            {
                user.Id = _users.Count + 1;
                _users.Add(user);
                return Task.CompletedTask;
            }
        public async Task<int> AddAsync(CreateUserDto dto)
        {
            var user = new User
            {
                Id = _users.Any() ? _users.Max(x => x.Id) + 1 : 1,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                IsActive = true
            };

            _users.Add(user);

            return await Task.FromResult(user.Id);
        }

    }
}
