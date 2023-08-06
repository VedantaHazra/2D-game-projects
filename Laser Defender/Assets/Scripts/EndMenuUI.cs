using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndMenuUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endScoreText;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        endScoreText.text = "YoU Scored :\n" + scoreKeeper.GiveScore();
    }
   
}
