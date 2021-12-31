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

    void WowAmIDead() {
        if(returning) {
            Vector3 parentPos =  gameObject.transform.parent.position;
            if(Vector3.Distance(parentPos, transform.position)<1) {
                if(hasHaul) {
                    print("AAAAAAAAAAAAAAAAAAAAAAAAAAA");
                    print("myhaul: "+haul);
                }
                Destroy(gameObject);
            }
        }
    }

}
