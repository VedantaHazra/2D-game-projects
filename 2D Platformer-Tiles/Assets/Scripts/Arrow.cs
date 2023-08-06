using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float arrowSpeed = 4f;
    [SerializeField] int pointsForEnemyDestroy = 10;
    PlayerMovement player;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        myRigidBody.velocity = new Vector2 (arrowSpeed*player.transform.localScale.x, 0f);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            gameObject.SetActive(false);
            FindObjectOfType<GameSession>().AddToScore(pointsForEnemyDestroy);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
        
    }
}
