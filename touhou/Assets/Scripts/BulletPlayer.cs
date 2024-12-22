using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
   public Transform posišaoInimigo;
  public  float Velocidade;
    Rigidbody2D RB;
    public float time, MaxTime;

    
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        time += Time.deltaTime;
        if(time > MaxTime)
        {
            Destroy(gameObject);
        }      
    }
    
    void FixedUpdate()
    {
        tiro();
    }
    void tiro()
    {
      Vector2 Direšao = (posišaoInimigo.position - transform.position).normalized; //"ponto A pro ponto B"
      RB.velocity = Direšao * Velocidade;

    }

}
