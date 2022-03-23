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
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));  //ȭ�� �ʱ�ȭ
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
        // x�� ����
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

        // y�� - 50 ~ 50 ����
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
                case TouchPhase.Began: //�հ����� ȭ���� ��ġ�ϴ� ����
                    if (Time.time - lastTouchTime < doubleTouchDelay) //������ġ ����
                    {
                        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));  //ȭ�� �ʱ�ȭ
                    }
                    break;

                case TouchPhase.Moved:   //�հ����� ȭ�� ������ ��ġ�� ���·� �̵��ϰ� �ִ� ����
                    break;

                case TouchPhase.Ended:   //�հ����� ȭ�鿡�� ������ ����
                    lastTouchTime = Time.time;
                    break;
            }
        }

        if (clearCam)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));  //ȭ�� �ʱ�ȭ
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