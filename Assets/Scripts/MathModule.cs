using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathModule : MonoBehaviour
{
    public static float AngleFromTo(Vector3 origin, Vector3 target)
    {
        Vector3 direction = target - origin;

        // here I use variables b, a, c to mark the lenghts of an abstract right angle triangle that is created between the origin point, the cursor and the x line
        float b = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
        float c = direction.x;
        float a = direction.y;

        // this condition ensures we are not dividing by zero - Unity doesn't like it
        if (b > 0 && c != 0){

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

            return angle;
        }

        else
        {
            return 0;
        }
    }
}
