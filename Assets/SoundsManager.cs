using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SoundsManager : MonoBehaviour {
    //[SerializeField] private StudioEventEmitter bgm = null;
    FMOD.Studio.EventInstance bgm;

    public static SoundsManager current;

    private void Start() {
        current = this;
        bgm = FMODUnity.RuntimeManager.CreateInstance("event:/MENU");
        bgm.start();
    }

    private void Update() {
    }

    public void FromMenuToGameTransition() {
        bgm.setParameterByName("Intensiteetti", 10, true);
    }
}