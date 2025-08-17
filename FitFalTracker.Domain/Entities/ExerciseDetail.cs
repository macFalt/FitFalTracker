using System.Text.Json.Serialization;
using FitFalTracker.Domain.ValueObjects;

namespace FitFalTracker.Domain.Entities;

public class ExerciseDetail
{
    public int Id { get; set; }
    public int Reps { get; set; }
    public int SetNumber { get; set; }
    public int? Rir { get; set; }
    public int? Rpe { get; set; }
    public string Tempo { get; set; }
    public Weight Weight { get; set; }
    
    [JsonIgnore]public Exercise? Exercise { get; set; }
    public int ExerciseId { get; set; }
    
    

}
