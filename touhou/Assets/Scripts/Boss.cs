using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Slider slider;
    public float life = 17f;


   
    void Start()
    {
       gameObject.SetActive(false);
       LevelManager.Manager += Iniciar;
        LevelManager.ManagerStop += parar;

    }

    
    void Update()
    {
        slider.value = life;
        if(life <= 0)
        {
           
            Destroy(gameObject);
           
        }
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "tiro")
        {
            life -= 0.01f;
            Destroy(c.gameObject);
        }    
    }
    void Iniciar()
    {
        gameObject.SetActive(true);
    }
    void parar()
    {
       gameObject.SetActive(false);
    }

}
