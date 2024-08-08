using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        transform.localPosition = new Vector2(0.6f, 0.3f);
    }

    public void Damage() {
        if (animator == null) return;

        animator.enabled = true;
    }

    public void EndOfAnimation() {

    }
}
