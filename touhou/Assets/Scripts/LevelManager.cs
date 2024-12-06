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
    void Start()
    {
        end.SetActive(false);
        main = FindObjectOfType<PlayerMoving>();
        main2 = FindObjectOfType<Boss>();
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
