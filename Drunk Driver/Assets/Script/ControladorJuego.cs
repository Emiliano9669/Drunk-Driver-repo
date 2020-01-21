using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    public GameObject gameOverInterface;
    public GameObject introductionInterface;
    public int[] LevelsLimitsInSeconds;
    [HideInInspector]
    public static int level;
    

    private static GameObject intrfz;
    private bool leftIntro;

    // Start is called before the first frame update
    void Start()
    {
        intrfz = gameOverInterface;
        intrfz.SetActive(false);
        level = 0;
        bool didnt_see_introduction = PlayerPrefs.GetInt("introduction") == 0;
        if (didnt_see_introduction)
        {
            leftIntro = false;
            Time.timeScale = 0;
            introductionInterface.SetActive(true);
            PlayerPrefs.SetInt("introduction", 1);                              
        }
        else
            introductionInterface.SetActive(false);       
    }

    private void Update()
    {
        if (leftIntro == false && Input.touchCount > 0)
            StartGame();
        if (LevelsLimitsInSeconds[level] <= TimeManager.globalSceneTime)
            level++;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        leftIntro = true;
        introductionInterface.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        TimeManager.ResetearTiempo();
        SceneManager.LoadScene("Game");
    }

    public static void GameOver()
    {
        Time.timeScale = 0;
        intrfz.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("introduction", 0);
    }
}
