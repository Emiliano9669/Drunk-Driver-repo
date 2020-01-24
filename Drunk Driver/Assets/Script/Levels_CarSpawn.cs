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
        float interval_InSec = BookOfLevels[actualLevel].spawnRatio;
        if (time > interval_InSec)
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

        SetVelocity(go);

        TryLuck_To_Spawn2Cars();
    }


    private void SetVelocity(GameObject go)
    {
        float velocity = BookOfLevels[ControladorJuego.level].carSpeed;
        Avanzar avanzar = go.GetComponent<Avanzar>();
        avanzar.speed = velocity;
    }

    private void TryLuck_To_Spawn2Cars()
    {
        if (WannaSpawnTwoCars())
            time = (BookOfLevels[ControladorJuego.level].spawnRatio) / 2;
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

    private bool WannaSpawnTwoCars()
    {
        return Random.Range(0, 5) == 4;
    }
}