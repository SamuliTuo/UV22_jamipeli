using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash_code : MonoBehaviour {

    Rigidbody rb; 
    [SerializeField]
    float swimSpeed=1;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        Swim();
    }

    void Swim() {
        transform.position += new Vector3(-swimSpeed,0,0);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "koukku") {
            Koukku_script scp = other.gameObject.GetComponent<Koukku_script>();
            if(!scp.hasHaul) {
                scp.hasHaul = true;
                scp.haul = gameObject;
                scp.returning = true;
                transform.parent = other.transform;
            }
            
        }
    }
}
