using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaOuDesativa : MonoBehaviour
{
   
    void Start()
    {
        LevelManager.Manager += Desativar;
    }

    
    void Update()
    {
        
    }
    void Desativar()
    {
        gameObject.SetActive(false);
    }
}
