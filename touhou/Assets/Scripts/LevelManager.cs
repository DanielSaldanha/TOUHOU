using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public delegate void Mensagem();
   public static Mensagem Manager;
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
    public void Comecar()
    {
        if(Manager != null)
        {
            Manager();
        }
    }
}
