using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UIManager : MonoBehaviour{
    [Header("HUD")]
    public TMP_Text scoreTMP;
    public TMP_Text healthTMP;
    
    [Header("GameOver Panel")]
    public GameObject gameOverPanel;
    public TMP_Text scoreGameOverTMP;
    public TMP_Text highscoreGameOverTMP;
    public TMP_Text hsGameOverTMP;

    [Header("MainMenu Panel")]
    public GameObject mainMenuPanel;
    public TMP_Text hsMainMenuTMP;

    [Header("Pause Panel")]
    public GameObject pausePanel;

    [Header("Highscore Panel")]
    public GameObject highscorePanel;
    public TMP_Text scoreHSTMP;
    public TMP_InputField highscoreNameInput;

    // Start is called before the first frame update
    void Start(){
        // scoreTMP.text = "score : " + 0;
        UpdateHealth();
        // healthTMP.text = "health : " + 0;
        UpdateScore();
        StartMenu();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update(){
        
    }
    public void UpdateHealth(){
        var health = GameManager.get.health;
        healthTMP.text = "Health : " + health;
    }
    public void UpdateScore(){
        var score = GameManager.get.score;
        scoreTMP.text = "Score : " + score;

    }
    public void StartGame(){
        mainMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void GameOver(){
        
        highscoreGameOverTMP.text = "Highscore : " + GameManager.get.highscore;
        scoreGameOverTMP.text = "Your score : " + GameManager.get.score;
        hsGameOverTMP.text = "Highscore \n" + GameManager.get.hsData.name+" : " + GameManager.get.hsData.score;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void HighScorePanel(){
        scoreHSTMP.text = " Score : " + GameManager.get.score;
        highscorePanel.SetActive(true);
    }
    
    public void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StartMenu(){
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        hsMainMenuTMP.text = "Highscore \n" + GameManager.get.hsData.name+" : " + GameManager.get.hsData.score;
        Time.timeScale = 0;
    }
    public void PlayAgain(){
        //matikan game over panel
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        //reset score dan hp
        GameManager.get.health = 5;
        GameManager.get.score = 0;
        UpdateHealth();
        UpdateScore();
        //Destroy any enemy on scene
        Spawner.ins.DestroyAllSpawned();

    }
    public void ExitGame(){
        Application.Quit();
    }
    public void PauseGame(){
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame(){
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

}
