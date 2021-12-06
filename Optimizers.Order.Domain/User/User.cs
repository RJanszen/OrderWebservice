﻿namespace Optimizers.Order.Domain.User
{
    public class User
    {
        public long Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
    }
}
