using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject companyPanel;
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject controlsPanel;
    [SerializeField] GameObject creditsPanel;
    
    AudioSource menuMusic;


    private void Awake()
    {
        menuMusic = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        OpenMenu(mainMenuPanel);
        CloseMenu(controlsPanel);
        CloseMenu(creditsPanel);
        menuMusic.Play();
    }

    public void CloseMenu(GameObject menu)
    {
        menu.SetActive(false);
    }

    public void OpenMenu(GameObject menu)
    {
        menu.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
