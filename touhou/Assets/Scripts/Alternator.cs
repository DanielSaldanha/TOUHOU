using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alternator : MonoBehaviour
{
    public float time, maxtime;
    bool controlador;

    public GameObject obj1, obj2;
    void Start()
    {
        controlador = true;
    }

 
    void Update()
    {
        time += Time.deltaTime;
        if (time >= maxtime)
        {
            controlador = !controlador;
            time = 0;
        }
        obj1.SetActive(controlador);
        obj2.SetActive(!controlador);
    }
}
