using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] ParticleSystem hitEffect;
   [SerializeField] int health  = 50;

   [SerializeField] bool isPlayer;
   CameraShake cameraShake;
   AudioPlayer audioPlayer;
   ScoreKeeper scoreKeeper;
   LevelManager levelManager;

   void Awake()
   {
     cameraShake = Camera.main.GetComponent<CameraShake>();
      audioPlayer = FindObjectOfType<AudioPlayer>();
      scoreKeeper = FindObjectOfType<ScoreKeeper>();
      levelManager = FindObjectOfType<LevelManager>();
   }

   void OnTriggerEnter2D(Collider2D other) 
   {
    DamageDealer damageDealer = other.GetComponent<DamageDealer>();

    if(damageDealer!= null)
    {
        
        TakeDamage(damageDealer.GetDamage());
        PlayHitEffect();
        ShakeCamera();
        PlayDamageTakenClip();
        damageDealer.Hit();
    }
   }

   void TakeDamage(int damage)
   {
        health-= damage;
    if(health<=0)
    {
        Die();
    }
   }

   void PlayHitEffect()
   {
    if(hitEffect!=null)
    {
    ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity); 
    Destroy(instance.gameObject, instance.main.duration);
   }
   }

   void ShakeCamera()
   {
    if(cameraShake!=null && isPlayer)
    {
        cameraShake.Play();
    }
   }

   void PlayDamageTakenClip()
   {
    if(audioPlayer!=null && isPlayer)
    {
    audioPlayer.PlayDamageClip();
    }
   }

   public int GetHealth()
   {
    return health;

   }
   void Die()
   {
    if(!isPlayer)
        {
            scoreKeeper.IncreaseScore();
        }
        
    else
    {
        levelManager.LoadEndMenu();
    }
    Destroy(gameObject);
   }

}
