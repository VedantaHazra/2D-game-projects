using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   Vector2 rawInput;
   [SerializeField] float moveSpeed = 8f;

   Vector2 minBounds;
   Vector2 maxBounds;
   [SerializeField] float paddingLeft;
   [SerializeField] float paddingRight;
   [SerializeField] float paddingBottom;
   [SerializeField] float paddingUp;

   Shooter shooter;
   LevelManager levelManager;

   void Awake() 
   {
    shooter = GetComponent<Shooter>();
    levelManager = FindObjectOfType<LevelManager>();
   }

   void Start() 
   {
    InitBounds();
   }


   void InitBounds()
   {
    Camera mainCamera = Camera.main;
    minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
    maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
   }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime ;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x , minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingUp);
        transform.position = newPos;
    }

    void OnFire(InputValue value)
    {
        if(shooter!= null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
    void OnPause()
    {
        levelManager.PauseGame();
    }
}
