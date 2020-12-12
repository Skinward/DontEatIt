using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
	public TextMeshProUGUI timeText;
	public TextMeshProUGUI countdownText;
	public TextMeshProUGUI controlsText;

	public AudioClip _321Beep;
	public AudioClip _GoBeep;


    public GameObject startPos;
    public GameObject player;
    public GameObject standingsPanel;
    public GameObject pausePanel;

	private float timer;
	private float finalTime;
	private float clockTime;
	private bool gameDone;
	private bool isPaused;
	public bool countdownFinished;

	private void Awake()
    {
        Instance = this;
		gameDone = false;
		countdownFinished = false;
    }

	IEnumerator Countdown(int seconds)
	{
		int counter = seconds;
		while (counter > -1)
		{
			if (counter == 0)
			{
				countdownText.text = "GO!";
				gameObject.GetComponent<AudioSource>().PlayOneShot(_GoBeep);
			}
			else
			{
				countdownText.text = counter.ToString();
				gameObject.GetComponent<AudioSource>().PlayOneShot(_321Beep);
			}
			yield return new WaitForSeconds(1);
			counter--;
		}
		countdownText.gameObject.SetActive(false);
		countdownFinished = true;
	}

	private void Start()
    {
		player.transform.position = startPos.transform.position;
		StartCoroutine(Countdown(3));
		standingsPanel.SetActive(false);
		pausePanel.SetActive(false);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;
	}

    void Update()
	{
		if (countdownFinished)
		{
			timer += Time.deltaTime;
			clockTime = timer;
			int minutes = Mathf.FloorToInt(clockTime / 60F);
			int seconds = Mathf.FloorToInt(clockTime % 60F);
			if (!gameDone)
			{
				timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
			}

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				PauseGame();
				pausePanel.SetActive(true);
				Cursor.visible = true;
			}
		}

	}

	public void EndTime()
	{
		finalTime = timer;
		int minutes = Mathf.FloorToInt(finalTime / 60F);
		int seconds = Mathf.FloorToInt(finalTime % 60F);
		Debug.Log(minutes.ToString("00") + ":" + seconds.ToString("00"));
	}	

	public void SetGameDone()
    {
		gameDone = true;
		timeText.gameObject.SetActive(false);
		standingsPanel.SetActive(true);
		Standings.Instance.PopulateWinners();
		Cursor.visible = true;
    }

	public void ResetPlayer()
    {
		player.transform.position = startPos.transform.position;
    }

	public void QuitGame()
    {
		Application.Quit();
    }

	public float GetFinalTime()
    {
		return finalTime;
    }

	public bool GetGameDone()
    {
		return gameDone;
    }

	public void ResetGame()
    {
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	void PauseGame()
	{
		Time.timeScale = 0;
		isPaused = true;
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
		isPaused = false;
		pausePanel.SetActive(false);
		Cursor.visible = false;
	}

	public bool IsGamePaused()
    {
		return isPaused;
    }

	public void GoToMainMenu()
    {
		Time.timeScale = 1;
		Destroy(BGMusic.Instance.gameObject);
		SceneManager.LoadScene("MainMenu");
	}
}
