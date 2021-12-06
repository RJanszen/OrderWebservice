namespace Optimizers.Order.Services.Contracts.DTO.User
{
    public record CreateUserDTO
    {
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
    }
}
