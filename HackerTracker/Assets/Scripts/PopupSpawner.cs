using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupSpawner : MonoBehaviour {

    public RectTransform popper;
    public RectTransform bigboi;

    private float bigY, bigX;
    private Vector3 popupLoc;

    GameObject NewestPopUp;

    public List<RectTransform> PopUpList = new List<RectTransform>();

    // Use this for initialization
    void Start () {
        bigY = bigboi.rect.height * bigboi.localScale.y;
        bigX = bigboi.rect.width * bigboi.localScale.x;
        float rng1 = Random.Range(-0.05f,0.30f);
        float rng2 = Random.Range(-0.30f,-0.10f);
        popupLoc = new Vector3(bigX * rng1, bigY * rng2, 0);
        popEm();
        InvokeRepeating("popEm", 0.3f, 1.0f);
    }

    // Update is called once per frame
    void Update () {

    }
    public void popEm() {
        float rng1 = Random.Range(-0.05f, 0.25f);
        float rng2 = Random.Range(-0.23f, -0.0f);
        popupLoc = new Vector3(bigX * rng1, bigY * rng2, -0.05f);
        int selectedPopUp = Random.Range(0,PopUpList.Count);
        Instantiate(PopUpList[selectedPopUp],popupLoc,Quaternion.identity,bigboi);

    }
}
