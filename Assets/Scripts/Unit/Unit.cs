using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed;
    public bool isAttacking;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (isAttacking) 
            return;

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    
}
