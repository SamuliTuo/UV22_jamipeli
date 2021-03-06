using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash_code : MonoBehaviour {

    Rigidbody rb; 
    [SerializeField]
    float swimSpeed=1;
    bool asHaul = false;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        GetComponent<throwable>().enabled = false;
    }

    void FixedUpdate() {
        Swim();
    }

    void Swim() {
        if(!asHaul) {
            transform.position += new Vector3(-swimSpeed,0,0);
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "koukku") {
            Koukku_script scp = other.gameObject.GetComponent<Koukku_script>();
            if(!scp.hasHaul) {
                asHaul = true;
                scp.hasHaul = true;
                scp.haul = gameObject;
                scp.returning = true;
                transform.parent = other.transform;
                SoundsManager.current.Kelaus();
            }
        }
    }
}
