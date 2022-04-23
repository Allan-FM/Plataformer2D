using BBUnity.Conditions;
using Pada1.BBCore;
using UnityEngine;

[Condition("Game/Perception/IsTargetVisible")]
public class IsTargetVisible : GOCondition
{
    [InParam("Target")]
    private GameObject target;
    public override bool Check()
    {
        return Vector2.Distance(gameObject.transform.position, target.transform.position) < 3;
    }
}
