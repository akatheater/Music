using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBottomCollision : MonoBehaviour
{

    public float upPosition;

    public float GetUpPosition()
    {

        Ray2D upLine = new Ray2D(transform.position, Vector2.up);
        RaycastHit2D hit = Physics2D.Raycast(upLine.origin, upLine.direction);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.CompareTag("StairTop"))
            {
                upPosition = hit.transform.position.y + 1.0f;
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
        return upPosition;
    }
}
