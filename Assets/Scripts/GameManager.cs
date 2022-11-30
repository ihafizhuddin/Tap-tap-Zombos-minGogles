using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public static GameManager get;
    [SerializeField] UIManager ui;
    [SerializeField] JsonManager json;
    public int health = 5;
    public int score = 0;
    public int highscore = 0;
    public ScoreData hsData;

    private string highscorekey = "highscore";
    // [Header("")]


    void Awake(){
        get = this;

    }
    // Start is called before the first frame update
    void Start(){
        ui = GetComponent<UIManager>();
        json = GetComponent<JsonManager>();
        highscore = PlayerPrefs.GetInt(highscorekey, 0);
        hsData = json.GetHighsScoreFromJSON();
       
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void DecreaseHealth(){
        health--;
        ui.UpdateHealth();
        if(health<= 0){
            GameOver();
        }
    }

    public void AddScore(){
        score++;
        ui.UpdateScore();
    }
    public void SubmitHighScore(){
        json.SaveHighScoreToJSON(ui.highscoreNameInput.text, score);
        ui.highscorePanel.SetActive(false);
        hsData = json.GetHighsScoreFromJSON();
        ui.GameOver();
    }
    public void GameOver(){
        if(score> highscore){
            ui.HighScorePanel();
            highscore = score;
            PlayerPrefs.SetInt(highscorekey, highscore);
            hsData = json.GetHighsScoreFromJSON();
        }
        ui.GameOver();
        Debug.Log("Game Over");
    }


}
