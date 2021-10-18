using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    Transform target;
    Vector3 offset;
    Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, 0.25f);
    }
}
