using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool meetStairBottom;
    public bool meetStairTop;
    GameObject bottomStair;
    GameObject topStair;
    GameObject rightEnemy;
    GameObject leftEnemy;
    GameObject rightStairBottom;
    GameObject leftStairBottom;
    GameObject redLeftRope;
    GameObject redRightRope;
    GameObject blueLeftRope;
    GameObject blueRightRope;
    GameObject redTrack;
    GameObject blueTrack;
    GameObject wall;



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

    //打敌人
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

    //打梯子
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

    //打红绳
    public bool RedLeftRopeLeft()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.left);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.name== "RedRopeLeft")
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                redLeftRope = hit.transform.gameObject;
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

    public bool RedLeftRopeRight()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.name == "RedRopeLeft")
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                redLeftRope = hit.transform.gameObject;
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

    public GameObject GetRedLeftRope()
    {
        return redLeftRope;
    }

    public bool RedRightRopeLeft()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.left);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.name == "RedRopeRight")
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                redRightRope = hit.transform.gameObject;
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

    public bool RedRightRopeRight()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.name == "RedRopeRight")
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                redRightRope = hit.transform.gameObject;
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

    public GameObject GetRedRightRope()
    {
        return redRightRope;
    }

    //打蓝绳
    public bool BlueLeftRopeLeft()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.left);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.name == "BlueRopeLeft")
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                blueLeftRope = hit.transform.gameObject;
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

    public bool BlueLeftRopeRight()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.name == "BlueRopeLeft")
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                blueLeftRope = hit.transform.gameObject;
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

    public GameObject GetBlueLeftRope()
    {
        return blueLeftRope;
    }

    public bool BlueRightRopeLeft()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.left);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.name == "BlueRopeRight")
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                blueRightRope = hit.transform.gameObject;
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

    public bool BlueRightRopeRight()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.name == "BlueRopeRight")
            {
                Debug.Log("检测到" + hit.transform.gameObject.tag);
                blueRightRope = hit.transform.gameObject;
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

    public GameObject GetBlueRightRope()
    {
        return blueRightRope;
    }

    //打红轨道
    public bool RedTrackLeft()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.left);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.name == "RedTrack")
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                redTrack = hit.transform.gameObject;
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

    public bool RedTrackRight()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.name == "RedTrack")
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                redTrack = hit.transform.gameObject;
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

    public GameObject GetRedTrack()
    {
        return redTrack;
    }

    //打蓝轨道
    public bool BlueTrackLeft()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.left);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.name == "BlueTrack")
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                blueTrack = hit.transform.gameObject;
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

    public bool BlueTrackRight()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.name == "BlueTrack")
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                blueTrack = hit.transform.gameObject;
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

    public GameObject GetBlueTrack()
    {
        return blueTrack;
    }


    //打墙
    public bool WallLeft()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.left);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.name == "Wall")
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                wall = hit.transform.gameObject;
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

    public bool WallRight()
    {
        bool isLeft = false;
        Ray2D rightLine = new Ray2D(transform.position, Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(rightLine.origin, rightLine.direction, 1f);
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.name == "Wall")
            {
                //Debug.Log("检测到" + hit.transform.gameObject.tag);
                wall = hit.transform.gameObject;
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

    public GameObject GetWall()
    {
        return wall;
    }
}
