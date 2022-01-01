using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_parts_destroyer : MonoBehaviour {

    void Start() {
        
    }

    void Update() {
        
    }

    void OnTriggerExit(Collider col) {
        print(col.gameObject.name);
        if(col.gameObject.tag == "ship") {
            Destroy(col.gameObject);
        }
    }
}
