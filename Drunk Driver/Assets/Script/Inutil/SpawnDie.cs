using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDie : MonoBehaviour
{
    [System.Serializable]
    public struct RangeToSpawn
    {
       public Vector2 alpha;
       public Vector2 beta;
    }


    public Transform objectToSpawn;   
    public RangeToSpawn rangeSpawn;
    public float timeLapse;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = timeLapse+1;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timeLapse)
        {
            time = 0;

            float x = GetRandomX();
            float y = GetRandomY();

            Instantiate(objectToSpawn, new Vector2(x,y), objectToSpawn.rotation);
        }

        
    }


    private float GetRandomX()
    {
        float alphaX = rangeSpawn.alpha.x;
        float betaX = rangeSpawn.beta.x;
        float x = Random.Range(alphaX, betaX);
        return x;
    }

    private float GetRandomY()
    {
        float alphaY = rangeSpawn.alpha.y;
        float betaY = rangeSpawn.beta.y;
        float y = Random.Range(alphaY, betaY);
        return y;
    }
}
