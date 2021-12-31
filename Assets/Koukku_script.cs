using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koukku_script : MonoBehaviour {
    
    [SerializeField]
    float y_speed = 0.1f;
    [SerializeField]
    float accpt_dist = 30f;
    public bool returning = false;
    public GameObject haul;
    public bool hasHaul = false;

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Move();
        DistCheck();
        WowAmIDead();
    }

    void Move() {
        if(returning) {
            ReturnKoukku();
        } else {
            MoveAwayKoukku();
        }
    }

    void ReturnKoukku() {
        transform.position += new Vector3(0,1*y_speed,0);
    }

    void MoveAwayKoukku() {
        transform.position += new Vector3(0,-1*y_speed,0);
    }

    void DistCheck() {
        Vector3 parentPos =  gameObject.transform.parent.position;
        if(Vector3.Distance(parentPos, transform.position)>accpt_dist) {
            returning = true;
        }
    }

    /*Koukku kohtaa pelaajan
    koukku poistetaan olevaisuudesta
    koukun saamat roskat annetaan pelaajalle
    */
    void WowAmIDead() {
        if(returning) {
            Vector3 parentPos =  gameObject.transform.parent.position;
            if(Vector3.Distance(parentPos, transform.position)<1) {
                if(hasHaul) {
                    print("myhaul: "+haul);
                    controller cont = transform.parent.gameObject.GetComponent<controller>();
                    cont.carryingThrowableThing = true;
                    cont.throwableTrash = haul;
                    //haul.GetComponent<Rigidbody>().isKinematic = true;
                    haul.transform.parent = transform.parent;
                    haul.GetComponent<trash_code>().enabled = false;
                    haul.GetComponent<throwable>().enabled = true;
                    Vector3 pos = transform.parent.position;
                    pos.y += 3f;
                    haul.transform.position = pos;
                }
                Destroy(gameObject);
            }
        }
    }

}
