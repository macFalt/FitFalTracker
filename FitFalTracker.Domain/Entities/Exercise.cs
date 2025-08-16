using System.Text.Json.Serialization;

namespace FitFalTracker.Domain.Entities;

public class Exercise
{
    public int Id { get; set; }
    public string Notes { get; set; }
    public int Order { get; set; }

    public Workout Workout { get; set; }
    public int WorkoutId { get; set; }

    public ExerciseDefinition ExerciseDefinition { get; set; }
    public int ExerciseDefinitionId { get; set; }

    public ICollection<ExerciseDetail> ExerciseDetails { get; set; } = new List<ExerciseDetail>();
}