using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }

        Vector3 playerPos = GameManager.Instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = playerPos.x - myPos.x;
        float diffY = playerPos.y - myPos.y;

        Vector3 playerDir = GameManager.Instance.player.GetInputVec();
        float dirX = diffX < 0 ? -1 : 1;
        float dirY = diffY < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if(Mathf.Abs(diffX) > Mathf.Abs(diffY))
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (Mathf.Abs(diffX) < Mathf.Abs(diffY))
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemy":

                break;
        }
    }
}
