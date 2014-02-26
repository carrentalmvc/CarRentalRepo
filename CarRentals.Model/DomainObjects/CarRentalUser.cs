namespace CarRentals.Model.DomainObjects
{
    public class CarRentalUser
    {
        public int UserId { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] Password { get; set; }

        public bool IsActive { get; set; }

        public int RoleId { get; set; }

        public CarRentalRole UserRole { get; set; }
    }
}