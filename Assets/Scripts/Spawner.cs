using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{
    public static Spawner ins;
    public Transform[] spawnPos;
    public Enemy enemyInstances;
    public Human humanInstances;
    public Enemy[] enemies;
    public float timeToSpawn = 3f;
    public List<GameObject> enemiesOnScene;
    
    [SerializeField]float currentCD;
    void Awake(){
        ins = this;
    }
    // Start is called before the first frame update
    void Start(){
        currentCD = timeToSpawn;    
    }

    // Update is called once per frame
    void Update(){
        CountDown();
    }

    public void CountDown(){
        currentCD -= Time.deltaTime;
        if(currentCD <= 0f){
            int levelCount = 1 +  GameManager.get.score / 10;
            for(int i = 0 ; i < levelCount ; i++ ){
                int spawnRNG = Random.Range(1,5);
                float cd = Random.Range(1f,3f);
                if(spawnRNG < 4){
                    Invoke("SpawnEnemy", cd);
                }else{
                    Invoke("SpawnHuman", cd);
                }
            }
            // SpawnHuman();
            currentCD = Random.Range(1f,3f);
        }
    }
    public void SpawnEnemy(){
        int randSpawnPos = Random.Range(0,spawnPos.Length);
        GameObject checkEnemy = enemiesOnScene.Find(x => x.activeInHierarchy == false && x.name == "Enemy");
        if(checkEnemy == null){
            Enemy newEnemy = Instantiate(enemyInstances, spawnPos[randSpawnPos].position, Quaternion.identity);
            newEnemy.speed = Random.Range(1,5);
            newEnemy.gameObject.name = "Enemy";
            enemiesOnScene.Add(newEnemy.gameObject);
        }else{
            Enemy newEnemy = checkEnemy.GetComponent<Enemy>();
            checkEnemy.transform.position = spawnPos[randSpawnPos].position;
            checkEnemy.transform.rotation = Quaternion.identity;
            newEnemy.speed = Random.Range(1,5);
            checkEnemy.SetActive(true);
        }
    }
    
    public void SpawnHuman(){
        int randSpawnPos = Random.Range(0,spawnPos.Length);
        GameObject checkHuman = enemiesOnScene.Find(x => x.activeInHierarchy == false && x.name == "Human");
        if(checkHuman == null){
            Human newHuman = Instantiate(humanInstances, spawnPos[randSpawnPos].position, Quaternion.identity);
            newHuman.speed = Random.Range(1,9);
            newHuman.gameObject.name = "Human";
            enemiesOnScene.Add(newHuman.gameObject);
        }else{
            Human newHuman = checkHuman.GetComponent<Human>();
            checkHuman.transform.position = spawnPos[randSpawnPos].position;
            checkHuman.transform.rotation = Quaternion.identity;
            newHuman.speed = Random.Range(1,9);
            checkHuman.SetActive(true);
        }
    }

    public void DestroyAllSpawned(){
        foreach(var enemy in enemiesOnScene){
            if(enemy == null){
                continue;
            }else{
                Destroy(enemy);
            }
        }
        enemiesOnScene = new List<GameObject>();
    }
}
