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

    //DANO
    public float damage;

    //PENTAGRAMA
    public GameObject satan;
    float z = 0;
    public float velocidadeRotacionatoria;

    //EFEITINHO ESPECIAL
    public GameObject efeito, poss;
    public GameObject CloneE;
    public float time, maxtime;


    //SONS
    public GameObject HurtXsound,NextBoss;
    GameObject CloneSound;
    void Start()
    {
       gameObject.SetActive(false);
       LevelManager.Manager += Iniciar;
      // LevelManager.ManagerStop += parar;
        partida = true;
        main = FindObjectOfType<LevelControler>();
      //  damage = 0.015f;
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
            time = 0;
            CloneE = Instantiate(efeito, poss.transform.position, Quaternion.identity);
            CloneSound = Instantiate(NextBoss);
            
        }
        Gira();
        time += Time.deltaTime;
        if(time >= maxtime)
        {
            Destroy(CloneE);
           
        }
               
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "tiro")
        {
            life -= damage;
            Destroy(c.gameObject);
        }   
        if(c.tag == "X")
        {
            life -= 0.035f;
            CloneSound = Instantiate(HurtXsound);
        }
    }
    void Iniciar()
    {
        Index++;
       // gameObject.SetActive(true);
    }
    void parar()
    {
     //  gameObject.SetActive(false);
      //  Destroy(CloneE);
    }
    void Gira()
    {
        z = z + Time.deltaTime * velocidadeRotacionatoria;
        satan.transform.rotation = Quaternion.Euler(0, 0, z);
    }

}
