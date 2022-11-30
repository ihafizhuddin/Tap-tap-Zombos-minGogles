using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseCharacter{
    public string enemyName;
    public int health = 1;

    protected override void OnEnable(){
        base.OnEnable();
        // anim = GetComponent<Animator>();
        // cd = GetComponent<Collider2D>();
        anim.SetBool("isDead", false);
        // cd.enabled = true;

    }

    // Start is called before the first frame update
    protected override void Start(){
        base.OnEnable();
        // anim = GetComponent<Animator>();
        // cd = GetComponent<Collider2D>();
        anim.SetBool("isDead", false);
        
    }

    // Update is called once per frame
    protected override void Update(){
        base.Update();
        // transform.Translate(Vector2.down*speed*Time.deltaTime);
    }
    
    protected override void Tapped(){
        health--;
        if(health <= 0){
            cd.enabled = false;
            GameManager.get.AddScore();
            AudioManager.ins.playSFX("get_score");
            anim.SetBool("isDead", true);
            anim.SetTrigger("Dead");
            speed = 0;
            Invoke("Dead", 1f);
            // Destroy(gameObject);
        }
    }
    
}
