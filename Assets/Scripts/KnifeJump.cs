using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeJump : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float jumpForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Jump();
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
