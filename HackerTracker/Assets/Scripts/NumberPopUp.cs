using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberPopUp : Popup {

    int howManygone = 0;
    
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    // Use this for initialization
    void Start () {
	    this.transform.SetSiblingIndex(9);
        difficulty = 1f;
        ITGuy = GameObject.Find("Itguy");
    }
	
	// Update is called once per frame
	void Update () {
        /*if(Input.GetMouseButtonDown(0)) {
            Debug.Log("paska");
            this.transform.SetSiblingIndex(1);
        }*/
        RaycastHit2D hit = Physics2D.Raycast(transform.position,-Vector2.up);
        if(hit.collider != null && hit.collider.gameObject.tag == "PopUp") {
            Debug.Log("jespaskaa");
            hit.collider.gameObject.transform.SetSiblingIndex(1);
        }

    }
    public void OnPointerClick(PointerEventData eventData) {
        eventData.selectedObject.gameObject.transform.SetSiblingIndex(1);
    }


    public void DestroyButton1() {
        if(howManygone == 0) {
            GameObject.Destroy(button1);
            howManygone++;
        }
    }
    public void DestroyButton2() {
        if(howManygone == 1) {
            GameObject.Destroy(button2);
            howManygone++;
        }
    }
    public void DestroyButton3() {
        if(howManygone == 2) {
            GameObject.Destroy(button3);
            howManygone++;
        }
    }
    public void DestroyButton4() {
        if(howManygone == 3) {
            AddProgressToIT(difficulty);
            GameObject.Destroy(this.gameObject);          
        }
    }


}
