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
        public GameObject[] spawnPoints;
    }



    /*
     Variables:
     Spawn ratio/per sec
     car speed
     types of cars
     spawn points
         */
    private float time;
    public LevelForCar[] BookOfLevels;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int actualLevel = ControladorJuego.level;
        if (time > BookOfLevels[actualLevel].spawnRatio)
        {
            time = 0;
            DoWork_ToSpawnEnemy();
        }
    }


    public void DoWork_ToSpawnEnemy()
    {
        GameObject go = Random_Model_Of_ActualLevel();
        Vector3 position = Random_Spawn_Location();
        go = Instantiate(go, position, go.transform.rotation);
        Avanzar avanzar = go.GetComponent<Avanzar>();
        avanzar.speed = BookOfLevels[ControladorJuego.level].carSpeed;
    }

    private GameObject Random_Model_Of_ActualLevel()
    {
        int actualLevel = ControladorJuego.level;
        int cantidad_Modelos = BookOfLevels[actualLevel].models.Length;
        int randomValue = Random.Range(0, cantidad_Modelos);
        return BookOfLevels[actualLevel].models[randomValue];
    }

    private Vector3 Random_Spawn_Location()
    {
        int actualLevel = ControladorJuego.level;
        int maxRndm = BookOfLevels[actualLevel].spawnPoints.Length;
        int random = Random.Range(0, maxRndm);
        return BookOfLevels[actualLevel].spawnPoints[random].transform.position;
    }

}
