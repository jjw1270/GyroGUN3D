using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArduinoSerialAPI;
using System;

public class Serial : MonoBehaviour
{

    public static SerialHelper serial;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            serial = SerialHelper.CreateInstance("COM2", 9600);

            serial.setFixedLengthBasedStream(1);
            //serial.setTerminatorBasedStream("\n");
            serial.Connect();

            serial.OnConnected += () => {
                Debug.Log("Connected");
            };

            serial.OnConnectionFailed += () => {
                Debug.Log("Failed");

            };

            /*serial.OnDataReceived += () => {
                Debug.Log(serial.Read());
            };*/
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }
    void OnDestroy()
    {
        if (serial != null)
            serial.Disconnect();
    }
}