using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAnimationController : CharacterAnimationController
{
    private EnemyIAController aiController;
    protected override void Awake()
    {
        base.Awake();
        aiController = GetComponent<EnemyIAController>();
    }
    protected override void Update()
    {
        base.Update();
        animator.SetBool(EnemyAnimationKeys.IsChacing, aiController.isChacing);
    }
}
