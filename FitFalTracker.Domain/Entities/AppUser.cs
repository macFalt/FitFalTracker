using FitFalTracker.Domain.Enums;
using FitFalTracker.Domain.ValueObjects;

namespace FitFalTracker.Domain.Entities;

public class AppUser
{
    public int Id { get; set; }
    public PersonName FullName { get; set; }

    public DateOnly? DateOfBirth { get; set; }
    
    public float? Height { get; set; }
    
    public ICollection<BodyWeightEntry> BodyWeightEntrys { get; set; } = new List<BodyWeightEntry>();
    
}