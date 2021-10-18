using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    Transform parent;
    Vector3 startPos;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        parent = transform.parent;
        startPos = transform.localPosition;
    }

    public void ResetPosition()
    {
        rb.velocity = Vector3.zero;
        transform.SetParent(parent);
        transform.localPosition = startPos;
        gameObject.SetActive(false);
    }
}
