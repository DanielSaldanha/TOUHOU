using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Slider slider;
    public float life = 17f;
    private void Awake()
    {
       // gameObject.SetActive(false);
    }
    void Start()
    {
       gameObject.SetActive(false);
        LevelManager.Manager += Iniciar;
    }

    
    void Update()
    {
        slider.value = life;
        if(life <= 0)
        {
           
        }
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "tiro")
        {
            life -= 1f;
            Destroy(c.gameObject);
        }    
    }
    void Iniciar()
    {
        gameObject.SetActive(true);
    }

}
