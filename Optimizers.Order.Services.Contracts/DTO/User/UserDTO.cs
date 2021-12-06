namespace Optimizers.Order.Services.Contracts.DTO.User
{
    public record UserDTO
    {
        public long Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
    }
}
