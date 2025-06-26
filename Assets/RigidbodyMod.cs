using UnityEngine;

public class RigidbodyMod : MonoBehaviour
{
    private Rigidbody _rb;
    private float gravityDirection = -1f;
    public float gravityStrength = 20f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gravityDirection *= -1f;
        }
    }

    void FixedUpdate()
    {
        _rb.AddForce(Vector3.up * gravityDirection * gravityStrength, ForceMode.Acceleration);
    }
}

