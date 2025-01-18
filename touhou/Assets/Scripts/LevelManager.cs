using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   public delegate void Mensagem();
   public static Mensagem Manager, ManagerStop;

    public GameObject end, TelaInicial, boss, player, pausagem, dificuldades, mudadorPersonagem, barralife;

    PlayerMoving main;
    Boss main2;
    LevelControler main3;

   //EFEITO DE BRIR CENA
   [SerializeField] Color cor;
   [SerializeField] SpriteRenderer spritecor;
    public float time,time2,maxtime;

    //DIFICULDADE
    public int us, vd;

    //PAUSE OU DESPAUSE
    bool pause, permitir;

    //SONS
    public GameObject OpenMenuSound;
    GameObject CloneSound;

   
   
    void Start()
    {
       
        end.SetActive(false);
        barralife.SetActive(false);
        main = FindObjectOfType<PlayerMoving>();
        main2 = FindObjectOfType<Boss>();
        main3 = FindObjectOfType<LevelControler>();

        cor.a = 255;
        cor = Color.black;
      //  medio();
        pause = true;
        permitir = false;
        pausagem.SetActive(false);

        //MEDIO
        main.vidaAtual = 5;
        main.Uso = 5;
        main2.damage = 0.009f;

    }

  
    void Update()
    {
        pausar();
       if (main.vidaAtual <= 0 || main2.Index >= 5)//|| main2.Index >= 3
       {
            permitir = false;
            end.SetActive(true);
            playerDestruido();// player.SetActive(false);
            boss.SetActive(false);
            Destroy(main2.CloneE);
            if (ManagerStop != null)
            {
                ManagerStop();
            }
            main3.CloneSongs.SetActive(false);

       }
       
       

        time2 += Time.deltaTime;
        if(time2 >= maxtime)
        {
            time += Time.deltaTime / 180;
            spritecor.color = cor;
            cor.a -= time;
        }

        if(main2.life <= 0)
        {
            justo();
        }

      //  Resetar();
    }
    // CONFIGURANDO E INICIANDO
    public void IniciarConfiguraçoes()
    {
        
      
        TelaInicial.SetActive(false);
        boss.SetActive(true);

        mudadorPersonagem.SetActive(true);
    }
    public void FinalizadoPersonagem()
    {
        mudadorPersonagem.SetActive(false);
        dificuldades.SetActive(true);
        Destroy(main.SpriteVisual);
        Destroy(main.SpriteVisual2);

    }
    void começar()
    {
        if (Manager != null)
        {
            Manager();
        }
        permitir = true;
        TelaInicial.SetActive(false);
        boss.SetActive(true);
        dificuldades.SetActive(false);
        barralife.SetActive(true);
    }

    //RESTART AND QUIT
    public void Quit()
    {
        Application.Quit();

    }
    public void Resetar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  
    }
    void pausar()
    {
        if (permitir == true)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (pause == false)
                {
                    Time.timeScale = 1;

                }
                if (pause == true)
                {
                    Time.timeScale = 0;

                }
                main3.CloneSongs.SetActive(!pause);
                CloneSound = Instantiate(OpenMenuSound);


                pausagem.SetActive(pause);
                pause = !pause;
            }
        }
    }

    //PARAMETRO DE DIFICULDADE
    public void facil()
    {
        main.vidaAtual = 10;
        main.Uso = 10;
        main2.damage = 0.025f;
        armazem();
        começar();
    }
    public void medio()
    {
        main.vidaAtual = 5;
        main.Uso = 5;
        main2.damage = 0.011f;
        armazem();
        começar();
    }
    public void dificil()
    {
        main.vidaAtual = 3;
        main.Uso = 5;
        main2.damage = 0.011f;
        armazem();
        começar();
    }

    //SISTEMA DE JUSTIÇA
    void armazem()
    {
        vd = main.vidaAtual;
        us = main.Uso;
       
    }
    public void justo()
    {
        main.vidaAtual = vd;
        main.Uso = us;
    }
   
    //MORTE
    void playerDestruido()
    {
        main.Destruir();
        player.SetActive(false);
    }
    
}
