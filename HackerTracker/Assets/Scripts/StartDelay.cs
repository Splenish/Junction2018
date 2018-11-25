using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartDelay : MonoBehaviour {
    public AudioClip lowSound;
    public AudioClip highSound;

    private AudioSource audioSource;

    private int lastPlayedOn = 3;

    private float duration = 3;
    void Start() {
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }

    void Update() {
        duration -= Time.deltaTime;
        Text text = GameObject.Find("DelayText").GetComponent<Text>();
        if (duration >= 0) {
            if (lastPlayedOn > (int)duration) {
                lastPlayedOn--;
                audioSource.PlayOneShot(lowSound);
            }
            text.text = "" + ((int)duration + 1);
        }
        else if (duration >= -1) {
            if (lastPlayedOn == (int)duration) {
                lastPlayedOn--;
                audioSource.PlayOneShot(highSound);
            }
            text.text = "HACK!";
        }
        else
            SceneManager.LoadScene("Game");
    }
}