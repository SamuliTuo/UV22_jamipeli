using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parcon : MonoBehaviour {
    
    GameObject vesi;
    GameObject tausta;
    GameObject vesi2;
    GameObject tausta2;
    GameObject sieni1;
    GameObject sieni2;
    [SerializeField] float vesiMovementKerroin = 0.1f;
    [SerializeField] float taustaMovementKerroin = 0.1f;
    [SerializeField] float sieniKerroin = 0.13f;
    List<GameObject> taustat = new List<GameObject>();
    List<GameObject> vedet = new List<GameObject>();
    List<GameObject> sienet = new List<GameObject>();

    void Start() {
        vesi = transform.GetChild(1).gameObject;
        tausta = transform.GetChild(0).gameObject;
        vesi2 = transform.GetChild(3).gameObject;
        tausta2 = transform.GetChild(2).gameObject;
        taustat.Add(tausta);
        taustat.Add(tausta2);
        vedet.Add(vesi);
        vedet.Add(vesi2);
        sieni1 = transform.GetChild(4).gameObject;
        sieni2 = transform.GetChild(5).gameObject;
        sienet.Add(sieni1);
        sienet.Add(sieni2);
    }

    void FixedUpdate() {
        VesiMovement();
        TaustaMovement();
        TaustaMover();
        VesiMover();
    }

    void VesiMover() {
        foreach(GameObject v in vedet) {
            if(v.transform.position.x >= 75) {
                float width = v.GetComponent<MeshFilter>().mesh.bounds.extents.x;
                width = width * v.transform.localScale.x * 2;
                v.transform.position -= new Vector3(width*2f, 0, 0);
            }
        }
    }

    void SieniMover() {
        foreach(GameObject s in sienet) {
            if(s.transform.position.x <= 10000) {
                float width = s.GetComponent<MeshFilter>().mesh.bounds.extents.x;
                width = width * s.transform.localScale.x * 2;
                s.transform.position += new Vector3(width*2f, 0, 0);
            }
        }
    }

    void TaustaMover() {
        foreach(GameObject t in taustat) {
            if(t.transform.position.x <= -69) {
                float width = t.GetComponent<MeshFilter>().mesh.bounds.extents.x;
                width = width * t.transform.localScale.x * 2;
                t.transform.position += new Vector3(width*2f, 0, 0);
            }
        }
    }

    void SieniMovement() {
        foreach(GameObject s in sienet) {
            s.transform.position -= Vector3.left*sieniKerroin;
        }
    }

    void VesiMovement() {
        foreach(GameObject v in vedet) {
            v.transform.position -= Vector3.left*vesiMovementKerroin;
        }
    }
    
    void TaustaMovement() {
        foreach(GameObject t in taustat) {
            t.transform.position += Vector3.left*taustaMovementKerroin;
        }
    }   
}
