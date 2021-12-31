using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roska_gen : MonoBehaviour{

    GameObject[] roskat;
    float timer = 0f;
    [SerializeField]
    int spawnRate = 5; // amount of trash per sec
    float spawnCd = 1f;
    [SerializeField]
    float syvin = 25f;
    [SerializeField]
    float matalin = 5f;

    // Start is called before the first frame update
    void Start() {
        roskat = Resources.LoadAll<GameObject>("RoskaKansio");
        print(roskat.Length);
    }

    // Update is called once per frame
    void Update() {
        spawnCd = 1/spawnRate;
        SpawnTrash();
    }

    void SpawnTrash() {
        timer += Time.deltaTime;
        if(timer > spawnCd) {
            timer = 0;
            InstantiateTrash();
        }
    }

    void InstantiateTrash() {
        int ri = Random.Range(0,roskat.Length);
        GameObject hot_garbo = roskat[ri];
        float newy = Random.Range(syvin, matalin);
        Vector3 pos = new Vector3(transform.position.x, newy, transform.position.z);
        var new_garbo = Instantiate(hot_garbo, pos, Quaternion.identity);
    }
}
