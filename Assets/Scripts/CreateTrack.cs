using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrack : MonoBehaviour
{
    public GameObject redTrack;
    public GameObject blueTrack;
    public GameObject musicTrack;

    public RedTrack rc;
    public Vector3 rcPosition;

    private enum PlayerTurn { red, blue };

    //public BasicItemController bic;

    // Start is called before the first frame update
    void Start()
    {
        rcPosition = rc.GetRedTrackPosition();
    }

    // Update is called once per frame
    void Update()
    {
        //rcTransform = rc.GetRedTrackTransform();
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
                    //�������Ҫ�޸����깫ʽ���⡿
                    //musicQueue[k].Enqueue(new Vector3(j - 3.5f + rcPosition.x, rcPosition.y, 0f)); 
                    musicQueue[k].Enqueue(new Vector3(j - 4.0f, 0f, 0f));
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
        //Object trackPrefab = Resources.Load("Prefabs/RedTrack");
        //if(trackPrefab!=null)
        //{
        //    GameObject redTrack = Instantiate(trackPrefab,trackTransform(), Quaternion.identity) as GameObject;          
        //}

        Vector3[] v3=TrackTransform(currentMusic);
        foreach(Vector3 v in v3)
        {
            //if(currentTurn==(int)PlayerTurn.red)
            //{
            //    GameObject ob = Instantiate(redTrack, v, Quaternion.identity);
            //    ob.transform.parent = musicTrack.transform;
            //}

            if (currentTurn == (int)PlayerTurn.red)
            {
                GameObject ob = Instantiate(redTrack, v, Quaternion.identity);
                ob.transform.parent = musicTrack.transform;
            }
            //else if(currentTurn==(int)PlayerTurn.blue)
            //{
            //    GameObject ob = Instantiate(blueTrack, v, Quaternion.identity);
            //    ob.transform.parent = musicTrack.transform;
            //}

            //hudCamera.transform.SetParent(hudSelectedObject.transform);
            //hudCamera.transform.localScale = Vector3.one;
            //hudCamera.transform.localPosition = Vector3.zero; // Or desired position
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
