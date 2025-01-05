using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioDown : MonoBehaviour
{
    Rigidbody2D rb;
    public float time, maxtime;
    public int numero;
    public Transform poss;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        time = -25;
    }

   
    void Update()
    {
        time += Time.deltaTime * numero;
        transform.position = new Vector2(4, -time);
    }
}
