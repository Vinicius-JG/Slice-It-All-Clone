using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCut : MonoBehaviour
{
    Rigidbody rb;
    RigidbodyConstraints normalConstraints;
    RigidbodyConstraints cuttingConstraints;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        normalConstraints = rb.constraints;
        cuttingConstraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destructible"))
        {
            other.GetComponent<Destructible>().Cut();
            EnterCutState();
        }
    }

    void EnterCutState()
    {
        rb.constraints = cuttingConstraints;
    }

    public void ExitCutState()
    {
        rb.constraints = normalConstraints;
    }
}
