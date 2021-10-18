using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : MonoBehaviour
{
    Rigidbody rb;
    bool slowState;
    bool lastFrameIsBladeForward;
    bool input;
    [SerializeField]
    float fastSpeed;
    [SerializeField]
    float slowSpeed;
    [SerializeField]
    float movingSpeed;
    [SerializeField]
    float knockbackForce;
    bool moving;
    KnifeCut knifeCut;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        knifeCut = GetComponent<KnifeCut>();
    }

    private void LateUpdate()
    {
        lastFrameIsBladeForward = IsBladeForward();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moving = true;
            input = true;
            knifeCut.ExitCutState();
            GoFast();
        }

        if (lastFrameIsBladeForward != IsBladeForward())
            OnBladePosChange();
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            if (slowState)
                rb.angularVelocity = -transform.forward * slowSpeed;
            else
                rb.angularVelocity = -transform.forward * fastSpeed;

            rb.velocity = new Vector3(movingSpeed * Time.fixedDeltaTime, rb.velocity.y, rb.velocity.z);
        }
    }

    bool IsBladeForward()
    {
        return transform.eulerAngles.z >= 220f && transform.eulerAngles.z <= 360f;
    }

    void GoFast()
    {
        slowState = false;
    }

    void GoSlow()
    {
        slowState = true;
    }

    void OnBladePosChange()
    {
        if (IsBladeForward())
            OnBladeForward();
        else
            OnBladeBackward();
    }

    void OnBladeForward()
    {
        if (!input)
            GoSlow();
    }

    void OnBladeBackward()
    {
        input = false;
        GoFast();
    }

    void KnockBack()
    {
        rb.AddForce(knockbackForce * -Vector3.right + Vector3.up);
    }

    private void OnCollisionEnter(Collision other)
    {
        moving = false;

        if (other.collider.CompareTag("Rigid"))
            KnockBack();
    }
}
