using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float accelerationPower;
    public float steeringPower;
    private float steeringAmount, speed, direction;

    public float fuerza;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        steeringAmount = 0;
        direction = 1;
        
    }



    private void FixedUpdate()
    {
        steeringAmount = TouchSteering(); // - Input.GetAxis("Horizontal")      
        rbRotation_Handled();
        MagicMovement_Handled();
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

        if (steeringAmount >= 1)
            steeringAmount = 1;
        else if (steeringAmount <= -1)
            steeringAmount = -1;
        return steeringAmount;
    }

    private void rbRotation_Handled()
    {
        if (rb.rotation <= 20 && rb.rotation >= -20)
        {
            rb.rotation += steeringAmount * steeringPower * direction;  // aca podemos poner el limite determinado para doblar (ejemplo: de -20 a 20)
        }
        else
        {
            if (rb.rotation >= 20)
                rb.rotation = 20;
            else
                rb.rotation = -20;
        }
    }

    private void MagicMovement_Handled()
    {
        float angulo = AngleFormatted(transform.rotation.eulerAngles.z);
        rb.AddForce(Vector2.left * Time.deltaTime * angulo * fuerza);
    }




    public float AngleFormatted(float angle)
    {
        angle = (angle > 180) ? angle - 360 : angle;
        return angle;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string nameObject = collision.transform.tag;
        if (nameObject == "CarBot" || nameObject == "Border")
        {
            GameOver();
        }
    }

    public void GameOver()
    {

    }
}
