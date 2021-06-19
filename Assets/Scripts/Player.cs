using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
