using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScrollerController : MonoBehaviour
{
    public GameObject redTrack;
    public GameObject blueTrack;

    public float beatTempo; //120pm，0.5s一拍，每拍间隔1,1s走2
    public Vector3 redBtnIniPosition;
    public Vector3 blueBtnIniPosition;

    public bool hasStarted; //测试用
    public bool redBtnHasReturn;
    public bool blueBtnHasReturn;

    public RedTrack rt;
    public Vector3 rtPosition;
    public Vector3 rtRotation;

    public BlueTrack bt;

    private enum PlayerTurn { red, blue };

    // Start is called before the first frame update
    void Start()
    {
        redBtnIniPosition = new Vector3(-4.0f, 0, 0);
        blueBtnIniPosition = new Vector3(-4.0f, 0, 0);

        transform.SetParent(redTrack.transform);
        transform.localPosition = redBtnIniPosition;
        transform.localEulerAngles = Vector3.zero;

        beatTempo = beatTempo / 60f;
        redBtnHasReturn = false;
        blueBtnHasReturn = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = Vector3.zero;
    }

    public void RedStartScroll(int nextTurn)
    {
        transform.SetParent(redTrack.transform);
        transform.Translate(beatTempo * Time.deltaTime, 0, 0);
        //【如果到尽头了就回到第一个dot】
        if (transform.localPosition.x >= 4.0f)
        {
            if (nextTurn == (int)PlayerTurn.red)
            {
                transform.localPosition = redBtnIniPosition;
                redBtnHasReturn = true;
                //Debug.Log("red btn has return!");
            }
            if (nextTurn == (int)PlayerTurn.blue)
            {
                transform.SetParent(blueTrack.transform);
                transform.localPosition = blueBtnIniPosition;
                redBtnHasReturn = true;
                //Debug.Log("red btn has return!");
            }

        }
    }

    public void BlueStartScroll(int nextTurn)
    {
        transform.SetParent(blueTrack.transform);
        transform.Translate(beatTempo * Time.deltaTime, 0, 0);
        //【如果到尽头了就回到第一个dot】
        if (transform.localPosition.x >= 4.0f)
        {
            if (nextTurn == (int)PlayerTurn.blue)
            {
                transform.localPosition = blueBtnIniPosition;
                blueBtnHasReturn = true;
                //Debug.Log("red btn has return!");
            }
            if (nextTurn == (int)PlayerTurn.red)
            {
                transform.SetParent(redTrack.transform);
                transform.localPosition = redBtnIniPosition;
                blueBtnHasReturn = true;
                //Debug.Log("red btn has return!");
            }          

        }
    }

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

    public bool BlueBtnHasReturn()
    {
        return blueBtnHasReturn;
    }

    public void SetBlueBtnReturn(bool set)
    {
        blueBtnHasReturn = set;
    }

}
