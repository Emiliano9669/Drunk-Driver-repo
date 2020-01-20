using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetManager : MonoBehaviour
{   
    [System.Serializable]
    public struct StreetOfLevels
    {
        public GameObject[] road; // tiene que ser del mismo estilo!!! (importante)
    }
    
    public StreetOfLevels[] streetsOnLevels;
    public Vector3 whereToSpawn;


    private void OnTriggerExit2D(Collider2D other)
    {
        int actualLevel = ControladorJuego.level;
        if (other.gameObject.tag == "Street")
        {
            int randomNumber = Random.Range(0 ,streetsOnLevels[actualLevel].road.Length);
            GameObject calle = streetsOnLevels[actualLevel].road[randomNumber];
            Instantiate(calle, whereToSpawn, calle.transform.rotation);
        }
    }
}
