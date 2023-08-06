using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] AudioClip buttonClip;
    [SerializeField] [Range(0f,1f)] float volume = 0.7f;
    ScoreKeeper scoreKeeper;
    [SerializeField] float sceneLoadDelay = 2f;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadEasyGame()
    {
        scoreKeeper.ResetScore();
        StartCoroutine(WaitAndLoad("EasyGame", 0.19f));
    }
    public void LoadMediumGame()
    {
        scoreKeeper.ResetScore();
        StartCoroutine(WaitAndLoad("MediumGame", 0.19f));
    }
    public void LoadHardGame()
    {
        scoreKeeper.ResetScore();
        StartCoroutine(WaitAndLoad("HardGame", 0.19f));
    }
    public void LoadMainMenu()
    {
        StartCoroutine(WaitAndLoad("MainMenu", 0.19f));
    }
    public void LoadTutorialMenu()
    {
        StartCoroutine(WaitAndLoad("TutorialMenu", 0.19f));
    }

    public void LoadLevelSelect()
    {
        StartCoroutine(WaitAndLoad("LevelSelect", 0.19f));
    }
    public void LoadEndMenu()
    {
       StartCoroutine(WaitAndLoad("EndMenu", sceneLoadDelay));
    }
    public void PauseGame()
    {
        StartCoroutine(WaitAndLoad("PauseMenu", 0.19f));
    }
    public void QuitGame()
    {
        PlaySound();
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        PlaySound();
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
    void PlaySound()
    {
        AudioSource.PlayClipAtPoint(buttonClip, Camera.main.transform.position, volume);
    }
}
