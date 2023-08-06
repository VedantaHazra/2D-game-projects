using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float ReloadTime = 1f;
    [SerializeField] ParticleSystem finishEffect;
    // Start is called before the first frame update
   void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Player"){
        Debug.Log("You finished");
        finishEffect.Play();
        GetComponent<AudioSource>().Play();
        Invoke("ReloadScene",ReloadTime);
    }
   }
    void ReloadScene(){
        SceneManager.LoadScene(0);
    
    
  }
}
