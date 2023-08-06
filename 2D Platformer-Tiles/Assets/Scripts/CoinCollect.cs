using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] AudioClip coinCollectSFx;
    [SerializeField] int pointsForCoinCollect = 5;
    public int score = 0;
    bool wasCollected = false;
  void OnTriggerEnter2D(Collider2D other) 
  {
    if(other.tag == "Player" && !wasCollected)
    {
      wasCollected = true;
        AudioSource.PlayClipAtPoint(coinCollectSFx, Camera.main.transform.position);
        Destroy(gameObject);
        gameObject.SetActive(false);
        FindObjectOfType<GameSession>().AddToScore(pointsForCoinCollect);
    }
    
   }
}
