using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        SteeringActive();
        
    }



    private void SteeringActive()
    {
        if (Input.GetKey(KeyCode.A))
        {
            GirarIzquierda();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            GirarDerecha();
        }
        else
        {
            Derecho();
        }
    }

    private void GirarIzquierda()
    {
        Quaternion izq = Quaternion.Euler(0, 0, 20);
        transform.rotation = izq;
    }

    private void GirarDerecha()
    {
        Quaternion der = Quaternion.Euler(0, 0, -20);
        transform.rotation = der;
    }

    private void Derecho()
    {
        Quaternion derecho = Quaternion.Euler(0, 0, 0);
        transform.rotation = derecho;
    }
}
