using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesManager : MonoBehaviour
{

    public GameObject lines;
    public Vector2 whereToSpawn;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Lines")
        {
            print("line se fue");
            Instantiate(lines, whereToSpawn, lines.transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lines")
        {
            print("line entro");
        }
       
    }


}
