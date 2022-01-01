using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipStuff : MonoBehaviour {
    
    float totalVol = 0f;
    float dropSpeed = 0.004f;

    // Update is called once per frame
    void Update() {
        shipTotalVolume();
    }

    void FixedUpdate() {
        dropChildren();
    }

    void dropChildren() {
        foreach(Transform child in transform) {
            Vector3 pos = child.position;
            pos.y -= dropSpeed;
            child.position = pos;
        }
    }

    void shipTotalVolume() {
        float total = 0;
        foreach(Transform child in transform) {
            total += child.gameObject.GetComponent<throwable>().volume;
        }
        totalVol = total;
    }
}
