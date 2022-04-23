using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVision : MonoBehaviour
{
    [Range(0.5f,  10.0f)]
    [SerializeField] private float visionRange = 5;

    [Range(0, 180)]
    [SerializeField] private float visionAngle = 30;

    public bool IsVisble(GameObject target)
    {
        if(target == null)
        {
            return false;
        }
        if(Vector2.Distance(transform.position, target.transform.position) > visionRange)
        {
            return false;
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, visionRange);

        Vector3 visionDirection = Vector3.right;
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, visionAngle / 2) * visionDirection * visionRange);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, -visionAngle / 2) * visionDirection * visionRange);
    }
}
