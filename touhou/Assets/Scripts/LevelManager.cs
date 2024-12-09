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
   
    void Start()
    {
       
        end.SetActive(false);
        main = FindObjectOfType<PlayerMoving>();
        main2 = FindObjectOfType<Boss>();

        cor.a = 255;
        cor = Color.black;
    }

  
    void Update()
    {
       if(main.vidaAtual <= 0 || main2.life <= 0)
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

  
}
