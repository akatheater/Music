using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairTopCollision : MonoBehaviour
{
    public float downPosition;

    public float GetDownPosition()
    {

        Ray2D upLine = new Ray2D(transform.position, Vector2.down);
        RaycastHit2D hit = Physics2D.Raycast(upLine.origin, upLine.direction);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.CompareTag("StairBottom"))
            {
                downPosition = hit.transform.position.y;
            }
            else
            {
                Debug.Log("检测到" + hit.transform.gameObject.tag);
            }
        }
        else
        {
            Debug.Log("没有碰撞任何对象");
        }
        return downPosition;
    }
}
