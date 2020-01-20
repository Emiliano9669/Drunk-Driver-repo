using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    public GameObject gameOverInterface;
    [HideInInspector]
    public static int level;
    public int[] LevelsLimitsInSeconds;

    private static GameObject intrfz;


    // Start is called before the first frame update
    void Start()
    {
        intrfz = gameOverInterface;
        intrfz.SetActive(false);
        level = 0;
    }

    private void Update()
    {
        if (LevelsLimitsInSeconds[level] <= TimeManager.globalSceneTime)
            level++;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        TimeManager.ResetearTiempo();
        SceneManager.LoadScene("Game");
    }

    public static void GameOver()
    {
        //alguna explosion
        Time.timeScale = 0;
        intrfz.SetActive(true);
    }
}
