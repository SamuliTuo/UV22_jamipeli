using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwable : MonoBehaviour {

    public bool inAir = false;
    Rigidbody rb;
    public float volume;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        volume = VolumeOfMesh(GetComponentInChildren<MeshFilter>().mesh);
    }

    float VolumeOfMesh(Mesh mesh) {
        float vol = 0;
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;
        for (int i = 0; i < mesh.triangles.Length; i += 3)
        {
            Vector3 p1 = vertices[triangles[i + 0]];
            Vector3 p2 = vertices[triangles[i + 1]];
            Vector3 p3 = vertices[triangles[i + 2]];
            vol += SignedVolumeOfTriangle(p1, p2, p3);
        }
        return Mathf.Abs(vol);
    }

    float SignedVolumeOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3) {
        float v321 = p3.x * p2.y * p1.z;
        float v231 = p2.x * p3.y * p1.z;
        float v312 = p3.x * p1.y * p2.z;
        float v132 = p1.x * p3.y * p2.z;
        float v213 = p2.x * p1.y * p3.z;
        float v123 = p1.x * p2.y * p3.z;
        return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
    }

    public Rigidbody GetRb() {
        return rb;
    }

    void OnCollisionEnter(Collision col) {
        foreach(ContactPoint cont in col.contacts) {
            if(col.gameObject.tag == "ship") {
                inAir = false;
                rb = GetComponent<Rigidbody>();
                Destroy(rb);
                gameObject.tag = "ship";
                print(gameObject.name);
                transform.GetChild(0).gameObject.tag = "ship";
                gameObject.transform.parent = col.transform.parent;
            }
        }
    }

    //void OnTriggerExit(Collider col) {
    //    print(col.gameObject.name);
    //}
}
