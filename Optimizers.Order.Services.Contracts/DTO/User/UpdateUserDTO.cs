namespace Optimizers.Order.Services.Contracts.DTO.User
{
    public record UpdateUserDTO
    {
        public string UserName { get; set; } = string.Empty;

        public string OldPassword { get; set; } = string.Empty; 

        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
    }
}
