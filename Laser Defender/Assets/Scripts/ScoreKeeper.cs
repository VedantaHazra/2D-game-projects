using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score = 0;
    static ScoreKeeper instance;
    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instance!=null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void IncreaseScore()
    {
        score+= 10;
       
    }

    public int GiveScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
