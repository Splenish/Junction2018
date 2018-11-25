using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPuzzle : Popup {

	// Use this for initialization
	void Start () {
        this.transform.SetSiblingIndex(9);
        difficulty = 1f;
        ITGuy = GameObject.Find("Itguy");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ConfirmPurchase() {
        AddProgressToIT(-difficulty);
        Destroy(this.gameObject);
    }

    public void DestroyIfSolved(float parameter) {
        if(parameter == 1.0f) {
            AddProgressToIT(difficulty);
            Destroy(this.gameObject);
        }
    }
}
