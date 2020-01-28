using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    public GameObject gameOverInterface, introductionInterface;
    public int[] levels_Limits_InSeconds;

    [HideInInspector]
    public static int level;
    [HideInInspector]
    public static float actualStreetSpeed;

    private bool leftIntro;
    private MusicManager music;

    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        actualStreetSpeed = 3;
        gameOverInterface.SetActive(false);
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
        QuarantineCode();

        bool itsTimeToLevelUp = levels_Limits_InSeconds[level] <= TimeManager.globalSceneTime;       
        if (itsTimeToLevelUp)
            DoThingsToLevelUp();
    }

    public void DoThingsToLevelUp()
    {
        level++;
        actualStreetSpeed = actualStreetSpeed + 0.35f;
    }


    public void QuarantineCode() // dont remember what is this but works
    {
        bool introAlreadyPassed = (leftIntro == false); //dont know exactly what is this
        bool screenIsTouched = (Input.touchCount > 0);
        if (introAlreadyPassed && screenIsTouched)
            StartGame();
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
        music.NoFilterForAudio();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverInterface.SetActive(true);
        music.ActivateLowFrequencyAudio();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("introduction", 0);
    }
}
