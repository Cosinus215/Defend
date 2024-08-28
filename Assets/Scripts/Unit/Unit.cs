using System.Collections.Generic;
using UnityEngine;

public enum type {
    meele, 
    range
}

public class Unit : MonoBehaviour {
    private type unitType;
    private bool isAttacking;
    private team unitTeam;
    private SpriteRenderer spriteRenderer;
    private float speed;
    private float health;
    private Weapon weapon;
    private Queue<Unit> enemyQueue = new Queue<Unit>();

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
        if (CanAttack(other, out Unit u)) {
            enemyQueue.Enqueue(u);
            isAttacking = true;
            Attack();
        }
    }

    private bool CanAttack(Collider2D other, out Unit enemyUnit) {
        enemyUnit = null;

        if (other.CompareTag("Unit") &&
            other.TryGetComponent(out Unit u) &&
            u.unitTeam != unitTeam) {
            enemyUnit = u;
            return true;
        }
        return false;
            
    }

    public void DelayAttack() {
        if (enemyQueue.Count == 0) {
            return;
        }

        if (enemyQueue.TryPeek(out Unit u) && u != null && u.GetHealth() <= 0) {
            enemyQueue.Dequeue();
            Destroy(u.gameObject); 
        }


        if (enemyQueue.Count == 0) {
            isAttacking = false;
            return;
        }

        Invoke("Attack", 2f);
    }

    private void Attack() {
        while (enemyQueue.TryPeek(out Unit u)) {
            if (u == null) {
                enemyQueue.Dequeue();
                if (enemyQueue.Count == 0) isAttacking = false;
                continue;
            }
            weapon.Damage(u, this);
            break; 
        }
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
