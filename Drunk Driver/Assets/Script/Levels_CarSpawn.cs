using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels_CarSpawn : MonoBehaviour
{
    [System.Serializable]
    public struct LevelForCar
    {
        public float spawnRatio;
        public float carSpeed;
        public GameObject[] models;
    }



    /*
     Variables:
     Spawn ratio/per sec
     car speed
     types of cars
         */

    public LevelForCar[] BookOfLevels;
    public int[] LevelsLimitsInSeconds;

    private float time;
    private int actualLevel;
    public GameObject[] spawn;


    // Start is called before the first frame update
    void Start()
    {
        actualLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > BookOfLevels[actualLevel].spawnRatio)
        {
            time = 0;
            GameObject go = Random_Model_Of_ActualLevel();           
            Vector3 position = Random_Spawn_Location();
            go = Instantiate(go, position, go.transform.rotation);
            Avanzar avanzar = go.GetComponent<Avanzar>();
            avanzar.speed = BookOfLevels[actualLevel].carSpeed;
        }
    }

    private GameObject Random_Model_Of_ActualLevel()
    {
        int cantidad_Modelos = BookOfLevels[actualLevel].models.Length;
        int randomValue = Random.Range(0, cantidad_Modelos);
        return BookOfLevels[actualLevel].models[randomValue];
    }

    private Vector3 Random_Spawn_Location()
    {
        int random = Random.Range(0, 9);
        return spawn[random].transform.position;
    }

}
