using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 10;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target, Vector3.up);
            Vector3 dir = (target.position - transform.position);
            dir.Normalize();
            dir *= moveSpeed;
            float yVelocity = rb.linearVelocity.y;
            dir.y = yVelocity;
            rb.linearVelocity = dir;
            
        }
    }
}
