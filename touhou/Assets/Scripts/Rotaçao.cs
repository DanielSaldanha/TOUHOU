using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotaçao : MonoBehaviour
{
    public GameObject obj;
    float z = 0;
    public float velocidadeRotacionatoria;

    public GameObject objGuardante;
    public float time, maxtime,maxtime2;
    void Start()
    {
        objGuardante.SetActive(false);
    }

  
    void Update()
    {
        Gira();
        time += Time.deltaTime;
        if(time >= maxtime)
        {
            objGuardante.SetActive(true);
        }
        if(time >= maxtime2)
        {
            objGuardante.SetActive(false);
        }
    }
    void Gira()
    {
        z = z + Time.deltaTime * velocidadeRotacionatoria;
       obj.transform.rotation = Quaternion.Euler(0, 0, z);
    }
}
