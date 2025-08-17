using System.Text.Json.Serialization;

namespace FitFalTracker.Domain.Entities;

public class Workout
{
    public int  Id { get; set; }
    
    public DateTime Date { get; set; }

    public string  Name { get; set; }

    [JsonIgnore] public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    
}