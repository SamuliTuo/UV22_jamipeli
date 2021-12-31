using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onkiminen : MonoBehaviour {
    
    public GameObject koukku;

    void Start() {
        
    }

    public void Ongi() {
        Vector3 pos = gameObject.transform.position;
        GameObject kouk = Instantiate(koukku, pos, Quaternion.identity);
    }

}
