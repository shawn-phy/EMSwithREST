using System;
using System.Collections.Generic;

namespace EMSwithREST.Models;

public partial class Event
{
    internal object? OrganizerID;

    public int EventId { get; set; }
    public object? EventIdentifier { get; internal set; }
    public string EventName { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public TimeSpan EventTime { get; set; }

    public string Location { get; set; } = null!;

    public string? Description { get; set; }

    public int? OrganizerId { get; set; }

    public virtual ICollection<Attendee> Attendees { get; set; } = new List<Attendee>();

    public virtual Organizer? Organizer { get; set; }
}
