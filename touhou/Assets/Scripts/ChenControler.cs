using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChenControler : MonoBehaviour
{
    public Transform p1, p2, p3, p4, p5;
    public GameObject n1, n2, n3, n4, n5, n6, n7, n8, n9;
    GameObject Clone1, Clone2, Clone3, Clone4, Clone5, Clone6, Clone7, Clone8, Clone9;

    [SerializeField] int aleatoriedade;

    public float time, maxtime;
    public bool pare;

   public bool Controlador;


    LevelControler main;
    PlayerMoving mainP;
    void Start()
    {

        Controlador = true;
        LevelManager.Manager += Iniciar;
        LevelManager.ManagerStop += parar;

        main = FindObjectOfType<LevelControler>();
        mainP = FindObjectOfType<PlayerMoving>();
    }



    void Update()
    {

        if (Controlador == true)
        {
            time += Time.deltaTime;

            if (time > maxtime)
            {
                destrua();
                clonagem();
                time = 0;
            }
        }
        
        if(main.aviso == true)
        {
            destrua();
            main.aviso = false;
        }
        if(mainP.derrota == true)
        {
            destrua();
            mainP.derrota = false;
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
   public void destrua()
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
        destrua();
        Controlador = false;
    }

}
