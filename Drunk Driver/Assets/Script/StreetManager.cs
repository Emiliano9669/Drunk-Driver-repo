using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetManager : MonoBehaviour
{

    public GameObject street;
    public Vector3 whereToSpawn;


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Street")
        {
            Instantiate(street, whereToSpawn, street.transform.rotation);
        }
    }
}
