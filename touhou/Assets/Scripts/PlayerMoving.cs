using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoving : MonoBehaviour
{
    public float _PlayerSpeed;
    private Vector2 _PlayerDirection;
    private Rigidbody2D _PlayerRB2D;
    public GameObject Bullet;
    GameObject Clone;
    public  float time, MaxTime;

    //VIDA

    public int vidaAtual = 3;
    public float timelife,maxtimelife;
    public Text txtlife,frameTime;
    public int abreviaTempo;

    bool Controlador;

   public Text Vitoria;
    Boss main2;
    void Start ()
    {
        _PlayerRB2D = GetComponent<Rigidbody2D>();
        main2 = FindObjectOfType<Boss>();
        LevelManager.Manager += Iniciar;
        LevelManager.ManagerStop += Destruir;
        timelife = 0;
        timelife = 3;
    
    }

    void Update ()
    {
        if(Controlador == true)
        {
            Bull3t();
            sllow();
            _PlayerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            txtlife.text = "Life " + vidaAtual.ToString();
            frameTime.text = "Frame " + abreviaTempo.ToString();
        }
        if(timelife < maxtimelife)
        {
            timelife += Time.deltaTime;
            gameObject.layer = 2;

        }
        else
        {
            gameObject.layer = 3;
        }

        if (vidaAtual <= 0)
        {
           
            Vitoria.text = "v o c e   p e r d e u";
            
        }
       if(timelife > abreviaTempo)
       {
            abreviaTempo += 1;
       }
        if (main2.Index >= 2)
        {
            Vitoria.text = "v o c e   v e n c e u";
        }

        
        

    }

    void FixedUpdate()
    {
        _PlayerRB2D.MovePosition(_PlayerRB2D.position + _PlayerDirection* _PlayerSpeed * Time.deltaTime); 
    }

    private void OnParticleCollision(GameObject c)
    {
        if (c.gameObject.layer == 8)
        {
            if(timelife >= maxtimelife)
            {
                timelife = 0;
                vidaAtual -= 1;
                abreviaTempo = 0;
                Destroy(c.gameObject);
            }
           
          
        }
    }
   
    void sllow()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _PlayerSpeed = 3;
        }
        else
        {
            _PlayerSpeed = 7;
        }
    }
    void Bull3t()
    {
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.Z) && time > MaxTime)
        {

            Clone = Instantiate(Bullet, transform.position, Quaternion.identity);
            time = 0;

        }
    }
    void Iniciar()
    {
        Controlador = true;
    }
    void Destruir()
    {
        gameObject.SetActive(false);
        txtlife.text = "";
        frameTime.text =  "";
        Controlador = false;
    }
   
}
