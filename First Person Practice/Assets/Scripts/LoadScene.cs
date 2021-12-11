using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    void OnTriggerEnter(Collider player)
     {
        if(SceneManager.GetActiveScene().name == "Main_Area")
        {
            if (player.gameObject.name == "Player") 
            {
                 SceneManager.LoadScene("Loading");
            }
        }
        else
        {
            if(player.gameObject.name == "Player")
            {
                SceneManager.LoadScene("TBD");
            }     
        }
     }
}
