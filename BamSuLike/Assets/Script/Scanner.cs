using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    private float scanRange;
    private LayerMask targetLayer;
    private RaycastHit2D[] targets;
    private Transform nearestTarget;

    private void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        nearestTarget = GenNearest();
    }

    Transform GenNearest()
    {
        Transform result = null;
        float diff = 100;

        foreach(RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);

            if(curDiff < diff)
            {
                diff = curDiff;
                result = transform.transform;
            }
        }

        return result;
    }
}
