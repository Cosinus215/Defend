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
    private Weapon weapon;
    public GameObject enemy;

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
            enemy = other.gameObject;
            Attack();
        }
    }

    private bool CanAttack(Collider2D other) {
        return other.CompareTag("Unit") &&
            other.TryGetComponent(out Unit u) &&
            u.unitTeam != unitTeam;
    }

    public void DelayAttack() {
        Invoke("Attack", 2f);
    }

    private void Attack() {
        if (enemy == null || !enemy.TryGetComponent(out Unit e)) 
            return;

        if (e.GetHealth() <= 0) {
            Destroy(enemy);
        }
        weapon.Damage(e, this);
    }

    public void DecreaseHealth(float value) {
        health -= value;
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

    public void SetWeapon(Weapon w) {
        weapon = w;
    }
}
