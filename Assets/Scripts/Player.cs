using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {   
        RotateTowardsCursor();
    }

    void RotateTowardsCursor()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 origPos = transform.position;
        float angle = MathModule.AngleFromTo(origPos, mousePos);
        rb.SetRotation(angle);
    }

    public void Shoot()
    {
        animator.SetTrigger("Shoot");
    }
}
