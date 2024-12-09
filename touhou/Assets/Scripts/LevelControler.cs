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
    }

}
