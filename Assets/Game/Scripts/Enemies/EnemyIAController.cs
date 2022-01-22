using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(CharacterFacing2D))]
public class EnemyIAController : MonoBehaviour
{
    CharacterMovement2D enemyMovement;
    CharacterFacing2D enemyFAcing;
    Vector2 movementInput;
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<CharacterMovement2D>();
        enemyFAcing = GetComponent<CharacterFacing2D>();
        StartCoroutine(Temp_Walk());
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement.ProcessMovementInput(movementInput);
        enemyFAcing.UpdateFacing(movementInput);
    }
    IEnumerator Temp_Walk()
    {
        while(true)
        {
            movementInput.x = 1;
            yield return new WaitForSeconds(1.0f);
            movementInput.x = 0;
            yield return new WaitForSeconds(2.0f);
            movementInput.x = -1;
            yield return new WaitForSeconds(2.0f);
            movementInput.x = 0;
            yield return new WaitForSeconds(2.0f);
        }
    }
}
