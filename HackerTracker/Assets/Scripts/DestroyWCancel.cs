using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWCancel : MonoBehaviour {

    [SerializeField]
    GameObject destro;

    public void StabIt() {
        Destroy(destro);
    }
}
