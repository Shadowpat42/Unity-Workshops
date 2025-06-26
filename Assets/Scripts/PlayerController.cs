using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 180.0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * rotationSpeed * Time.deltaTime, 0f);

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(h, 0f, v).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.Self);
    }
}
