using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;
    
    [Header("UseAI")]
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minFiringRate = 0f;
    [SerializeField] bool useAI;

    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;
    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    
    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
        
    }
    void Fire()
    {
        if(isFiring && firingCoroutine==null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine!=null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab,transform.position,Quaternion.identity);
            
            if(!useAI)
            {
            audioPlayer.PlayShootingClip();
            }

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb!=null)
            {
                rb.velocity = transform.up*projectileSpeed;
            }
            Destroy(instance, projectileLifetime);
            float firingRate = Random.Range(baseFiringRate-firingRateVariance,baseFiringRate+firingRateVariance);
            yield return new WaitForSeconds(Mathf.Clamp(firingRate,minFiringRate,float.MaxValue));
        }

    }
}
