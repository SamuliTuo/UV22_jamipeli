using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    [SerializeField] float magicFloat = 0;

    float t = 0;
    Transform cam;
    bool gameStarted = false;

    void Start() {
        cam = Camera.main.transform;
    }
    void Update() {
        if (gameStarted) {
            LerpTheFloat();

            cam.position += (cam.up * Time.deltaTime * 1.2f + cam.forward * Time.deltaTime * 4) * magicFloat;
            cam.Rotate(cam.forward, 0.09f * magicFloat);
        }
    }

    void LerpTheFloat() {
        t += Time.deltaTime * 0.5f;
        magicFloat = Mathf.Lerp(-2f, 6, t);
    }

    public void NewGame() {
        gameStarted = true;
        t = 0;
        StartCoroutine(ChangeScene());
        SoundsManager.current.FromMenuToGameTransition();
    }

    public void Options() {

    }

    public void QuitGame() {

    }

    public void Credits() {

    }


    IEnumerator ChangeScene() {
        yield return new WaitForSeconds(2.6f);
        SceneManager.LoadScene(1);
    }
}
