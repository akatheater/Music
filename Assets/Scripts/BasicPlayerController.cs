using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerController : MonoBehaviour
{
    //TODO
    //һ��player�࣬����hp������transform
    //һ����player��һģһ����item�࣬��������item���ܱ�input�����ƶ���������Զ��ƶ���

    public float moveSpeed;
    public Transform movePoint;

    public LayerMask whatStopsMovement;

    public bool isKeyPressed;

    public int HP;

    public ShakeCamera shakeCamera;

    //public StairBottomCollision sbc;
    public PlayerCollision pc;
    GameObject bottomStair;
    GameObject topStair;

    public RedTrack rt;
    public BlueTrack bt;

    public Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        HP = 3;
        moveSpeed = 500f;
        movePoint.parent = null;
        isKeyPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        bottomStair = pc.GetBottomStair();
        topStair = pc.GetTopStair();
    }

    public void MoveLeft()
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(-1f, 0f, 0f);
                }
            
        }
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        transform.localScale = new Vector3(-1, 1, 1);
    }

    public void MoveRight()
    {        
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, whatStopsMovement))
            {
                movePoint.position += new Vector3(1f, 0f, 0f);
            }

        }
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void MoveUp()
    {
        if(pc.WhetherMeetStairBottom())
        {
            movePoint.position = new Vector3(movePoint.position.x, bottomStair.GetComponent<StairBottomCollision>().GetUpPosition(), 0);
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, 10.0f);
        }
    }

    public void MoveDown()
    {
        if (pc.WhetherMeetStairTop())
        {
            movePoint.position = new Vector3(movePoint.position.x, topStair.GetComponent<StairTopCollision>().GetDownPosition(), 0);
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, 10.0f);
        }
    }

    public void Attack()
    { 
        playerAnim.SetBool("isAttack", true);

        //������Ч
        //TODO��������Ѫ
        if(transform.localScale.x==1)//�泯��
        {
            if(pc.EnemyRight())//�ұ���enemy ֮����Լ�����item
            {
                pc.GetRightEnemy().transform.parent.GetComponent<BasicPlayerController>().DecreaseHP();
                shakeCamera.StartShake();
            }
            if(pc.StairBottomRight())
            {
                pc.GetRightStairBottom().transform.GetComponent<BasicItemController>().DestroyMyself();
                shakeCamera.StartShake();
            }
            if (pc.RedLeftRopeRight())
            {
                pc.GetRedLeftRope().transform.GetComponent<BasicItemController>().DestroyMyself();
                rt.SetRotateAroundRight(true);
                shakeCamera.StartShake();
            }
            if (pc.RedRightRopeRight())
            {
                pc.GetRedRightRope().transform.GetComponent<BasicItemController>().DestroyMyself();
                rt.SetRotateAroundLeft(true);
                shakeCamera.StartShake();
            }
            if (pc.BlueLeftRopeRight())
            {
                pc.GetBlueLeftRope().transform.GetComponent<BasicItemController>().DestroyMyself();
                bt.SetRotateAroundRight(true);
                shakeCamera.StartShake();
            }
            if (pc.BlueRightRopeRight())
            {
                pc.GetBlueRightRope().transform.GetComponent<BasicItemController>().DestroyMyself();
                bt.SetRotateAroundLeft(true);
                shakeCamera.StartShake();
            }
            if (pc.RedTrackRight())
            {
                //Debug.Log("redTrackRight!!");
                rt.SetTrackBgImgDefault();
                shakeCamera.StartShake();
            }
            if (pc.BlueTrackRight())
            {
                //Debug.Log("redTrackRight!!");
                bt.SetTrackBgImgDefault();
                shakeCamera.StartShake();
            }

        }
        if (transform.localScale.x == -1)//�泯��
        {
            if (pc.EnemyLeft())//�����enemy ֮����Լ�����item
            {
                pc.GetLeftEnemy().transform.parent.GetComponent<BasicPlayerController>().DecreaseHP();
                shakeCamera.StartShake();
            }
            if (pc.StairBottomLeft())
            {
                pc.GetLeftStairBottom().transform.GetComponent<BasicItemController>().DestroyMyself();
                shakeCamera.StartShake();
            }
            if(pc.RedLeftRopeLeft())
            {
                pc.GetRedLeftRope().transform.GetComponent<BasicItemController>().DestroyMyself();
                rt.SetRotateAroundRight(true);
                shakeCamera.StartShake();
            }
            if (pc.RedRightRopeLeft())
            {
                pc.GetRedRightRope().transform.GetComponent<BasicItemController>().DestroyMyself();
                rt.SetRotateAroundLeft(true);
                shakeCamera.StartShake();
            }
            if (pc.BlueLeftRopeLeft())
            {
                pc.GetBlueLeftRope().transform.GetComponent<BasicItemController>().DestroyMyself();
                bt.SetRotateAroundRight(true);
                shakeCamera.StartShake();
            }
            if (pc.BlueRightRopeLeft())
            {
                pc.GetBlueRightRope().transform.GetComponent<BasicItemController>().DestroyMyself();
                bt.SetRotateAroundLeft(true);
                shakeCamera.StartShake();
            }
            if(pc.RedTrackLeft())
            {
                //Debug.Log("redTrackLeft!!");
                rt.SetTrackBgImgDefault();
                shakeCamera.StartShake();
            }
            if (pc.BlueTrackLeft())
            {
                //Debug.Log("redTrackLeft!!");
                bt.SetTrackBgImgDefault();
                shakeCamera.StartShake();
            }
        }
    }
    
    //ֹͣattack����
    public void StopAttack()
    {
        if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                playerAnim.SetBool("isAttack", false);
            }
        }
    }

    
    public void DecreaseHP()
    {
        HP--;
        if(HP<=0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver=true;
            //TODO
            //��������
            this.gameObject.SetActive(false);
        }
    }

    public int GetHP()
    {
        return HP;
    }
}
