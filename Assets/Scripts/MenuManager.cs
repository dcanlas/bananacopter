using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	/// <summary>
	/// Main Menu Controller.
	/// This class handles user clicks on menu button, and also fetch and shows user saved scores on screen.
    /// This also controlls the splash screen on the new Menu.
	/// </summary>
	
	private int bestScore;				//best saved score
	private int lastScore;				//score of the last play

	//reference to gameObjects
	public GameObject bestScoreText;	
	public GameObject lastScoreText;

    public AudioClip menuTap;			//sfx for touch on menu buttons
	
	private bool canTap;						//are we allowed to click on buttons? (prevents double touch)
	//private float buttonAnimationSpeed = 9.0f;	//button scale animation speed

	void Awake () {
		
		canTap = true; //player can tap on buttons
		
		bestScore = PlayerPrefs.GetInt("bestScore");
		bestScoreText.GetComponent<Text>().text = bestScore.ToString();
		
		lastScore = PlayerPrefs.GetInt("lastScore");
		lastScoreText.GetComponent<Text>().text = lastScore.ToString();
	}


	void Start() {
		//prevent screenDim in handheld devices
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

    public void StartNextLevel()
    {
        playSfx(menuTap);
        PlayerPrefs.SetInt("GameMode", 0);
        SceneManager.LoadScene("Game");
    }
	
	///***********************************************************************
	/// play audio clip
	///***********************************************************************
	void playSfx(AudioClip _sfx) {
		GetComponent<AudioSource>().clip = _sfx;
		if(!GetComponent<AudioSource>().isPlaying)
			GetComponent<AudioSource>().Play();
	}
}
