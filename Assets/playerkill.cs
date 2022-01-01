using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerkill : MonoBehaviour {
    

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") { //oravanimations.current.
            OravaAnimations.current.PlayDeath();

        }
    }

    IEnumerator MoveToMainMenu() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
