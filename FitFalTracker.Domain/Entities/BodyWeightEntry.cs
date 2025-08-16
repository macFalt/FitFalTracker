using FitFalTracker.Domain.ValueObjects;

namespace FitFalTracker.Domain.Entities;

public class BodyWeightEntry
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Weight Weight { get; set; }
    
    public AppUser AppUser { get; set; }
    public int  AppUserId { get; set; }
    
    
}