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
        aiController.isChacing = true;
        characterMovement.MaxGroundSpeed = chaseSpeed;
    }
    public override void OnAbort()
    {
        base.OnAbort();
        aiController.isChacing = false;
    }
    public override TaskStatus OnUpdate()
    {
        Vector2 toTarget = target.transform.position - aiController.transform.position;
        aiController.movementInput.x = Mathf.Sign(toTarget.x);
        return TaskStatus.RUNNING;
    }
}
