using System.ComponentModel.DataAnnotations;

namespace Testtoo.Models;

public class Participant
{
    public int ParticipantId { get; set; }
    public string ?FirstName { get; set; }
    public string ?LastName { get; set; }
    public string ?PersonalCode { get; set; }
    public string ?PaymentMethod { get; set; }

    public string ?AdditionalInfo { get; set; }
    public string ?CompanyName { get; set; }
    public string ?CompanyRegistrationCode { get; set; }
    public int NumberOfParticipantsFromCompany { get; set; }

    public int EventId { get; set; }
    public Event? Event { get; set; }
}