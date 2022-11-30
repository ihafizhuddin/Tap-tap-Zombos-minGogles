using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour{
    protected Animator anim;
    protected Collider2D cd;
    public float speed = 3f;

    protected virtual void OnEnable(){
        anim = GetComponent<Animator>();
        cd = GetComponent<Collider2D>();
        cd.enabled = true;
    }
    // Start is called before the first frame update
    protected virtual void Start(){
        anim = GetComponent<Animator>();
        cd = GetComponent<Collider2D>();
        cd.enabled = true;
        
    }

    // Update is called once per frame
    protected virtual void Update(){
        Movement();
    }
    public virtual void OnMouseDown(){
        Tapped();
    }
    protected virtual void Movement(){
        transform.Translate(Vector2.down*speed*Time.deltaTime);
    }
    protected virtual void Tapped(){}

    public void Dead(){
        this.gameObject.SetActive(false);

    }

}
