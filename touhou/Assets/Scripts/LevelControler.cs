using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControler : MonoBehaviour
{
    bool Controlador;

    //EFEITO DE BRIR CENA
    [SerializeField] Color cor;
    [SerializeField] SpriteRenderer spritecor;
    public float time2, maxtime2;

    //BOSSES
    public GameObject[] boss;
    GameObject Clone,Clone2,Clone3;
    public Transform pos;

    Boss main;
    public bool aviso = false;

    ChenControler Main;
    void Start()
    {
        
        Controlador = false;
        LevelManager.Manager += Iniciar;
        LevelManager.ManagerStop += parar;

        cor.a = 255;
        cor = Color.black;

        main = FindObjectOfType<Boss>();
        Main = FindObjectOfType<ChenControler>();
    }


   
    void Update()
    {

        if(Controlador == true)
        {
            controle();
            time2 += Time.deltaTime / 180;
            spritecor.color = cor;
            cor.a -= time2;
        }
    }

   
    void Iniciar()
    {
        Controlador = true;

    }
    void parar()
    {
        Controlador = false;
        Destroy(Clone);
        Destroy(Clone2);
        Destroy(Clone3);
       

    }
    void controle()
    {
        //PARTIDA = FAZ  O JOGO FAZER UM CLONE SO
        //AVISO = FAZ OS OBJETOS DO BOSS ANTERIOR SUMIREM
        if(main.partida == true)
        {
            if (main.Index == 0)
            {
                Clone = Instantiate(boss[0], pos.position, Quaternion.identity);
                main.partida = false;
                

            }
            if (main.Index == 1 )
            {
                if (aviso == false)
                {
                    //  Main.destrua();
                    Destroy(Clone);
                    Clone2 = Instantiate(boss[1], pos.position, Quaternion.identity);
                    main.partida = false;
                }
            }
            
            if (main.Index == 2)
            { 
                if(aviso == false)
                {
                    // Main.destrua();
                    Destroy(Clone2);
                    Clone3 = Instantiate(boss[2], pos.position, Quaternion.identity);
                    main.partida = false;
                }
            }
            
        }
       
    }

}
