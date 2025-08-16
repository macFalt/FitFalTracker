using System.Text.Json.Serialization;
using FitFalTracker.Domain.Enums;

namespace FitFalTracker.Domain.Entities;

public class ExerciseDefinition
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string MuscleGroup { get; set; }
    public EquipmentEnum Equipment { get; set; }
    
    [JsonIgnore] public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}