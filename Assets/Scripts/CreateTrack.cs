using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrack : MonoBehaviour
{
    public GameObject redTrack;
    public GameObject blueTrack;
    public GameObject redMusicTrack;
    public GameObject blueMusicTrack;

    public RedTrack rt;
    public Vector3 rtPosition;
    public Vector3 rtRotation;

    public BlueTrack bt;
    public Vector3 btPosition;
    public Vector3 btRotation;

    private enum PlayerTurn { red, blue };

    // Start is called before the first frame update
    void Start()
    {
        rtPosition = rt.GetRedTrackPosition();
        rtRotation = rt.GetRedTrackRotation();

        btPosition = bt.GetBlueTrackPosition();
        btRotation = bt.GetBlueTrackRotation();

    }

    // Update is called once per frame
    void Update()
    {
        rtPosition = rt.GetRedTrackPosition();
        rtRotation = rt.GetRedTrackRotation();

        btPosition = bt.GetBlueTrackPosition();
        btRotation = bt.GetBlueTrackRotation();
    }

    //�����־�
    int[,] RecordMusicCanon()
    {
        //�������Ҫ�޸��־���⡿
        int[,] canon = new int[6, 8]
        {
            {1,0,1,0,1,0,0,0},
            {1,0,1,0,1,0,0,0},
            {1,0,1,0,1,0,1,0},
            {1,0,1,0,1,0,1,0},
            {1,0,1,0,1,1,1,0},
            {1,0,1,0,1,1,1,0}
        };
        return canon;
    }

    public int GetMusicNum()
    {
        int musicNum = RecordMusicCanon().GetLength(0);
        return musicNum;
    }

    //�־�ת����
    Queue<Vector3>[] MusicToTransform()
    {
        int[,] music = RecordMusicCanon();

        Queue<Vector3>[] musicQueue = new Queue<Vector3>[music.GetLength(0)];
        for (int i = 0; i < music.GetLength(0); i++)
        {
            musicQueue[i] = new Queue<Vector3>();
        }
      
        int k = 0;
        for (int i = 0; i < music.GetLength(0); i++) //����
        {
            for (int j = 0; j < music.GetLength(1); j++) //����
            {
                if (music[i, j] == 1)
                {
                    musicQueue[k].Enqueue(new Vector3(j - 3.5f, 0f, 0f));
                }
            }
            k++;
        }

        return musicQueue;
    }

    //��������
    Vector3[] TrackTransform(int musicNum)
    {
        Queue<Vector3>[] trackQueue = MusicToTransform();

        Queue<Vector3> currentMusicQueue = trackQueue[musicNum];

        Vector3[] v3 = currentMusicQueue.ToArray();

        return v3;
    }

    public void CreateCurrentTrack(int currentMusic , int currentTurn)
    {

        Vector3[] v3=TrackTransform(currentMusic);
        foreach(Vector3 v in v3)
        {
            if (currentTurn == (int)PlayerTurn.red)
            {
                GameObject ob = Instantiate(redTrack, Vector3.zero, Quaternion.identity);
                ob.transform.parent = redMusicTrack.transform;
                ob.transform.localPosition = v;
                ob.transform.localEulerAngles = Vector3.zero;
  
            }
            else if (currentTurn == (int)PlayerTurn.blue)
            {
                GameObject ob = Instantiate(blueTrack, Vector3.zero, Quaternion.identity);
                ob.transform.parent = blueMusicTrack.transform;
                ob.transform.localPosition = v;
                ob.transform.localEulerAngles = Vector3.zero;
            }
        }

    }

    public void DeleteTrack()
    {
        //bic.DestroyMyself(); //TODO��Ҫ�ģ�����tag���߱��ʲôɾ����Ϊitem���кܶ���
        GameObject[] lastTrack = GameObject.FindGameObjectsWithTag("Track");
        foreach(GameObject ob in lastTrack)
        {
            Destroy(ob);
        }
    }



    //ѡ�������Ԥ���붯̬��ʧ

}
