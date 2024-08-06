using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum type {
    meele, 
    range
}

public class Unit : MonoBehaviour {
    [SerializeField] private type unitType;
    public bool isAttacking;
    private team unitTeam;
    private SpriteRenderer spriteRenderer;
    private float speed;
    private float health;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Start() { 
        isAttacking = false;
    }

    private void Update() {
        if (isAttacking) 
            return;

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (CanAttack(other)) {
            isAttacking = true;
            StartCoroutine(Attack(other));
        }
    }

    private bool CanAttack(Collider2D other) {
        return other.CompareTag("Unit") &&
            other.TryGetComponent(out Unit u) &&
            u.unitTeam != unitTeam;
    }

    private IEnumerator Attack(Collider2D enemy) {
        if (!enemy.TryGetComponent(out Unit u)) 
            yield return null;
        

        while (true) {
            yield return new WaitForSeconds(1);
            u.SetHealth(u.GetHealth()-10);
        }
    }

    public void SetGraphics(Sprite unitGraphics) {
        spriteRenderer.sprite = unitGraphics;
    }

    public void SetSpeed(float value) {
        speed = value;
    }

    public void SetHealth(float value) { 
        health = value; 
    }

    public float GetHealth() {
        return health;
    }

    public void SetUnitTeam(team uTeam) {
        unitTeam = uTeam;
    }
}
