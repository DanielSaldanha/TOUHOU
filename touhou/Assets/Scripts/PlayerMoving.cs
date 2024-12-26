using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoving : MonoBehaviour
{
    bool Controlador;

    [Header("MOVE")]
    public float _PlayerSpeed;
    private Vector2 _PlayerDirection;
    private Rigidbody2D _PlayerRB2D;

    [Header("SHOOT")]
    public GameObject Bullet;
    public GameObject BulletSuper;
    GameObject Clone,CloneSuper;
    public  float time, MaxTime;
    public float timeSuper, MaxTimeSuper;

    [Header("LIFE")]
    public int vidaAtual;
    public float timelife,maxtimelife;
    public Text txtlife,frameTime;
    public int abreviaTempo;

    [Header("WIN or NO")]
    public Text Vitoria;
    Boss main2;

    [Header("DAMAGE")]
    [SerializeField] Color cor;
    [SerializeField] SpriteRenderer spritecor;
    public float timeframe;
    public bool derrota;

    [Header("SKILL X")]
    public GameObject X;
    public GameObject USX;
    GameObject CloneX,UltraSkillX;
    public int Uso;
    public Text UltraPower;
    public float timeX, maxtimeX;

    [Header("DEATH BOMB SYSTEM")]
    public float timeDamage;
    public float MaxTimeDamage;

    [Header("SOUNDS")]
    public GameObject Xsound;
    public GameObject SoundBullet, AutoHurt;
    GameObject CloneSound;


    void Start ()
    {
        _PlayerRB2D = GetComponent<Rigidbody2D>();
        main2 = FindObjectOfType<Boss>();
        
        LevelManager.Manager += Iniciar;
     //   LevelManager.ManagerStop += Destruir;     
        timelife = 5;
        timeDamage = MaxTimeDamage;
    }

    void Update ()
    {
        if(Controlador == true)
        {
            Bull3t();
            Bull3tSuper();
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
        if (c.gameObject.layer == 8 && timelife >= maxtimelife)
        {
            timeDamage = 0;
            DeathBomb();
            Destroy(c.gameObject);
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
            CloneSound = Instantiate(SoundBullet);
        }
       
    }
    void Bull3tSuper()
    {
        timeSuper += Time.deltaTime;

        if (Input.GetKey(KeyCode.Z) &&  Input.GetKey(KeyCode.LeftShift) && timeSuper > MaxTimeSuper)
        {

            CloneSuper = Instantiate(BulletSuper, transform.position, Quaternion.identity);
            timeSuper = 0;

        }
      
        //  BulletSuper.transform.LookAt(apontar);
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
        timeX += Time.deltaTime;
        if(Uso > 0)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Destroy(CloneX);
                Destroy(UltraSkillX);
                CloneX = Instantiate(X, this.transform.position, Quaternion.identity);
                UltraSkillX = Instantiate(USX);
                derrota = true;
                timelife = 0;
                timeX = 0;
                Uso -= 1;
                CloneSound = Instantiate(Xsound);
            }
        }          
        if(timeX >= maxtimeX)
        {
            Destroy(UltraSkillX);
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

            //SYSTEM OF THE DEATH BOMB
            timeDamage += Time.deltaTime;

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

    void DeathBomb()
    {

        if (Input.GetKeyDown(KeyCode.X) && timeDamage < MaxTimeDamage)
        {
            vidaAtual += 1;
        
        }     
        else
        {
            timelife = 0;
            vidaAtual -= 1;
            abreviaTempo = 0;
           
            CloneSound = Instantiate(AutoHurt);
        }
        
    }
}
