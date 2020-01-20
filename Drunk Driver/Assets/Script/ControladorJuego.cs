using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    public GameObject gameOverInterface;

    private static GameObject intrfz;


    // Start is called before the first frame update
    void Start()
    {
        intrfz = gameOverInterface;
        intrfz.SetActive(false);       
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public static void GameOver()
    {
        //alguna explosion
        Time.timeScale = 0;
        intrfz.SetActive(true);
    }
}
