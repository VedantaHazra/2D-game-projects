using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float ReloadTime = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    int health = 40;
    
    [SerializeField] Image healthbar;
    bool hasCrashed = false;
   void OnTriggerEnter2D(Collider2D other) 
   {
    if(other.tag == "Ground" && !hasCrashed){
        GetComponent<PlayerController>().DisableControls();
        hasCrashed=true;
        Debug.Log("You crashed");
        crashEffect.Play();
        GetComponent<AudioSource>().PlayOneShot(crashSFX);
        Invoke("ReloadScene",ReloadTime);
    }

        if(other.tag=="Enemy")
        {
            health -= 5;
            float fill = health/40f;
            healthbar.fillAmount = fill;

        }

        if(health==0)
        {
            ReloadScene();
        }
        
   }
    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
