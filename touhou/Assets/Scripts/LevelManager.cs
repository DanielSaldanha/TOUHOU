using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public delegate void Mensagem();
   public static Mensagem Manager, ManagerStop;

    public GameObject end;

    PlayerMoving main;
    Boss main2;

   //EFEITO DE BRIR CENA
   [SerializeField] Color cor;
   [SerializeField] SpriteRenderer spritecor;
    public float time,time2,maxtime;

    //DIFICULDADE
    public int us, vd;
   
    void Start()
    {
       
        end.SetActive(false);
        main = FindObjectOfType<PlayerMoving>();
        main2 = FindObjectOfType<Boss>();

        cor.a = 255;
        cor = Color.black;
        medio();

    }

  
    void Update()
    {
       if(main.vidaAtual <= 0 || main2.Index >= 3)//|| main2.life <= 0
        {
            end.SetActive(true);
            
            if(ManagerStop != null)
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

    }
    public void Comecar()
    {
        if(Manager != null)
        {
            Manager();
        }
    }
    public void Quit()
    {
        Application.Quit();

    }
    public void facil()
    {
        main.vidaAtual = 10;
        main.Uso = 10;
        main2.damage = 0.025f;
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

  
}
