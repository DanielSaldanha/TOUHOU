using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cenario : MonoBehaviour
{
    public  float time, maxtime;
    public float time2, maxtime2;
    GameObject Clone;
    public GameObject obj;
    public Transform pos;
    void Start()
    {
        time = maxtime;
    }

   
    void Update()
    {
        time += Time.deltaTime;
        if(time >= maxtime)
        {

            Destroy(Clone);
            Clone = Instantiate(obj, pos.position, Quaternion.identity);
            time = 0;
        }
        time2 += Time.deltaTime;
        if (time2 >= maxtime2)
        {
            
            time2 = 0;
            
        }
    }
}
