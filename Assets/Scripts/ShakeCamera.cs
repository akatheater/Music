using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{

    public float shakeLevel = 3f;// �𶯷���
    public float setShakeTime = 0.5f;   // ��ʱ��
    public float shakeFps = 45f;    // �𶯵�FPS

    private bool isshakeCamera = false;// �𶯱�־
    private float fps;
    private float shakeTime = 0.0f;
    private float frameTime = 0.0f;
    private float shakeDelta = 0.005f;
    public Camera selfCamera;

    public void StartShake()
    {

        isshakeCamera = true;
        shakeTime = setShakeTime;
        fps = shakeFps;
        frameTime = 0.03f;
        shakeDelta = 0.005f;
    }

    public void StopShake()
    {
        selfCamera.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        isshakeCamera = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("shakeTime= " + shakeTime);
        if (isshakeCamera)
        {
            if (shakeTime > 0)
            {
                shakeTime -= Time.deltaTime;
                if (shakeTime <= 0)
                {
                    //enabled = false;
                    StopShake();
                }
                else
                {
                    frameTime += Time.deltaTime;

                    if (frameTime > 1.0 / fps)
                    {
                        frameTime = 0;
                        selfCamera.rect = new Rect(shakeDelta * (-1.0f + shakeLevel * Random.value), shakeDelta * (-1.0f + shakeLevel * Random.value), 1.0f, 1.0f);
                    }
                }
            }
        }
    }
}
