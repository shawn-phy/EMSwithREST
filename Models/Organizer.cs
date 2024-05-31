using System;
using System.Collections.Generic;

namespace EMSwithREST.Models;

public partial class Organizer
{
    public int OrganizerId { get; set; }

    public string OrganizerName { get; set; } = null!;

    public string ContactEmail { get; set; } = null!;

    public string? ContactPhone { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
