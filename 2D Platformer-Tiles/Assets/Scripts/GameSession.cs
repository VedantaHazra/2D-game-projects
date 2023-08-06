using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] int score = 0;
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions>1)
        {
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start() 
    {
     livesText.text = "Lives: " + playerLives;  
     scoreText.text = "Score: " + score; 
    }
    public void AddToScore(int pointsToAdd)
    {
        score+= pointsToAdd;
        scoreText.text = "Score: " + score; 
    }
    

    public void ProcessPlayerDeath()
    {
        if(playerLives>1)
        {
            TakeLife();
        }
        else{
            StartCoroutine(ResetGameSession());
        }
    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = "Lives: " + playerLives;
    }
    IEnumerator ResetGameSession()
    {
        yield return new WaitForSeconds(1.5f);
       FindObjectOfType<ScenePersist>().ResetScenePersist();
         Destroy(gameObject);
        levelManager.LoadEndMenu();
       
    }
    public void ResetGame()
    {
       FindObjectOfType<ScenePersist>().ResetScenePersist();
         Destroy(gameObject);
       
    }
    
    
    
}
