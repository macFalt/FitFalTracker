namespace FitFalTracker.Domain.Entities;

public class Workout
{
    public int  Id { get; set; }
    
    public DateTime Date { get; set; }

    public string  Name { get; set; }

    public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    
}