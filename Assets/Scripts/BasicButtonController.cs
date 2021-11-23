using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;

    public bool enterTrackTrigger;

    public KeyCode keyLeftArrow;
    public KeyCode keyRightArrow;
    public KeyCode keySpace;

    public Animator btnAnim;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    public void BtnPressDown()
    {
        btnAnim.SetBool("isPressdown", true);
    }

    public void BtnPressUp()
    {
        btnAnim.SetBool("isPressdown", false);
        btnAnim.SetBool("isPressup", true);
    }

    public void StopBtnPress()
    {
        if (btnAnim.GetCurrentAnimatorStateInfo(0).IsName("Pressup"))
        {
            if (btnAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                btnAnim.SetBool("isPressup", false);
            }
        }
        if (btnAnim.GetCurrentAnimatorStateInfo(0).IsName("Success"))
        {
            if (btnAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                btnAnim.SetBool("isSuccess", false);
                btnAnim.SetBool("isPressup", false);
            }
        }
    }

    public void BtnSuccess()
    {
        btnAnim.SetBool("isSuccess", true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Track")
        {
            enterTrackTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Track")
        {
            enterTrackTrigger = false;
        }
    }

    public bool GetEnterTrackTrigger()
    {
        return enterTrackTrigger;
    }

}
