using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text text;
    public static float globalSceneTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        globalSceneTime += Time.deltaTime;
        text.text = globalSceneTime.ToString("0");          
    }

    public static void ResetearTiempo()
    {
        globalSceneTime = 0;
    }
}
