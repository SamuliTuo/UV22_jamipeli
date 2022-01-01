using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerkill : MonoBehaviour {
    

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") { //oravanimations.current.
            OravaAnimations.current.PlayDeath();
        }
    }
}
