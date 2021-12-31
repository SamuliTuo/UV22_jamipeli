using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OravaAnimations : MonoBehaviour {

    public static OravaAnimations current;
    Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
        current = this;
    }

    public void RotatePlayer(Vector3 dir) {
        transform.LookAt(transform.position + dir);
    }

    public void PlayWalk() { anim.Play("walk", 0); }
    public void PlayJump() { anim.Play("jump", 0); }
    public void PlayIdle() { anim.Play("idle", 0); }
    public void PlayFishing() { anim.Play("fishing", 0); }
    public void PlayCarry() { anim.Play("carry", 0); }
    public void PlayDeath() { anim.Play("death", 0); }

}
