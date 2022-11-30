using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour{

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Enemy"){
            GameManager.get.DecreaseHealth();
            col.gameObject.SetActive(false);
        }else if(col.gameObject.tag == "Player"){
            GameManager.get.AddScore();
            col.gameObject.SetActive(false);

        }
    }
}
