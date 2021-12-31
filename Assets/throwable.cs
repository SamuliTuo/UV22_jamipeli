using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwable : MonoBehaviour {

    public bool inAir = false;
    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public Rigidbody GetRb() {
        return rb;
    }

    void OnCollisionEnter(Collision col) {
        foreach(ContactPoint cont in col.contacts) {
            if(col.gameObject.tag == "ship") {
                inAir = false;
                rb = GetComponent<Rigidbody>();
                Destroy(rb);
                gameObject.tag = "ship";
                gameObject.transform.parent = null;
            }
        }
    }
}
