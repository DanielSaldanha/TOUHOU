using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControler : MonoBehaviour
{
    public Transform p1, p2, p3, p4, p5;
    public GameObject n1, n2, n3, n4, n5,n6,n7,n8,n9;
    GameObject Clone1, Clone2, Clone3, Clone4, Clone5, Clone6, Clone7, Clone8, Clone9;    

   [SerializeField] int aleatoriedade;

    public float time, maxtime;
    public bool pare;

    bool Controlador;

    //EFEITO DE BRIR CENA
    [SerializeField] Color cor;
    [SerializeField] SpriteRenderer spritecor;
    public float time2, maxtime2;

    void Start()
    {
        
        Controlador = false;
        LevelManager.Manager += Iniciar;
        LevelManager.ManagerStop += parar;

        cor.a = 255;
        cor = Color.black;
    }


   
    void Update()
    {

        if(Controlador == true)
        {
            time += Time.deltaTime;

            if (time > maxtime)
            {
                destrua();
                clonagem();
                time = 0;
            }
        }
        if(Controlador == true)
        {
            time2 += Time.deltaTime / 180;
            spritecor.color = cor;
            cor.a -= time2;
        }
       

    }

    void clonagem()
    {

        aleatoriedade = Random.Range(1, 10);
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
        else if (aleatoriedade == 6)
        {
            Clone6 = Instantiate(n6, p5.position, Quaternion.identity);
        }
        else if (aleatoriedade == 7)
        {
            Clone7 = Instantiate(n7, p5.position, Quaternion.identity);
        }
        else if (aleatoriedade == 8)
        {
            Clone8 = Instantiate(n8, p5.position, Quaternion.identity);
        }
        else if (aleatoriedade == 9)
        {
            Clone9 = Instantiate(n9, p2.position, Quaternion.identity);
        }





        /*
        Clone1 = Instantiate(n1, p1.position, Quaternion.identity);
        Clone2 = Instantiate(n2, p2.position, Quaternion.identity);
        Clone3 = Instantiate(n3, p3.position, Quaternion.identity);
        Clone4 = Instantiate(n4, p4.position, Quaternion.identity);
        Clone5 = Instantiate(n5, p5.position, Quaternion.identity);
        */
    }
    void destrua()
    {
        Destroy(Clone1);
        Destroy(Clone2);
        Destroy(Clone3);
        Destroy(Clone4);
        Destroy(Clone5);
        Destroy(Clone6);
        Destroy(Clone7);
        Destroy(Clone8);
        Destroy(Clone9);
    }
    void Iniciar()
    {
        Controlador = true;

    }
    void parar()
    {
        Controlador = false;
    }

}
