namespace Testtoo.Models;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}

    public DbSet<Event> Events { get; set; }
    public DbSet<Participant> Participants { get; set; }
  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
            
        modelBuilder.Entity<Event>().ToTable("Event").HasKey(x => x.EventId);
        modelBuilder.Entity<Participant>().ToTable("Participant").HasKey(x => x.ParticipantId);
        
            
        modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = 1,
                    Name = "Event 1",
                    DateTime = new DateTime(2025, 02, 14),
                    Location = "Location 1"
                },
                new Event
                {
                    EventId = 2,
                    Name = "Event 2",
                    DateTime = new DateTime(2025, 02, 18),
                    Location = "Location 2"
                },
                new Event
                {
                    EventId = 3,
                    Name = "Event 3",
                    DateTime = new DateTime(2025, 03, 03),
                    Location = "Location 3"
                },
                new Event
                {
                    EventId = 4,
                    Name = "Event 4",
                    DateTime = new DateTime(2025, 03, 22),
                    Location = "Location 4"
                },
                new Event
                {
                    EventId = 5,
                    Name = "Event 5",
                    DateTime = new DateTime(2024, 01, 14),
                    Location = "Location 5"
                },
                new Event
                {
                    EventId = 6,
                    Name = "Event 6",
                    DateTime = new DateTime(2023, 12, 18),
                    Location = "Location 6"
                },
                new Event
                {
                    EventId = 7,
                    Name = "Event 7",
                    DateTime = new DateTime(2023, 12, 03),
                    Location = "Location 7"
                },
                new Event
                {
                    EventId = 8,
                    Name = "Event 8",
                    DateTime = new DateTime(2023, 11, 22),
                    Location = "Location 8"
                },
                new Event
                {
                    EventId = 9,
                    Name = "Event 9",
                    DateTime = new DateTime(2023, 11, 01),
                    Location = "Location 9"
                },
                new Event
                {
                    EventId = 10,
                    Name = "Event 10",
                    DateTime = new DateTime(2023, 10, 15),
                    Location = "Location 10"
                },
                new Event
                {
                    EventId = 11,
                    Name = "Event 11",
                    DateTime = new DateTime(2025, 12, 30),
                    Location = "Location 11"
                },
                new Event
                {
                    EventId = 12,
                    Name = "Event 12",
                    DateTime = new DateTime(2024, 06, 12),
                    Location = "Location 12"
                }
            );

            modelBuilder.Entity<Participant>().HasData(
                new Participant
                {
                    ParticipantId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    PersonalCode = "1234567890",
                    PaymentMethod = "bankTransfer",
                    AdditionalInfo = "Additional info 1",
                    EventId = 1
                },
                new Participant
                {
                    ParticipantId = 2,
                    FirstName = "Alice",
                    LastName = "Smith",
                    PersonalCode = "0987654321",
                    PaymentMethod = "cash",
                    AdditionalInfo = "Additional info 2",
                    EventId = 1
                },
                new Participant
                {
                    ParticipantId = 3,
                    FirstName = "Bob",
                    LastName = "Johnson",
                    PersonalCode = "2468013579",
                    PaymentMethod = "bankTransfer",
                    AdditionalInfo = "Additional info 3",
                    EventId = 2
                },
                new Participant
                {
                    ParticipantId = 4,
                    FirstName = "Emma",
                    LastName = "Brown",
                    PersonalCode = "1357924680",
                    PaymentMethod = "cash",
                    AdditionalInfo = "Additional info 4",
                    EventId = 2
                },
                new Participant
                {
                    ParticipantId = 5,
                    FirstName = "Michael",
                    LastName = "Lee",
                    PersonalCode = "9876543210",
                    PaymentMethod = "bankTransfer",
                    AdditionalInfo = "Additional info 5",
                    EventId = 3
                },
                new Participant
                {
                    ParticipantId = 6,
                    FirstName = "Sophia",
                    LastName = "Wang",
                    PersonalCode = "0123456789",
                    PaymentMethod = "cash",
                    AdditionalInfo = "Additional info 6",
                    EventId = 3
                },
                new Participant
                {
                    ParticipantId = 7,
                    FirstName = "Emily",
                    LastName = "Jones",
                    PersonalCode = "4567890123",
                    PaymentMethod = "bankTransfer",
                    AdditionalInfo = "Additional info 7",
                    EventId = 4
                },
                new Participant
                {
                    ParticipantId = 8,
                    FirstName = "Daniel",
                    LastName = "Garcia",
                    PersonalCode = "3210987654",
                    PaymentMethod = "cash",
                    AdditionalInfo = "Additional info 8",
                    EventId = 4
                },
                new Participant
                {
                    ParticipantId = 9,
                    FirstName = "Olivia",
                    LastName = "Brown",
                    PersonalCode = "9870123456",
                    PaymentMethod = "bankTransfer",
                    AdditionalInfo = "Additional info 9",
                    EventId = 5
                },
                new Participant
                {
                    ParticipantId = 10,
                    FirstName = "William",
                    LastName = "Miller",
                    PersonalCode = "6543210987",
                    PaymentMethod = "cash",
                    AdditionalInfo = "Additional info 10",
                    EventId = 5
                },
                new Participant
            {
                ParticipantId = 11,
                CompanyName = "ABC Inc.",
                CompanyRegistrationCode = "ABC123",
                NumberOfParticipantsFromCompany = 10,
                PaymentMethod = "bankTransfer",
                AdditionalInfo = "Additional info 1",
                EventId = 1
            },
            new Participant
            {
                ParticipantId = 12,
                CompanyName = "XYZ Ltd.",
                CompanyRegistrationCode = "XYZ456",
                NumberOfParticipantsFromCompany = 8,
                PaymentMethod = "cash",
                AdditionalInfo = "Additional info 2",
                EventId = 1
            },
            new Participant
            {
                ParticipantId = 13,
                CompanyName = "LMN Enterprises",
                CompanyRegistrationCode = "LMN789",
                NumberOfParticipantsFromCompany = 15,
                PaymentMethod = "bankTransfer",
                AdditionalInfo = "Additional info 10",
                EventId = 2
            },
            new Participant
            {
                ParticipantId = 14,
                CompanyName = "PQR Solutions",
                CompanyRegistrationCode = "PQR101",
                NumberOfParticipantsFromCompany = 5,
                PaymentMethod = "cash",
                AdditionalInfo = "Additional info 4",
                EventId = 2
            },
            new Participant
            {
                ParticipantId = 15,
                CompanyName = "DEF Corp.",
                CompanyRegistrationCode = "DEF789",
                NumberOfParticipantsFromCompany = 12,
                PaymentMethod = "bankTransfer",
                AdditionalInfo = "Additional info 5",
                EventId = 3
            },
            new Participant
            {
                ParticipantId = 16,
                CompanyName = "GHI Enterprises",
                CompanyRegistrationCode = "GHI456",
                NumberOfParticipantsFromCompany = 20,
                PaymentMethod = "cash",
                AdditionalInfo = "Additional info 6",
                EventId = 3
            },
            new Participant
            {
                ParticipantId = 17,
                CompanyName = "JKL Solutions",
                CompanyRegistrationCode = "JKL321",
                NumberOfParticipantsFromCompany = 7,
                PaymentMethod = "bankTransfer",
                AdditionalInfo = "Additional info 7",
                EventId = 4
            },
            new Participant
            {
                ParticipantId = 18,
                CompanyName = "MNO Ltd.",
                CompanyRegistrationCode = "MNO654",
                NumberOfParticipantsFromCompany = 10,
                PaymentMethod = "cash",
                AdditionalInfo = "Additional info 8",
                EventId = 4
            },
            new Participant
            {
                ParticipantId = 19,
                CompanyName = "STU Corp.",
                CompanyRegistrationCode = "STU987",
                NumberOfParticipantsFromCompany = 8,
                PaymentMethod = "bankTransfer",
                AdditionalInfo = "Additional info 9",
                EventId = 5
            },
            new Participant
            {
                ParticipantId = 20,
                CompanyName = "VWX Enterprises",
                CompanyRegistrationCode = "VWX111",
                NumberOfParticipantsFromCompany = 15,
                PaymentMethod = "cash",
                AdditionalInfo = "Additional info 10",
                EventId = 5
            }
            );
        }
    }
