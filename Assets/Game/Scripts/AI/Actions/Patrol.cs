using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using Platformer2D.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Game/Patrol")]
public class Patrol : BasePrimitiveAction
{
    [InParam("IAController")]
    private EnemyIAController aiController;
    [InParam("PatrolSpeed")]
    private float patrolSpeed;
    [InParam("ChacterMovement")]
    private CharacterMovement2D characterMovement;
    public override void OnStart()
    {
        base.OnStart();
        aiController.StartCoroutine(Temp_Walk());
        characterMovement.MaxGroundSpeed = patrolSpeed;
    }
    public override void OnAbort()
    {
        base.OnAbort();
        aiController.StopAllCoroutines();
    }
    public override TaskStatus OnUpdate()
    {
        return TaskStatus.RUNNING;
    }
    IEnumerator Temp_Walk()
    {
        while (true)
        {
            aiController.MovementInput = new Vector2(1, 0);
            yield return new WaitForSeconds(1.0f);
            aiController.MovementInput = new Vector2(0, 0);
            yield return new WaitForSeconds(2.0f);
            aiController.MovementInput = new Vector2(-1, 0);
            yield return new WaitForSeconds(1.0f);
            aiController.MovementInput = new Vector2(0, 0);
            yield return new WaitForSeconds(2.0f);
        }
    }
}
