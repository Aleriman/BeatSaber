using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int health;
    public int puntuacion;
    public static GameManager manager;

    private void Start()
    {
        manager = this;
    }

    public  void UpdateScore()
    {
        puntuacion++;
        transform.GetChild(1).GetComponent<Text>().text = puntuacion +  " :Score" ;
    }
    public void TakeDamage()
    {
        health--;
        transform.GetChild(0).GetComponent<Text>().text = "Vidas: " + health;
    }
}
