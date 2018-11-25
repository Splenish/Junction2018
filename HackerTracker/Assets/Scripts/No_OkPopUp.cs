using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class No_OkPopUp : Popup {

	// Use this for initialization
	void Start () {
        this.transform.SetSiblingIndex(9);
        difficulty = 0.5f;
        ITGuy = GameObject.Find("Itguy");
    }

    public void DestroyPopUp() {
        AddProgressToIT(difficulty);
        GameObject.Destroy(this.gameObject);
    }
}
