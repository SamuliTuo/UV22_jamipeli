using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    [SerializeField] private float magicFloat = 0;
    Vector3 originalCamPos = new Vector3(9.10000038f, 23.7999992f, -128.199997f);
    Quaternion originalRot = new Quaternion(0.0610885508f, 0.69889015f, -0.0620516539f, 0.709908724f);

    float t = 0;
    Transform cam;
    bool goingToNewGame = false;

    void Start() {
        cam = Camera.main.transform;
        cam.position = originalCamPos;
        cam.rotation = originalRot;
        SoundsManager.current.SetIntensity(0);
    }
    void Update() {
        if (goingToNewGame) {
            LerpTheFloat();
            FlyMeToTheLoo();
        }
    }

    void LerpTheFloat() {
        t += Time.deltaTime * 0.5f;
        magicFloat = Mathf.Lerp(-2f, 6, t);
    }

    public void NewGame() {
        goingToNewGame = true;
        t = 0;
        StartCoroutine(ChangeScene());
        SoundsManager.current.FromMenuToGameTransition();
    }
    public void PlayerDiedAndCameBackToMenu() {
        cam.position = originalCamPos;
        cam.rotation = originalRot;
    }

    public void Options() {

    }

    public void QuitGame() {

    }

    public void Credits() {

    }


    IEnumerator ChangeScene() {
        yield return new WaitForSeconds(2.6f);
        goingToNewGame = false;
        SceneManager.LoadScene(1);
    }

    void FlyMeToTheLoo() {
        cam.position += (cam.up * Time.deltaTime * 1.2f + cam.forward * Time.deltaTime * 4) * magicFloat;
        cam.Rotate(cam.forward, Time.deltaTime * 10 * magicFloat);
    }
}
