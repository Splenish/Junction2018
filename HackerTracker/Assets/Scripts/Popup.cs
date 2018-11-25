using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour {

    
    protected float difficulty;

    
    protected bool solved;

    protected GameObject ITGuy;

	// Use this for initialization
	void Start () {
        ITGuy = GameObject.Find("Itguy");
    }
	
	// Update is called once per frame
	void Update () {
		if (solved == true) {
            Destroy(this);
        }
	}


    public void AddProgressToIT(float difficulty) {
        ITGuy.GetComponent<Itguy>().AddProgress(difficulty);
    }
}
