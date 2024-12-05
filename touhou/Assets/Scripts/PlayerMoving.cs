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



    void Start ()
    {
        _PlayerRB2D = GetComponent<Rigidbody2D>();
        LevelManager.Manager += Iniciar;
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
            frameTime.text = "Invencible Frame " + abreviaTempo.ToString();
        }
        if(timelife < maxtimelife)
        {
            timelife += Time.deltaTime;
        }
        if(vidaAtual == 0)
        {
            Destroy(gameObject);
           
        }
       if(timelife > abreviaTempo)
        {
            abreviaTempo += 1;
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
   
}
