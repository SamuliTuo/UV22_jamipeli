using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parcon : MonoBehaviour {
    
    GameObject vesi;
    GameObject tausta;
    GameObject vesi2;
    GameObject tausta2;
    [SerializeField] float vesiMovementKerroin = 0.1f;
    [SerializeField] float taustaMovementKerroin = 0.1f;
    List<GameObject> taustat = new List<GameObject>();

    void Start() {
        vesi = transform.GetChild(1).gameObject;
        tausta = transform.GetChild(0).gameObject;
        vesi2 = transform.GetChild(3).gameObject;
        tausta2 = transform.GetChild(2).gameObject;
        taustat.Add(tausta);
        taustat.Add(tausta2);
    }

    void FixedUpdate() {
        VesiMovement();
        TaustaMovement();
        TaustaMover();
    }

    void VesiMover() {
        
    }

    void TaustaMover() {
        //if pos = Vector3(-69,-12,-5.29409981) -> move
        foreach(GameObject t in taustat) {
            if(t.transform.position.x <= -69) {
                float width = t.GetComponent<MeshFilter>().mesh.bounds.extents.x;
                width = width * t.transform.localScale.x * 2;
                t.transform.position += new Vector3(width*2f, 0, 0);
            }
        }
    }

    void VesiMovement() {
        vesi.transform.position -= Vector3.left*vesiMovementKerroin;
    }
    
    void TaustaMovement() {
        foreach(GameObject t in taustat) {
            t.transform.position += Vector3.left*taustaMovementKerroin;
        }
    }   
}
