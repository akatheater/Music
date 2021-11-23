using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public AudioSource bgm;

    public bool startPlaying; //乐曲播完
    public bool gameOver; //一方死亡

    public KeyCode startKey;

    public BeatScrollerController bsc;
    public BasicButtonController bbc;
    public BasicPlayerController bpc_red;
    public BasicPlayerController bpc_blue;
    public BasicPlayerController bpc_current;
    public CreateTrack ct;

    public int musicNum; //一首歌总共有多少句（多少个轨道）
    public int currentMusic; //正在播放的是哪一句（第几个轨道）

    public KeyCode keyLeftArrow;
    public KeyCode keyRightArrow;
    public KeyCode keyUpArrow;
    public KeyCode keyDownArrow;
    public KeyCode keySpace;

    public bool btnIsEnterTrigger; //btn进入track

    public bool btnHasReturn;

    private enum PlayerTurn { red,blue };
    public int currentTurn;

    public TextMeshProUGUI turn;
    public TextMeshProUGUI hp;

    public static GameManager instance;


    // Start is called before the first frame update
    void Start()
    {

        instance = this;
        gameOver = false;
        musicNum = ct.GetMusicNum();
        currentMusic = 0;
        currentTurn = (int)PlayerTurn.red;
        bpc_current = bpc_red;
    }

    // Update is called once per frame
    void Update()
    {
        btnIsEnterTrigger = bbc.GetEnterTrackTrigger();
        if(currentTurn==(int)PlayerTurn.red)
        {
            btnHasReturn = bsc.RedBtnHasReturn();
        }
        if (currentTurn == (int)PlayerTurn.blue)
        {
            btnHasReturn = bsc.BlueBtnHasReturn();
        }

        PlayerMove();
        PlayerAttack();
        BtnAnim();

        //暂时的UI
        if (currentTurn == (int)PlayerTurn.red)
        {
            turn.text = "red hp= ";
        }
        else if (currentTurn == (int)PlayerTurn.blue)
        {
            turn.text = "blue hp= ";
        }
        hp.text = " "+bpc_current.GetHP();

        if (!startPlaying)
        {
            if(Input.GetKeyDown(startKey)) //之后需要改，什么情况下开始
            {
                startPlaying = true;
                bgm.Play();
                ct.CreateCurrentTrack(currentMusic,currentTurn); //生成第一个轨道
            }
        }

        if(startPlaying && !gameOver)
        {
            if (currentTurn == (int)PlayerTurn.red)
            {
                bsc.RedStartScroll((int)PlayerTurn.blue);
            }
            else if (currentTurn == (int)PlayerTurn.blue)
            {
                bsc.BlueStartScroll((int)PlayerTurn.red);
            }
            
            StartCreateTrack();
        }

        if (currentTurn == (int)PlayerTurn.red)
        {
            bpc_current = bpc_red;
        }
        else if (currentTurn == (int)PlayerTurn.blue)
        {
            bpc_current = bpc_blue;
        }

        if (currentMusic>=musicNum) 
        {
            startPlaying = false;
            bgm.Stop();
        }
        if(gameOver)
        {
            bgm.Stop();
            turn.text = "game over!";
            hp.text = " ";
        }
    }

    void StartCreateTrack()
    {
        if(startPlaying) //之后需要改，什么情况下开始
        {           
            //选做
            //可能Tempo会改变
            float beatTempo = bsc.GetBeatTempo();
            if(btnHasReturn)
            {
                ct.DeleteTrack();
                currentMusic++;
                if(currentMusic<musicNum)
                {
                    //TODO: 需要写一个方法，根据给定的规律改变currentTurn
                    if (currentTurn == (int)PlayerTurn.red)
                    {
                        currentTurn = (int)PlayerTurn.blue;
                    }
                    else if (currentTurn == (int)PlayerTurn.blue)
                    {
                        currentTurn = (int)PlayerTurn.red;
                    }
                    ct.CreateCurrentTrack(currentMusic,currentTurn);
                    bsc.SetRedBtnReturn(false);
                    bsc.SetBlueBtnReturn(false);
                }
            }
        }
    }

    //通过键盘控制角色移动，具体的移动公式在BasicPlayerController里
    void PlayerMove()
    {
        
        if(btnIsEnterTrigger)
        {

        }
        //测完移上去
        if (Input.GetKeyDown(keyLeftArrow))
        {
            bpc_current.MoveLeft();
        }
        if (Input.GetKeyDown(keyRightArrow))
        {
            bpc_current.MoveRight();
        }
        if (Input.GetKeyDown(keyUpArrow))
        {
            bpc_current.MoveUp();
        }
        if (Input.GetKeyDown(keyDownArrow))
        {
            bpc_current.MoveDown();
        }

    }

    void PlayerAttack()
    {
        if (btnIsEnterTrigger)
        {

        }

        //测完移上去
        if (Input.GetKeyDown(keySpace))
        {
            bpc_current.Attack();
        }

        bpc_current.StopAttack();

    }

    //在空白轨道长按会存在bug，有空再修
    void BtnAnim()
    {
        if(btnIsEnterTrigger)
        {
            if (Input.GetKeyDown(keyLeftArrow) || Input.GetKeyDown(keyRightArrow) || Input.GetKeyDown(keySpace))
            {
                bbc.BtnSuccess();
            }
        }
        if(!btnIsEnterTrigger)
        {
            if (Input.GetKeyDown(keyLeftArrow) || Input.GetKeyDown(keyRightArrow) || Input.GetKeyDown(keySpace))
            {
                bbc.BtnPressDown();
            }
            if (Input.GetKeyUp(keyLeftArrow) || Input.GetKeyUp(keyRightArrow) || Input.GetKeyUp(keySpace))
            {
                bbc.BtnPressUp();
            }
        }
        bbc.StopBtnPress();
    }

}
