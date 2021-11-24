using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTrack : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;

    public bool rotateAroundLeft;
    public bool rotateAroundRight;
    public float speed;

    public bool leftOnGround;
    public bool rightOnGround;

    private SpriteRenderer thisSR;
    //public Sprite trackBgImg;

    // Start is called before the first frame update
    void Start()
    {
        thisSR = GetComponent<SpriteRenderer>();

        rotateAroundLeft = false;
        rotateAroundRight = false;

        leftOnGround = false;
        rightOnGround = false;
    }

    // Update is called once per frame
    void Update()
    {    
        RotateAroundLeft();
        RotateAroundRight();
    }

    public Vector3 GetRedTrackPosition()
    {
        return this.gameObject.transform.position;
    }

    public Vector3 GetRedTrackRotation()
    {
        return this.gameObject.transform.eulerAngles;
    }

    public void RotateAroundLeft()
    {
        if(rotateAroundLeft && !rightOnGround)
        {
            transform.RotateAround(leftPoint.transform.position,Vector3.back, speed*Time.deltaTime);
        }
    }

    public void RotateAroundRight()
    {
        if (rotateAroundRight && !leftOnGround)
        {
            transform.RotateAround(rightPoint.transform.position, Vector3.forward, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision:" + collision.transform.name);
        if (collision.transform.tag == "ground")
        {
            if(rotateAroundLeft)
            {
                rotateAroundLeft = false;
                rightOnGround = true;
            }
            if(rotateAroundRight)
            {
                rotateAroundRight = false;
                leftOnGround = true;
            }
            
        }
    }

    public void SetRotateAroundLeft(bool rotate)
    {
        rotateAroundLeft = rotate;
    }

    public void SetRotateAroundRight(bool rotate)
    {
        rotateAroundRight = rotate;
    }

    public void SetTrackBgImgDefault()
    {
        thisSR.sprite = default;
    }

}
