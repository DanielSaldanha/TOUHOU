using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaOuDesativa : MonoBehaviour
{
    bool r;
    void Start()
    {
        LevelManager.Manager += Desativar;
        r = true;
    }

    
    void Update()
    {
        
    }
    void Desativar()
    {
        r = !r;
           gameObject.SetActive(r);
      //  Destroy(gameObject);
       
       
    }
}
