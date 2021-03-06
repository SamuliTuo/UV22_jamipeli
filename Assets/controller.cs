using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controller : MonoBehaviour {

    Rigidbody rb;
    [SerializeField]
    float speed = 1;
    [SerializeField]
    float jumpSpeed = 1;
    [SerializeField]
    float throwForce = 5;
    bool iJustJumped = false;
    bool grounded = true;
    float groundslope = 0f;
    Onkiminen onki;
    public GameObject koukku;
    public GameObject ThrowableDebug;
    [SerializeField]
    float dragValue = 0.00000001f;
    string facing = "left";
    public bool carryingThrowableThing = false;
    public GameObject throwableTrash;
    Transform model;
    //Animator onkiAnim;

    float throwDebugCd = 0f;

    void Start() {
        rb = GetComponent<Rigidbody>();
        onki = GetComponent<Onkiminen>();
        //onkiAnim = transform.GetChild(0).GetChild(2).GetComponent<Animator>();
        model = transform.GetChild(0);
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
        bool noInput = true;
        if(Input.GetKey(KeyCode.E) && !carryingThrowableThing) {
            Ongi();
            return; //laita vielä joku stoppi tähän
        }
        ThrowingDebug();
        ThrowActual();
        if(Input.GetKey(KeyCode.A)) {
            rb.AddForce(Vector3.right*-speed, ForceMode.Impulse);
            noInput = false;
            model.LookAt(model.position + Vector3.left);
            if (grounded && !iJustJumped) {
                OravaAnimations.current.PlayWalk();
            }
            facing = "left";
        }
        if(Input.GetKey(KeyCode.D)) {
            rb.AddForce(Vector3.left*-speed, ForceMode.Impulse);
            noInput = false;
            model.LookAt(model.position + Vector3.right);
            if (grounded && !iJustJumped) {
                OravaAnimations.current.PlayWalk();
            }
            facing = "right";
        }
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) 
            && grounded && !iJustJumped) {
            Jump();
            OravaAnimations.current.PlayJump();
            noInput = false;
        }
        if(noInput) {
            if (grounded && !iJustJumped) {
                OravaAnimations.current.PlayIdle();
            }
            CustomDrag();
        }
        
    }
    
    void ThrowActual() {
        if(carryingThrowableThing && Input.GetKeyDown(KeyCode.R)) {
            carryingThrowableThing = false;
            //Rigidbody ttrb = throwableTrash.GetComponent<Rigidbody>();
            //ttrb.useGravity = true;
            throwableTrash.GetComponent<throwable>().inAir = true;
            Rigidbody ttrb= throwableTrash.AddComponent<Rigidbody>();
            Destroy(throwableTrash.GetComponent<trash_code>());
            if(facing == "left") {
                ttrb.AddForce(Vector3.left*throwForce, ForceMode.Impulse);
                //add torque kääntää
            } else {
                ttrb.AddForce(Vector3.right*throwForce, ForceMode.Impulse);
            }
        }
    }

    void ThrowingDebug() {
        throwDebugCd += Time.deltaTime;
        if(throwDebugCd > 1f && Input.GetKeyDown(KeyCode.G)) {
            Vector3 pos = transform.position;
            pos.y +=3f;
            var thr = Instantiate(ThrowableDebug, pos, Quaternion.identity);
            Rigidbody rbod = thr.GetComponent<throwable>().GetRb();
            thr.GetComponent<throwable>().inAir = true;
            if(facing == "left") {
                rbod.AddForce(Vector3.left*throwForce, ForceMode.Impulse);
            } else {
                rbod.AddForce(Vector3.right*throwForce, ForceMode.Impulse);
            }
            throwDebugCd = 0f;
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
            SoundsManager.current.Heitto();
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
    
    public void OnkiPois() {
        //onkiAnim.Play("onkipois", 0);
    }
}
