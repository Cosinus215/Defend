using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.tag);
    }
}
