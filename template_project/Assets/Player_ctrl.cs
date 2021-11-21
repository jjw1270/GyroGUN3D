using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ctrl : MonoBehaviour
{
    public static bool fire;
    public static bool clearCam;

    public static Vector3 angleGyro;

    private float lastTouchTime;
    private const float doubleTouchDelay = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        lastTouchTime = Time.time;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));  //화면 초기화
    }

    // Update is called once per frame
    void Update()
    {
        serialBtn();

        angleGyro.x = -Input.gyro.rotationRateUnbiased.x;
        angleGyro.y = -Input.gyro.rotationRateUnbiased.y;
        //angleGyro.z = Input.gyro.rotationRateUnbiased.z;
        transform.Rotate(angleGyro.x, angleGyro.y, 0);

        /*
        // x축 제한
        if (transform.rotation.eulerAngles.x < -90.0f)
        {
            Vector3 TunnelRotation = transform.rotation.eulerAngles;
            TunnelRotation.x = -80.0f;
            transform.rotation = Quaternion.Euler(TunnelRotation);
        }
        else if (transform.rotation.eulerAngles.x > 90.0f)
        {
            Vector3 TunnelRotation = transform.rotation.eulerAngles;
            TunnelRotation.x = 80.0f;
            transform.rotation = Quaternion.Euler(TunnelRotation);
        }

        // y축 - 50 ~ 50 제한
        if (transform.rotation.eulerAngles.y < -50.0f)
        {
            Vector3 TunnelRotation = transform.rotation.eulerAngles;
            TunnelRotation.y = -50.0f;
            transform.eulerAngles = TunnelRotation;
        }
        else if (transform.rotation.eulerAngles.y > 50.0f)
        {
            Vector3 TunnelRotation = transform.eulerAngles;
            TunnelRotation.y = 50.0f;
            transform.eulerAngles = TunnelRotation;
        }*/


        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began: //손가락이 화면을 터치하는 순간
                    if (Time.time - lastTouchTime < doubleTouchDelay) //더블터치 판정
                    {
                        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));  //화면 초기화
                    }
                    break;

                case TouchPhase.Moved:   //손가락이 화면 위에서 터치한 상태로 이동하고 있는 상태
                    break;

                case TouchPhase.Ended:   //손가락이 화면에서 떨어진 순간
                    lastTouchTime = Time.time;
                    break;
            }
        }

        if (clearCam)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));  //화면 초기화
            clearCam = false;
        }
    }

    void serialBtn()
    {
        if (Serial.serial.isConnected())
        {
            Serial.serial.OnDataReceived += () =>
            {
                String read = Serial.serial.Read();
                if (read == "F")
                    fire = true;
                if (read == "I")
                    clearCam = true;
            };
        }
        //else;
            //Serial.serial.Connect();
    }
}