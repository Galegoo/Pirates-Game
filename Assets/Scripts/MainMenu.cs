using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    float gameSessionTime;
    float enemieSpawnRateTime;
    public void PlayGame()
    {
        PlayerPrefs.GetFloat("GameSessionTime", gameSessionTime);
        PlayerPrefs.GetFloat("EnemiesSpawnRate", enemieSpawnRateTime);

        if (gameSessionTime == 0)
        {
            gameSessionTime = 2;
            PlayerPrefs.SetFloat("GameSessionTime", gameSessionTime);
        }

        if (enemieSpawnRateTime == 0)
        {
            enemieSpawnRateTime = 5;
            PlayerPrefs.SetFloat("EnemiesSpawnRate", enemieSpawnRateTime);
        }


        SceneManager.LoadScene("Game");
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
