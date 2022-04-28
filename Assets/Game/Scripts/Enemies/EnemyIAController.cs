using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(CharacterFacing2D))]
[RequireComponent(typeof(IDamageable))]
public class EnemyIAController : MonoBehaviour
{
    [SerializeField] private TriggerDamage damage;
    CharacterMovement2D enemyMovement;
    CharacterFacing2D enemyFAcing;
    IDamageable damageable;
    private Vector2 movementInput;
    private bool isChacing;

    public bool IsChacing
    {
        get => isChacing;
        set => isChacing = value;
    }
    public Vector2 MovementInput
    {
        get { return movementInput; }
        set { movementInput = new Vector2(Mathf.Clamp(value.x, -1, 1), (Mathf.Clamp(value.y, -1, 1))); }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<CharacterMovement2D>();
        enemyFAcing = GetComponent<CharacterFacing2D>();
        damageable = GetComponent<IDamageable>();

        damageable.DeathEvent += OnDeath;
    }
    private void OnDestroy()
    {
        if(damageable != null)
        {
            damageable.DeathEvent -= OnDeath;
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement.ProcessMovementInput(movementInput);
        enemyFAcing.UpdateFacing(movementInput);
    }
    private void OnDeath()
    {
        enabled = false;
        enemyMovement.StopImmediately();
        damage.gameObject.SetActive(false);
        Destroy(gameObject, 0.8f);
    }
    
}
