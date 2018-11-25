using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_desktop : Popup {

    public GameObject desktop;
    public Sprite kisse;
    public Sprite win;
    public static bool kissa = false;

	// Use this for initialization
	void Start () {
        this.transform.SetSiblingIndex(9);
        difficulty = 0.05f;
        ITGuy = GameObject.Find("Itguy");
        desktop = GameObject.Find("Image");
    }

    public void DestroyPopUp() {
        
        if (!kissa) {
            desktop.GetComponent<Image>().sprite = kisse;
        }
        else {
            desktop.GetComponent<Image>().sprite = win;
        }
        kissa = !kissa;
        
        AddProgressToIT(difficulty);
        GameObject.Destroy(this.gameObject);
    }
}
