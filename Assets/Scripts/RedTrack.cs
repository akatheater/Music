using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTrack : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public Vector3 GetRedTrackPosition()
    {
        return this.gameObject.transform.position;
    }

    public Vector3 GetRedTrackRotation()
    {
        return this.gameObject.transform.eulerAngles;
    }

}
