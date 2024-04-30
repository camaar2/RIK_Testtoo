using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace Testtoo.Models;

public class Event
{
    public int EventId { get; set; }
        
    public string ?Name { get; set; }

    public DateTime DateTime { get; set; }
        
    public string ?Location { get; set; }
        
    public string ?AdditionalInfo { get; set; }

    public ICollection<Participant>? Participants { get; set; }
}