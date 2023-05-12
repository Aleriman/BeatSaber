using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision x)
    {
        if (x.gameObject.CompareTag("Left"))
        {
            GetComponentInParent<Cube>().CollisionDetected(false);
        }
        else if(x.gameObject.CompareTag("Right"))
        {
            GetComponentInParent<Cube>().CollisionDetected(true);
        }
    }
}
