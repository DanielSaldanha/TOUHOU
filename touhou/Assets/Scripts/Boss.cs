using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Slider slider;
    public float life = 17f;


    public bool partida;
    public int Index = -1;

    LevelControler main;

    //PENTAGRAMA
    public GameObject satan;
    float z = 0;
    public float velocidadeRotacionatoria;
    void Start()
    {
       gameObject.SetActive(false);
       LevelManager.Manager += Iniciar;
       LevelManager.ManagerStop += parar;
        partida = true;
        main = FindObjectOfType<LevelControler>();
    }

    
    void Update()
    {
        slider.value = life;
        if(life <= 0)
        {
            life = 17;
            Index++;
            partida = true;
            main.aviso = true;
        }
        Gira();
        
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "tiro")
        {
            life -= 0.1f;
            Destroy(c.gameObject);
        }    
    }
    void Iniciar()
    {
        Index++;
        gameObject.SetActive(true);
    }
    void parar()
    {
       gameObject.SetActive(false);
    }
    void Gira()
    {
        z = z + Time.deltaTime * velocidadeRotacionatoria;
        satan.transform.rotation = Quaternion.Euler(0, 0, z);
    }

}
