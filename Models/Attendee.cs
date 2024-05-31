namespace EMSwithREST.Models
{
    public partial class Attendee
    {
        public int AttendeeId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public DateOnly RegistrationDate { get; set; }

        public int? EventId { get; set; }

        public virtual Event? Event { get; set; }
    }
}
