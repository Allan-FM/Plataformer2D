﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : TriggerDamage, IWeapon
{
    [SerializeField] private float attackTime = 0.2f;

    public bool IsAttacking { get; private set; }

    private void Awake()
    {
        gameObject.SetActive(false);
        IsAttacking = false;
    }
    public void Attack()
    {
        if (!IsAttacking)
        {
            gameObject.SetActive(true);
            IsAttacking = true;
            StartCoroutine(PerformeAttack());
        }
    }
    private IEnumerator PerformeAttack()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(attackTime);
        gameObject.SetActive(false);
        IsAttacking = false;
    }
}
