using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool meetStairBottom;
    public bool meetStairTop;
    public GameObject bottomStair;
    public GameObject topStair;
    public GameObject rightEnemy;
    public GameObject leftEnemy;
    public GameObject rightStairBottom;
    public GameObject leftStairBottom;


    public bool WhetherMeetStairBottom()
    {
        return meetStairBottom;
    }

    public bool WhetherMeetStairTop()
    {
        return meetStairTop;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "StairBottom")
        {
            meetStairBottom = true;
            bottomStair = other.gameObject;
        }
        if (other.tag == "StairTop")
        {
            meetStairTop = true;
            topStair = other.gameObject;
        }
    }

    public GameObject GetBottomStair()
    {
        return bottomStair;
    }

    public GameObject GetTopStair()
    {
        return topStair;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "StairBottom")
        {
            meetStairBottom = false;
        }
        if (other.tag == "StairTop")
        {
            meetStairTop = false;
        }
    }

    public bool EnemyRight()
    {
        bool isRight=false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction,1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                rightEnemy = hit.transform.gameObject;
                isRight = true;
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
        return isRight;
    }

    public GameObject GetRightEnemy()
    {
        return rightEnemy;
    }

    public bool EnemyLeft()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.left);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                leftEnemy = hit.transform.gameObject;
                isLeft = true;
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
        return isLeft;
    }

    public GameObject GetLeftEnemy()
    {
        return leftEnemy;
    }

    public bool StairBottomRight()
    {
        bool isRight = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.CompareTag("StairBottom"))
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                rightStairBottom = hit.transform.gameObject;
                isRight = true;
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
        return isRight;
    }

    public GameObject GetRightStairBottom()
    {
        return rightStairBottom;
    }

    public bool StairBottomLeft()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.left);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.CompareTag("StairBottom"))
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                leftStairBottom = hit.transform.gameObject;
                isLeft = true;
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
        return isLeft;
    }

    public GameObject GetLeftStairBottom()
    {
        return leftStairBottom;
    }
}
