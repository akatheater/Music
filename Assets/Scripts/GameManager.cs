using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public AudioSource bgm;

    public bool startPlaying; //��������
    public bool gameOver; //һ������

    public KeyCode startKey;

    public BeatScrollerController bsc;
    public BasicButtonController bbc;
    public BasicPlayerController bpc_red;
    public BasicPlayerController bpc_blue;
    public BasicPlayerController bpc_current;
    public CreateTrack ct;

    public int musicNum; //һ�׸��ܹ��ж��پ䣨���ٸ������
    public int currentMusic; //���ڲ��ŵ�����һ�䣨�ڼ��������

    public KeyCode keyLeftArrow;
    public KeyCode keyRightArrow;
    public KeyCode keyUpArrow;
    public KeyCode keyDownArrow;
    public KeyCode keySpace;

    public bool btnIsEnterTrigger; //btn����track

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

        //��ʱ��UI
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
            if(Input.GetKeyDown(startKey)) //֮����Ҫ�ģ�ʲô����¿�ʼ
            {
                startPlaying = true;
                bgm.Play();
                ct.CreateCurrentTrack(currentMusic,currentTurn); //���ɵ�һ�����
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
        if(startPlaying) //֮����Ҫ�ģ�ʲô����¿�ʼ
        {           
            //ѡ��
            //����Tempo��ı�
            float beatTempo = bsc.GetBeatTempo();
            if(btnHasReturn)
            {
                ct.DeleteTrack();
                currentMusic++;
                if(currentMusic<musicNum)
                {
                    //TODO: ��Ҫдһ�����������ݸ����Ĺ��ɸı�currentTurn
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

    //ͨ�����̿��ƽ�ɫ�ƶ���������ƶ���ʽ��BasicPlayerController��
    void PlayerMove()
    {
        
        if(btnIsEnterTrigger)
        {

        }
        //��������ȥ
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

        //��������ȥ
        if (Input.GetKeyDown(keySpace))
        {
            bpc_current.Attack();
        }

        bpc_current.StopAttack();

    }

    //�ڿհ׹�����������bug���п�����
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
