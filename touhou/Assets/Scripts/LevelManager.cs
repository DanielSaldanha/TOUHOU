using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   public delegate void Mensagem();
   public static Mensagem Manager, ManagerStop;

    public GameObject end, TelaInicial, boss, player, pausagem;

    PlayerMoving main;
    Boss main2;

   //EFEITO DE BRIR CENA
   [SerializeField] Color cor;
   [SerializeField] SpriteRenderer spritecor;
    public float time,time2,maxtime;

    //DIFICULDADE
    public int us, vd;

    //PAUSE OU DESPAUSE
    bool pause;
   
    void Start()
    {
       
        end.SetActive(false);
        main = FindObjectOfType<PlayerMoving>();
        main2 = FindObjectOfType<Boss>();

        cor.a = 255;
        cor = Color.black;
        medio();
        pause = true;
        pausagem.SetActive(false);

    }

  
    void Update()
    {
        pausar();
       if (main.vidaAtual <= 0 || main2.Index >= 3)//|| main2.life <= 0
        {
            end.SetActive(true);
            playerDestruido();// player.SetActive(false);
            boss.SetActive(false);
            Destroy(main2.CloneE);
            if (ManagerStop != null)
            {
                ManagerStop();
            }
            
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
    public void Comecar()
    {
        if(Manager != null)
        {
            Manager();
        }
        TelaInicial.SetActive(false);
        boss.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();

    }
    public void Resetar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            

        }
        */
    }
    public void facil()
    {
        main.vidaAtual = 10;
        main.Uso = 10;
        main2.damage = 1f;
        armazem();
    }
    public void medio()
    {
        main.vidaAtual = 5;
        main.Uso = 5;
        main2.damage = 0.02f;
        armazem();
    }
    public void dificil()
    {
        main.vidaAtual = 3;
        main.Uso = 5;
        main2.damage = 0.015f;
        armazem();
    }
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
    void pausar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(pause == false)
            {
                Time.timeScale = 1;
                
            }
            if(pause == true)
            {
                Time.timeScale = 0;
                
            }
            pausagem.SetActive(pause);
            pause = !pause;
        }
    }
    void playerDestruido()
    {
        main.Destruir();
        player.SetActive(false);
    }
    
  
}
