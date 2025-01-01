using FamilyBudgeting.Application.DTOs;
using FamilyBudgeting.Domain.Data.Users;

namespace FamilyBudgeting.Application.Mappers
{
    public static class UserMapper
    {
        public static User ConvertDtoToDomain(UserDto userDto)
        {
            return new User(userDto.FirstName, userDto.LastName, userDto.Email, userDto.PasswordHash) { Id = userDto.Id };
        }

        public static IEnumerable<User> ConvertDtoToDomains(IEnumerable<UserDto> userDtos)
        {
            return userDtos.Select(x => new User(x.FirstName, x.LastName, x.Email, x.PasswordHash) { Id = x.Id });
        }

        public static UserDto ConvertDomainToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
            };
        }

        public static IEnumerable<UserDto> ConvertDomainToDtos(IEnumerable<User> users)
        {
            return users.Select(x => new UserDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PasswordHash = x.PasswordHash,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                }
            );
        }
    }
}
