using UnityEngine;

public class StickySlowdown : MonoBehaviour
{
    public string stickyTag = "StickySurface";
    public float stickyLinearDamping = 20f;
    public float stickyAngularDamping = 20f;

    private Rigidbody rb;
    private float originalLinearDamping;
    private float originalAngularDamping;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        originalLinearDamping = rb.linearDamping;
        originalAngularDamping = rb.angularDamping;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(stickyTag))
        {
            rb.linearDamping = stickyLinearDamping;
            rb.angularDamping = stickyAngularDamping;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(stickyTag))
        {
            rb.linearDamping = originalLinearDamping;
            rb.angularDamping = originalAngularDamping;
        }
    }
}
