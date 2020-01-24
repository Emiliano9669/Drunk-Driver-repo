using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvanzarCalles : MonoBehaviour
{
    private Vector3 direction = new Vector3(0, -1, 0);
    public float positionYLimit;

    // Update is called once per frame
    void Update()
    {
        float speed = ControladorJuego.actualStreetSpeed;
        transform.Translate(direction * Time.deltaTime * speed);
        if (transform.position.y < positionYLimit)
        {
            Destroy(this.gameObject);
        }
    }
}
