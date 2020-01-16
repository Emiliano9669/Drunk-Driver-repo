using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    public float accelerationPower;
    public float steeringPower;
    private float steeringAmount, speed, direction;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        steeringAmount = 0;
    }



    private void FixedUpdate()
    {
       steeringAmount = TouchSteering(); // - Input.GetAxis("Horizontal")
       speed = 1  * accelerationPower; //esto tendria que ser siempre 1  # Input.GetAxis("Vertical") #
       direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up))); //esto tendria que ser siempre 1

        rbRotation_Handled();
        //rb.rotation += steeringAmount * steeringPower  * direction; // * rb.velocity.magnitude

        rb.AddRelativeForce(Vector2.up * speed);
        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
    }


    private float TouchSteering()
    {
        if (Input.touchCount > 0)
        {
            steeringAmount += 0.1f;
        }
        else
        {
            steeringAmount -= 0.1f;
        }

        if (steeringAmount > 1)
            steeringAmount = 1;
        else if (steeringAmount < -1)
            steeringAmount = -1;
        return steeringAmount;
    }

    private void rbRotation_Handled()
    {
        if (rb.rotation <= 20 && rb.rotation >= -20)
        {
            rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;  // aca podemos poner el limite determinado para doblar (ejemplo: de -20 a 20)
        }
        else
        {
            if (rb.rotation >= 20)
                rb.rotation = 20;
            else
                rb.rotation = -20;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string nameObject = collision.transform.tag;
        if (nameObject == "CarBot"  || nameObject == "Border")
        {
            GameOver();
        }
    }

    public void GameOver()
    {

    }

 


}
