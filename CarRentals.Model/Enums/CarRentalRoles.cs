using System.ComponentModel;

namespace CarRentals.Model.Enums
{
    public enum CarRentalRole : int
    {
        [Description("Admin")]
        Admin = 1,

        [Description("Guest")]
        GuestUser = 2,

        [Description("NormalUser")]
        NormalUser = 3
    }
}