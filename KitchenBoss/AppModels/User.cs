namespace KitchenBoss.AppModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public int UserID { get; set; }

        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(64)]
        public byte[] PasswordHash { get; set; }

        public Guid PasswordSalt { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
