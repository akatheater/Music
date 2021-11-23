using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScrollerController : MonoBehaviour
{

    public float beatTempo; //120pm，0.5s一拍，每拍间隔1,1s走2
    public Vector3 redBtnIniPosition;
    public Vector3 blueBtnIniPosition;

    public bool hasStarted; //测试用
    public bool redBtnHasReturn;
    public bool blueBtnHasReturn;

    public RedTrack rt;
    public Vector3 rcPosition;

    public BlueTrack bc;
    Transform bcTransform;

    // Start is called before the first frame update
    void Start()
    {
        rcPosition = rt.GetRedTrackPosition();
        //bcTransform = bc.GetBlueTrackTransform();
        redBtnIniPosition = new Vector3(rcPosition.x-3.5f-0.5f, rcPosition.y, 0);
        transform.position = redBtnIniPosition;
        //blueBtnIniPosition = new Vector3(bcTransform.position.x - 3.5f - 0.5f, bcTransform.position.y, 0);
        beatTempo = beatTempo / 60f;
        redBtnHasReturn = false;
        blueBtnHasReturn = false;
    }

    // Update is called once per frame
    void Update()
    {
        rcPosition = rt.GetRedTrackPosition();
        //rcTransform = rc.GetRedTrackTransform();
        //bcTransform = bc.GetBlueTrackTransform();
    }

    public void RedStartScroll()
    {
        //transform.position += new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
        transform.Translate(beatTempo * Time.deltaTime, 0, 0);
        //【如果到尽头了就回到第一个dot】
        if (transform.position.x >= 3.5f+0.5f+rcPosition.x)
        {
            transform.position = redBtnIniPosition;
            redBtnHasReturn = true;
        }
    }

    //public void BlueStartScroll()
    //{
    //    //transform.position += new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
    //    transform.Translate(beatTempo * Time.deltaTime, 0, 0);
    //    //【如果到尽头了就回到第一个dot】
    //    if (transform.position.x >= 3.5f + 0.5f + bcTransform.position.x)
    //    {
    //        transform.position = blueBtnIniPosition;
    //        blueBtnHasReturn = true;
    //    }
    //}

    public float GetBeatTempo()
    {
        return beatTempo;
    }

    public bool RedBtnHasReturn()
    {
        return redBtnHasReturn;
    }

    public void SetRedBtnReturn(bool set)
    {
        redBtnHasReturn = set;
    }

    //public bool BlueBtnHasReturn()
    //{
    //    return blueBtnHasReturn;
    //}

    //public void SetBlueBtnReturn(bool set)
    //{
    //    blueBtnHasReturn = set;
    //}
}
