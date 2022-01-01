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

    public void PlayWalk() {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("walk")) {
            anim.Play("walk", 0);
        }
    }
    public void PlayJump() {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("jump")) {
            anim.Play("jump", 0);
        }
    }
    public void PlayIdle() {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("idle")) {
            anim.Play("idle", 0);
        }
    }
    public void PlayFishing() {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("fishing")) {
            anim.Play("fishing", 0);
        }
    }
    public void PlayCarry() {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("carry")) {
            anim.Play("carry", 0);
        }
    }
    public void PlayDeath() { anim.Play("death", 0); }

}
