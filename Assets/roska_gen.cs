using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roska_gen : MonoBehaviour{

    GameObject[] roskat;
    GameObject[] isotRoskat;
    float timer = 0f;
    [SerializeField]
    int spawnRate = 5; // amount of trash per sec
    float spawnCd = 1f;
    [SerializeField]
    float syvin = 25f;
    [SerializeField]
    float matalin = 5f;
    [SerializeField] float rengasCd = 20f;
    float isotimer = 0f;

    void Start() {
        roskat = Resources.LoadAll<GameObject>("RoskaKansio");
        print("roskien määrä kansiossa: "+roskat.Length);
        isotRoskat = Resources.LoadAll<GameObject>("IsotRoskat");
    }

    void Update() {
        spawnCd = 1/spawnRate;
        SpawnTrash();
        SpawnBigTrash();
    }

    void SpawnTrash() {
        timer += Time.deltaTime;
        if(timer > spawnCd) {
            timer = 0;
            InstantiateTrash();
        }
    }

    void SpawnBigTrash() {
        isotimer += Time.deltaTime;
        if(isotimer > rengasCd) {
            isotimer = 0f;
            int ri = Random.Range(0,isotRoskat.Length);
            GameObject hot_garbo = isotRoskat[ri];
            float newy = Random.Range(syvin, matalin);
            Vector3 pos = new Vector3(transform.position.x, newy, transform.position.z);
            Quaternion kakka = new Quaternion(Random.Range(-180,180),Random.Range(-180,180),Random.Range(-180,180),Random.Range(-180,180));
            var new_garbo = Instantiate(hot_garbo, pos, kakka);
        }
    }

    void InstantiateTrash() {
        int ri = Random.Range(0,roskat.Length);
        GameObject hot_garbo = roskat[ri];
        float newy = Random.Range(syvin, matalin);
        Vector3 pos = new Vector3(transform.position.x, newy, transform.position.z);
        Quaternion kakka = new Quaternion(Random.Range(-180,180),Random.Range(-180,180),Random.Range(-180,180),Random.Range(-180,180));
        var new_garbo = Instantiate(hot_garbo, pos, kakka);
    }
}
