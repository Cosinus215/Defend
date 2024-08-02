using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public bool isAttacking;
    private SpriteRenderer spriteRenderer;
    private float speed;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (isAttacking) 
            return;

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void SetGraphics(Sprite unitGraphics) {
        spriteRenderer.sprite = unitGraphics;
    }

    public void SetSpeed(float value) {
        speed = value;
    }


}
