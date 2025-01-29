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
    GameObject Clone,Clone2,Clone3,Clone4,Clone5;
    public Transform pos;

    Boss main;
    PlayerMoving player;
    public bool aviso = false;

    ChenControler Main;


    //MUSICAS
    public GameObject themeChen, themeMariza, themeYuuma;
   public GameObject CloneSongs;

    //CENARIO
    public GameObject n1,cntrl;
    void Start()
    {
        
        Controlador = false;
        LevelManager.Manager += Iniciar;
        LevelManager.ManagerStop += parar;

        cor.a = 255;
        cor = Color.black;

        main = FindObjectOfType<Boss>();
        Main = FindObjectOfType<ChenControler>();
        player = FindObjectOfType<PlayerMoving>();
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
        Destroy(Clone4);
        Destroy(Clone5);


    }
    void controle()
    {
        //PARTIDA = FAZ  O JOGO FAZER UM CLONE SO
        //AVISO = FAZ OS OBJETOS DO BOSS ANTERIOR SUMIREM
        if(main.partida == true)
        {
            if (main.Index == 0)
            {
                CloneSongs = Instantiate(themeMariza);
                if(player.SpriteControler == true)
                {
                    Clone = Instantiate(boss[0], pos.position, Quaternion.identity);
                    main.partida = false;
                }
                if (player.SpriteControler == false)
                {
                    Clone = Instantiate(boss[5], pos.position, Quaternion.identity);
                    main.partida = false;
                }



            }
            if (main.Index == 1 )
            {
                if (aviso == false)
                {
                    Destroy(CloneSongs);
                    CloneSongs = Instantiate(themeMariza);

                    //  Main.destrua();
                    Destroy(Clone);
                    Clone = Instantiate(boss[1], pos.position, Quaternion.identity);
                    main.partida = false;
                }
            }
            
            if (main.Index == 2)
            { 
                if(aviso == false)
                {
                    Destroy(CloneSongs);
                    CloneSongs = Instantiate(themeChen);
                    // Main.destrua();
                    Destroy(Clone);
                    Clone2 = Instantiate(boss[2], pos.position, Quaternion.identity);
                    main.partida = false;
                }
            }
            if (main.Index == 3)
            {
                if (aviso == false)
                {
                    Destroy(CloneSongs);
                    CloneSongs = Instantiate(themeYuuma);
                    // Main.destrua();
                    Destroy(Clone2);
                    Clone3 = Instantiate(boss[3], pos.position, Quaternion.identity);
                    main.partida = false;

                    //cenario
                    n1.SetActive(false);
                    Clone = Instantiate(cntrl);
                }
            }
            
            if (main.Index == 4)
            {
                if (aviso == false)
                {
                    Destroy(CloneSongs);
                    CloneSongs = Instantiate(themeYuuma);
                    // Main.destrua();
                    Destroy(Clone3);
                    Clone4 = Instantiate(boss[4], pos.position, Quaternion.identity);
                    main.partida = false;

                    //cenario
                    n1.SetActive(false);
                    Clone = Instantiate(cntrl);
                }
            }
            if (main.Index == 5)
            {
                if (aviso == false)
                {
                    Destroy(CloneSongs);
                    CloneSongs = Instantiate(themeChen);
                    // Main.destrua();
                    Destroy(Clone4);
                    Clone5 = Instantiate(boss[6], pos.position, Quaternion.identity);
                    main.partida = false;

                    //cenario
                    n1.SetActive(false);
                    Clone = Instantiate(cntrl);
                }
            }



        }
       
    }

}
