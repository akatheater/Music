using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTrack : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;

    public bool rotating;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        if(rotating)
        {
            transform.RotateAround(leftPoint.transform.position,Vector3.back, speed*Time.deltaTime);
        }
    }

    public void RotateAroundRight()
    {
        if (rotating)
        {
            transform.RotateAround(rightPoint.transform.position, Vector3.forward, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision:" + collision.transform.name);
        if (collision.transform.tag == "ground")
        {
            rotating = false;
        }
    }

    public void SetRotating(bool rotate)
    {
        rotating = rotate;
    }

    private void OnMouseDown()
    {
        rotating = true;
    }

}
