using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avanzar : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public float positionYLimit;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
        if (transform.position.y < positionYLimit)
        {
            Destroy(this.gameObject);
        }
    }
}
