using System;
using System.Collections.Generic;

namespace EMSwithREST.Models;

public partial class Event
{
    internal object? OrganizerID;

    public int EventId { get; set; }
    public object? EventID { get; internal set; }
    public string EventName { get; set; } = null!;

    public DateOnly EventDate { get; set; }

    public TimeOnly EventTime { get; set; }

    public string Location { get; set; } = null!;

    public string? Description { get; set; }

    public int? OrganizerId { get; set; }

    public virtual ICollection<Attendee> Attendees { get; set; } = new List<Attendee>();

    public virtual Organizer? Organizer { get; set; }
}
