using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBot : MonoBehaviour
{
    public float speed;
    public Vector3 direction;


    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(direction * Time.deltaTime * speed);
    }

}
