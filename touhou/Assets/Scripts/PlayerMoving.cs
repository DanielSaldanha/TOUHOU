using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoving : MonoBehaviour
{
    bool Controlador;

    //MOVE
    public float _PlayerSpeed;
    private Vector2 _PlayerDirection;
    private Rigidbody2D _PlayerRB2D;

    //BULLET
    public GameObject Bullet;
    GameObject Clone;
    public  float time, MaxTime;

   
    //VIDA
    public int vidaAtual;
    public float timelife,maxtimelife;
    public Text txtlife,frameTime;
    public int abreviaTempo;

    //WIN ou PERCA
    public Text Vitoria;
    Boss main2;

    //DANO
    [SerializeField] Color cor;
    [SerializeField] SpriteRenderer spritecor;
    public float timeframe;
    public bool derrota;

    // X
    public GameObject X;
    GameObject CloneX;
    public int Uso;
    public Text UltraPower;

    void Start ()
    {
        _PlayerRB2D = GetComponent<Rigidbody2D>();
        main2 = FindObjectOfType<Boss>();
        
        LevelManager.Manager += Iniciar;
     //   LevelManager.ManagerStop += Destruir;     
        timelife = 5;            
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
            SistemaDeDanoEhp();
            EspecialDoX();
        }
       
        
        if(timelife >= 0.45f)
        {
            Destroy(CloneX); 
        }
        UltraPower.text = "Especial " + Uso.ToString();
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
            _PlayerSpeed = 2.7f;
        }
        else
        {
            _PlayerSpeed = 5.2f;
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
    public void Destruir()
    {
       // gameObject.SetActive(false);
        txtlife.text = "";
        frameTime.text =  "";
        UltraPower.text = " ";
        Controlador = false;
    }
   void AnimaçaoDano()
    {
        timeframe += Time.deltaTime;
        if (timeframe >= 0.2f)
        {
            cor = Color.black;
        }
        else
        {
            cor = Color.white;
        }
        if (timeframe >= 0.4)
        {
            timeframe = 0;
        }
    }
    
    void EspecialDoX()
    {
        if(Uso > 0)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Destroy(CloneX);
                CloneX = Instantiate(X, this.transform.position, Quaternion.identity);
                derrota = true;
                timelife = 0;
                Uso -= 1;
               
            }
        }                  
    }
    
    void SistemaDeDanoEhp()
    {
        spritecor.color = cor;

        if (timelife < maxtimelife)
        {
            timelife += Time.deltaTime;
            gameObject.layer = 2;
            AnimaçaoDano();

         
        }
        else
        {
            gameObject.layer = 3;
            cor.a = 255;
            cor = Color.white;
            
        }

        if (vidaAtual <= 0)
        {

            Vitoria.text = "v o c e   p e r d e u";

        }
        if (timelife > abreviaTempo)
        {
            abreviaTempo += 1;
        }
        if (main2.Index >= 3)
        {
            Vitoria.text = "v o c e   v e n c e u";
        }
    }
}
