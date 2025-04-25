using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OptionsHandler : MonoBehaviour
{
    [SerializeField] Slider enemieSpawnRateSlider;
    [SerializeField] Slider gameSessionSlider;

    public float gameSessionTime;
    public float enemieSpawnRateTime;

    [SerializeField] TMP_Text gameSessionTimeText;
    [SerializeField] TMP_Text enemieSpawnRateTimeText;

    [SerializeField] TMP_Text WarnText;
    // Start is called before the first frame update
    void Start()
    {
        enemieSpawnRateSlider.maxValue = 10;
        gameSessionSlider.maxValue = 5;
        enemieSpawnRateSlider.value = PlayerPrefs.GetFloat("EnemiesSpawnRate");
        gameSessionSlider.value = PlayerPrefs.GetFloat("GameSessionTime");
    }

    // Update is called once per frame
    void Update()
    {
        gameSessionTime = gameSessionSlider.value;
        gameSessionTimeText.text = gameSessionTime.ToString ("F1");

        

        enemieSpawnRateTime = enemieSpawnRateSlider.value;
        enemieSpawnRateTimeText.text = enemieSpawnRateTime.ToString("F1");

       
    }
    public void MainMenuFromOptions()
    {
        if(enemieSpawnRateTime > 0 && gameSessionTime > 0)
        {
            PlayerPrefs.SetFloat("GameSessionTime", gameSessionTime);
            PlayerPrefs.SetFloat("EnemiesSpawnRate", enemieSpawnRateTime);
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            WarnText.gameObject.SetActive(true);
        }
    }
}
