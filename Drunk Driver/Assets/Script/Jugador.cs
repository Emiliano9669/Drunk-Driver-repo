using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{


    public float speedRotation;
    public float maxSpeedMove;

    private float angleZ;
    private Vector3 left = Vector3.forward;
    private Vector3 right = Vector3.back;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        angleZ = AngleFormatted(transform.rotation.eulerAngles.z);

        if (Input.touchCount == 0)
            KeepGoingRight_Until(-20f);
        else
            KeepGoingLeft_Until(20f);

        transform.Translate(Vector3.left * angleZ/8 * Time.deltaTime,Space.World);
    }

    private void KeepGoingRight_Until(float limit)
    {
        if (angleZ > limit)
            transform.Rotate(right * Time.deltaTime * speedRotation);
    }

    private void KeepGoingLeft_Until(float limit)
    {
        if (angleZ < limit)
            transform.Rotate(left * Time.deltaTime * speedRotation);
    }

    private float AngleFormatted(float angle)
    {
        angle = (angle > 180) ? angle - 360 : angle;
        return angle;
    }
}
