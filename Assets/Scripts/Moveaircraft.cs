using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAircraft : MonoBehaviour
{
    public float Speed = 5.0f;
    public float RotationSpeed = 100.0f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Rotate(0f, h * RotationSpeed * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward * v * Speed * Time.deltaTime);
    }
}
