using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controller : MonoBehaviour {

    Rigidbody rb;
    [SerializeField] float speed = 1;
    [SerializeField] float jumpSpeed = 1;
    bool iJustJumped = false;
    bool grounded = true;
    float groundslope = 0f;
    Onkiminen onki;
    public GameObject koukku;
    [SerializeField] float dragValue = 0.00000001f;

    void Start() {
        rb = GetComponent<Rigidbody>();
        onki = GetComponent<Onkiminen>();
    }

    // Update is called once per frame
    void Update() {
        KeyboardInputs();
        GroundCheck(groundslope);
    }

    void CustomDrag() {
        Vector3 currvel = rb.velocity;
        currvel.x *=  dragValue;
        currvel.z *= dragValue;
        rb.velocity = currvel;
    }

    void KeyboardInputs() {
        Animationsmockup();
        bool noInput = true;
        if(Input.GetKey(KeyCode.E)) {
            Ongi();
            return; //laita vielä joku stoppi tähän
        }
        if(Input.GetKey(KeyCode.A)) {
            rb.AddForce(Vector3.right*-speed, ForceMode.Impulse);
            noInput = false;
            OravaAnimations.current.RotatePlayer(Vector3.left);
        }
        if(Input.GetKey(KeyCode.D)) {
            rb.AddForce(Vector3.left*-speed, ForceMode.Impulse);
            noInput = false;
            OravaAnimations.current.RotatePlayer(Vector3.right);
        }
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) 
            && grounded && !iJustJumped) {
            Jump();
            noInput = false;
        }
        if(noInput) {
            CustomDrag();
        }
        
    }

    IEnumerator IJustJumpedOhNo() {
        iJustJumped = true;
        grounded = false;
        groundslope = -1;
        yield return new WaitForSeconds(0.15f);
        iJustJumped = false;
    }

    void Jump() {
        rb.AddForce(Vector3.up*jumpSpeed, ForceMode.Impulse);
        StartCoroutine(IJustJumpedOhNo());
    }

    void GroundCheck(float groundslope) {
        if(groundslope > 0.3f) {
            grounded = true;
        } else {
            grounded = false;
        }
    }

    void Ongi() {
        if(!KoukkuActive()) {
            Vector3 pos = gameObject.transform.position;
            GameObject kouk = Instantiate(koukku, pos, Quaternion.identity);
            kouk.transform.parent = this.transform;
        } 
    }

    bool KoukkuActive() {
        bool isActive = false;
        foreach(Transform child in transform) {
            if(child.gameObject.tag == "koukku") {
                isActive = true;
            }
        }
        return isActive;
    }

    void OnCollisionStay(Collision Linf) {
        foreach(ContactPoint c in Linf.contacts) {
            if (!iJustJumped) {
                groundslope = Vector3.Dot(Vector3.up, c.normal);
            }
        }
    }

    void Animationsmockup() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            OravaAnimations.current.PlayCarry();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            OravaAnimations.current.PlayDeath();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            OravaAnimations.current.PlayFishing();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            OravaAnimations.current.PlayIdle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            OravaAnimations.current.PlayJump();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            OravaAnimations.current.PlayWalk();
        }
    }
}
