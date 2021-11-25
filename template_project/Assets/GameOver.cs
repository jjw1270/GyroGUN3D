using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Image backGroundImage;
    public Text gameOverText;
    public Text totalScore;
    public Text playTime;
    public Button mainMenuButton;
    public Text playTimerOnPlay;
    public Text scoreOnplay;

    public static int score = 0;
    public static float timer = 0.0f;


    private Color color;

    private void Start()
    {
        timer = 0f;
        score = 0;
    }


    void Update()
    {
        timer += Time.deltaTime;

        playTimerOnPlay.text = Mathf.RoundToInt(timer).ToString();
        scoreOnplay.text = score.ToString();
        if (PlayerHP.gameOver)
        {
            if (AudioListener.volume > 0.000001f)
            {
                AudioListener.volume -= Time.deltaTime * 0.3f;
                color += new Color(1, 1, 1, Time.deltaTime * 0.3f);
                backGroundImage.color = color;
                //Debug.Log("FADEOUT  " + AudioListener.volume);
            }
            if (AudioListener.volume < 0f)
            {
                playTimerOnPlay.gameObject.SetActive(false);
                scoreOnplay.gameObject.SetActive(false);
                AudioListener.volume = 0;
                PlayerHP.gameOver = false;
                Debug.Log("GAMEOVER");
                gameOverText.gameObject.SetActive(true);
                totalScore.gameObject.SetActive(true);
                totalScore.text = "Score : " + score.ToString();
                Debug.Log(score);
                playTime.gameObject.SetActive(true);
                playTime.text = "PlayTime : " + Mathf.RoundToInt(timer).ToString() + "s";
                mainMenuButton.gameObject.SetActive(true);
            }
        }
    }
}