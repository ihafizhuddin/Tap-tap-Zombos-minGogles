using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : BaseCharacter{
    protected override void OnEnable(){}
    // Start is called before the first frame update
    protected override void Start(){
        base.Start();
    }

    // Update is called once per frame
    protected override void Update(){
        base.Update();
    }
    protected override void Tapped(){
        cd.enabled = false;
        anim.SetBool("isDead", true);
        anim.SetTrigger("Dead");
        speed = 0;
        GameManager.get.GameOver();
    }
}
