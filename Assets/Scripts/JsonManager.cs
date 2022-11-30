using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Windows;

public class JsonManager : MonoBehaviour{
    public HighScoreTable table;
    public ScoreData newData;

    public void SaveHighScoreToJSON(string name, int score){
        string path = Application.persistentDataPath + "/highscore.json";
        newData.name = name;
        newData.score = score;
        var json = JsonUtility.ToJson(newData);
        if(File.Exists(path)){
            var scoreDataInString = File.ReadAllText(path);
            var oldScoreData = JsonUtility.FromJson<ScoreData>(scoreDataInString);
            //check wich one is highest
            if(newData.score > oldScoreData.score){
                File.WriteAllText(path, json);
                Debug.Log("Highscore overwrite");
            }
        }else{
            File.WriteAllText(path, json);
            Debug.Log("Create new highscore file in json");
        }

    }
    public ScoreData GetHighsScoreFromJSON(){
        string path = Application.persistentDataPath + "/highscore.json";
        ScoreData oldData = new ScoreData();
        if(File.Exists(path)){
            var jsonDataInString = File.ReadAllText(path);
            oldData = JsonUtility.FromJson<ScoreData>(jsonDataInString);
        }
        return oldData;
    }

    public void SaveToJSON(){

    }
    public void LoadFromJSON(){

    }
}
public class HighScoreTable{
    List<ScoreData> data = new List<ScoreData>();
}
[System.Serializable]
public class ScoreData{
    public string name = "";
    public int score = 0;
}
