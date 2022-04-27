using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using Platformer2D.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Game/ChaseTarget")]
public class ChaseTarget : BasePrimitiveAction
{
    [InParam("Target")]
    private GameObject target;
    [InParam("AIController")]
    private EnemyIAController aiController;
    [InParam("ChaseSpeed")]
    private float chaseSpeed;
    [InParam("ChacterMovement")]
    private CharacterMovement2D characterMovement;
    public override void OnStart()
    {
        base.OnStart();
        aiController.IsChacing = true;
        characterMovement.MaxGroundSpeed = chaseSpeed;
    }
    public override void OnAbort()
    {
        base.OnAbort();
        aiController.IsChacing= false;
    }
    public override TaskStatus OnUpdate()
    {
        if(target == null)
        {
            return TaskStatus.ABORTED;
        }
        Vector2 toTarget = target.transform.position - aiController.transform.position;
        aiController.MovementInput = new Vector2(Mathf.Sign(toTarget.x),0);
        return TaskStatus.RUNNING;
    }
}
