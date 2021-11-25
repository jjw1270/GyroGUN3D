using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour
{
    public void gotoStartScene()
    {
        //시작화면으로 씬전환
        SceneManager.LoadScene("StartScene");
        //Debug.Log("MainMenuBTN");
    }

    public void playGame()
    {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(delayTime());
        //Debug.Log("PlayGame");
    }
    void serialBtn()
    {
        if (Serial.serial.isConnected())
        {
            Serial.serial.OnDataReceived += () =>
            {
                String read = Serial.serial.Read();
                if (read == "F")
                    playGame();
            };
        }
        //else;
        //Serial.serial.Connect();
    }

    public void endGame()
    {
        Application.Quit();
        //Debug.Log("Quit");
    }

    public void howToPlay()
    {
        GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(true);
    }
    public void howToPlayReturn()
    {
        //Debug.Log("Return");
        GameObject.Find("HowToPlayTab").SetActive(false);
    }

    IEnumerator delayTime()
    {
        yield return new WaitForSeconds(1);
        LoadingScene.LoadScene("MainScene");
    }
}
