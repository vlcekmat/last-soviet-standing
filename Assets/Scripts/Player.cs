using System.Collections;
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

        Vector3 direction = mousePos - origPos;

        // here I use variables b, a, c to mark the lenghts of an abstract right angle triangle that is created between the origin point, the cursor and the x line
        float b = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
        float a = direction.y;
        float c = direction.x;

        bool overRightAngle = false;
        if(a <= 0)
        {
            overRightAngle = true;
        }

        float angle = Mathf.Acos((c*c + b*b - a*a) / (2*c*b)) / Mathf.PI * 180 - 90;

        if (overRightAngle)
        {
            angle = angle + 2 * (90 - angle);
        }

        // Debug.LogFormat("b = {0}; a = {1}; c = {2}; angle = {3}", b, a, c, angle);

        rb.SetRotation(angle);

     }
 

}
