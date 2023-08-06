using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject Start;
    void Awake()
    {
        Time.timeScale = 0f;
    }

   public void StartGame()
   {
       Start.SetActive(false);
       Time.timeScale = 1f;
   }
}
