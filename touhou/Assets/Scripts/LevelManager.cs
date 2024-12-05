using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.SceneManagement.SceneManager;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
   public delegate void Mensagem();
   public static Mensagem Manager;
    void Start()
    {
        
    }

  
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Restart();
        }
    }
    public void Comecar()
    {
        if(Manager != null)
        {
            Manager();
        }
    }
    public void Quit()
    {
        Application.Quit();

    }
   public void Restart()
    {
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //  LoadScene(GetActiveScene().buildIndex);
      //  SceneManager.LoadScene("SampleScene");
    }
}
