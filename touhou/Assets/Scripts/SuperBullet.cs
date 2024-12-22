using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBullet : MonoBehaviour
{
    public Transform posiçaoInimigo;
    public float Velocidade;
    Rigidbody2D RB;
    public float time, MaxTime;

    //SUPER BULLET

    float z = 0;
    public float VR;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time > MaxTime)
        {
            Destroy(gameObject);
        }
        z = z + Time.deltaTime * VR;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }

    void FixedUpdate()
    {
        tiro();
    }
    void tiro()
    {
        Vector2 Direçao = (posiçaoInimigo.position - transform.position).normalized; //"ponto A pro ponto B"
        RB.velocity = Direçao * Velocidade;

    }
}
