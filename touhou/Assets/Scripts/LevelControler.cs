using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControler : MonoBehaviour
{
    public Transform p1, p2, p3, p4, p5;
    public GameObject n1, n2, n3, n4, n5;
    GameObject Clone1, Clone2, Clone3, Clone4, Clone5;    

   [SerializeField] int aleatoriedade;

    public float time, maxtime;
    public bool pare;

    Main main;

    void Start()
    {
        Clone5 = Instantiate(n5, p5.position, Quaternion.identity);
        pare = false;
    }


   
    void Update()
    {
        time += Time.deltaTime;
        /*
        if(time >= 12)
        {
            pare = true;
            if (pare == true)
            {
                main.firerate = 10;
                pare = false;
            }
        }
        */
        if(time > maxtime)
        {
            Destroy(Clone1);
            Destroy(Clone2);
            Destroy(Clone3);
            Destroy(Clone4);
            Destroy(Clone5);
            clonagem();
            time = 0;
        }
       
    }

    void clonagem()
    {

        aleatoriedade = Random.Range(1, 6);
        if (aleatoriedade == 1)
        {
            Clone1 = Instantiate(n1, p1.position, Quaternion.identity);
        }
        else if (aleatoriedade == 2)
        {
            Clone2 = Instantiate(n2, p2.position, Quaternion.identity);
        }
        else if (aleatoriedade == 3)
        {
            Clone3 = Instantiate(n3, p3.position, Quaternion.identity);
        }
        else if (aleatoriedade == 4)
        {
            Clone4 = Instantiate(n4, p4.position, Quaternion.identity);
        }
        else if (aleatoriedade == 5)
        {
            Clone5 = Instantiate(n5, p5.position, Quaternion.identity);
        }
       
        



        /*
        Clone1 = Instantiate(n1, p1.position, Quaternion.identity);
        Clone2 = Instantiate(n2, p2.position, Quaternion.identity);
        Clone3 = Instantiate(n3, p3.position, Quaternion.identity);
        Clone4 = Instantiate(n4, p4.position, Quaternion.identity);
        Clone5 = Instantiate(n5, p5.position, Quaternion.identity);
        */
    }

}
