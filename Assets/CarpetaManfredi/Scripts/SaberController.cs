using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberController : MonoBehaviour
{
    public bool blue;
    public int angle;
    Vector3 lastPosition;


    private void FixedUpdate()
    {
        Vector3 direction = transform.position - lastPosition;

        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x < 0)
            {
                angle = 2;
            }
            else
            {
                angle = 3;
            }
        }
        else
        {
            if (direction.y < 0)
            {
                angle = 0;
            }
            else
            {
                angle = 1;
            }
        }



        lastPosition = transform.position;

    }
}
