using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerAndEndGameHandler : MonoBehaviour
{
    float timeLeft;
    [SerializeField] TMP_Text tempoTexto;
    float minutos;
    float segundos;
    public GameObject painelGameOver;
    [SerializeField] TMP_Text gameOverScoreText;
    public static bool gameover = false;

    // Use this for initialization
    void Start()
    {
        timeLeft = PlayerPrefs.GetFloat("GameSessionTime") * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameover)
            timeLeft -= Time.deltaTime;

        minutos = Mathf.Floor(timeLeft / 60);
        segundos = Mathf.Floor(timeLeft % 60);
        if (timeLeft <= 0)
        {
            GameOver();
        }
        tempoTexto.text = System.String.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GameOver()
    {
        gameover = true;
        gameOverScoreText.text = "Score : " + FindObjectOfType<ScoreHandler>().score;
        painelGameOver.SetActive(true);
    }
}
