using FitFalTracker.Domain.Common;
using FitFalTracker.Domain.Enums;

namespace FitFalTracker.Domain.ValueObjects;

public class Weight : ValueObject
{
    public decimal Value { get; set; }
    public WeightEnum WeightEnum { get; set; }

    public override string ToString()
    {
        return $"{Value} {WeightEnum}";
    }
    
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return WeightEnum;
    }
}