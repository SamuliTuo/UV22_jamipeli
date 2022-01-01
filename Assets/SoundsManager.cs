using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SoundsManager : MonoBehaviour {
    [SerializeField] private StudioEventEmitter heitto = null;
    [SerializeField] private StudioEventEmitter kelaus = null;
    FMOD.Studio.EventInstance bgm;
    

    public static SoundsManager current;

    private void Start() {
        current = this;
        bgm = FMODUnity.RuntimeManager.CreateInstance("event:/PELI");
        bgm.start();
    }

    public void Heitto() {
        heitto.Play();
    }

    public void Kelaus() {
        kelaus.Play();
    }

    public void FromMenuToGameTransition() {
        bgm.setParameterByName("Intensiteetti", 10, true);
    }
}