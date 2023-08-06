using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int flag = 0;
    [SerializeField] AudioClip Clip;
    GameSession game;
    void Awake() {
        game = FindObjectOfType<GameSession>();
    }

    public void LoadLevel1()
    {
        StartCoroutine(LoadScene("Level 1"));
    }
    public void LoadLevel2()
    {
        StartCoroutine(LoadScene("Level 2"));
    }
    public void LoadLevel3()
    {
        StartCoroutine(LoadScene("Level 3"));
    }
     public void LoadMainMenu()
    {
        if(flag== 1)
        {
        game.ResetGame();
        }
        StartCoroutine(LoadScene("MainMenu"));
    }
    public void LoadEndMenu()
    {
        SceneManager.LoadScene("EndMenu");
    }
    
    
    public void LoadPauseMenu()
    {
        StartCoroutine(LoadScene("PauseMenu"));
    }
    public void LoadTutorial()
    {
        StartCoroutine(LoadScene("Tutorial"));
    }
    public void LoadLevelSelect()
    {
        StartCoroutine(LoadScene("LevelSelect"));
    }
    public void QuitGame()
    {
        AudioSource.PlayClipAtPoint(Clip, Camera.main.transform.position);
        Application.Quit();
    }
    IEnumerator LoadScene(string Scene)
    {
        AudioSource.PlayClipAtPoint(Clip, Camera.main.transform.position);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(Scene);
    }

}
