using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetManager : MonoBehaviour
{   
    [System.Serializable]
    public struct StreetOfLevels
    {
        public GameObject[] road; // tiene que ser del mismo estilo!!! (importante) |ejemplo: si el nivel 2 es ciudad, no podes poner una carretera
    }
    
    public StreetOfLevels[] streetsOnLevels;

    private Vector3 whereToSpawn = new Vector3(0, 11.72f, 0);
  
    private void OnTriggerExit2D(Collider2D other)
    {
        int actualLevel = ControladorJuego.level;
        if (other.gameObject.tag == "Street")
        {
            int randomNumber = Random.Range(0 ,streetsOnLevels[actualLevel].road.Length);
            GameObject calle = streetsOnLevels[actualLevel].road[randomNumber];
            GameObject go =  Instantiate(calle, whereToSpawn, calle.transform.rotation);
        }
    }

}
