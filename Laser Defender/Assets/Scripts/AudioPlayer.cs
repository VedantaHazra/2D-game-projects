using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingAudioVolume = 1f;

    [Header("Damage Taken")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f,1f)] float damageAudioVolume = 1f;

    void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {
        int instanceCount = FindObjectsOfType((GetType())).Length;
        if(instanceCount>1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayShootingClip()
    {
        PlayClip(shootingClip,shootingAudioVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip,damageAudioVolume);
    }

    void PlayClip(AudioClip Clip, float volume)
    {
        if(Clip!=null)
        {
            AudioSource.PlayClipAtPoint(Clip, Camera.main.transform.position, volume);
        }
    }
}
