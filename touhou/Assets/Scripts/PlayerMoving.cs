using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public float _PlayerSpeed;
    private Vector2 _PlayerDirection;
    private Rigidbody2D _PlayerRB2D;
    public GameObject Bullet;
    GameObject Clone;
   public  float time, MaxTime;


    Main main;
    void Start ()
    {
        _PlayerRB2D = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        Bull3t();
        sllow();
        _PlayerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        /*
        if(main.aviso == true)
        {
            Destroy(gameObject);
        }
        */
    }

    void FixedUpdate()
    {
        _PlayerRB2D.MovePosition(_PlayerRB2D.position + _PlayerDirection* _PlayerSpeed * Time.deltaTime); 
    }

    private void OnParticleCollision(GameObject c)
    {
        if(c.gameObject.layer == 8)
        {
            Destroy(gameObject);
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

}
