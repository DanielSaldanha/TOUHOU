using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
   public GameObject sprite1;
    bool controlador = false;
    void Start()
    {
        
    }

   
    void Update()
    {
        sprite1.SetActive(controlador);
    }
   void OnMouseEnter()
    {
        controlador = true;
    }
    void OnMouseExit()
    {
        controlador = false;
    }
}
