using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Material materialRed;
    public bool blue;
    public int angle;
    public float speed;

    private void Start()
    {
        for(int i = 0; i<transform.childCount; i++)
        {
            if(i != angle)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            else if (!blue)
            {
                transform.GetChild(i).GetComponent<MeshRenderer>().material = materialRed;
            }
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.back * speed);
    }
    //Con el guion bajo diferenciamos de cual es un parametro y cual una variable
    public void CollisionDetected(bool _blue)
    {
        if(_blue == blue)
        {
            GameManager.manager.UpdateScore();
        }
        else
        {
            GameManager.manager.TakeDamage();
        }
        Destroy(gameObject);
        GetComponent<Collider>().enabled = false;
    }

    private void OnCollisionEnter(Collision x)
    {
        if (x.gameObject.CompareTag("Left") || x.gameObject.CompareTag("Right"))
        {
            if (x.gameObject.GetComponent<SaberController>().angle == angle)
                CollisionDetected(x.gameObject.GetComponent<SaberController>().blue);
            else
            {
                GameManager.manager.TakeDamage();
                Destroy(gameObject);
            }
           
        }
    }
}
