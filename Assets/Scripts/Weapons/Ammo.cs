using UnityEngine;

public class Ammo : MonoBehaviour {
    private Unit enemy;
    private Unit unit;
    private Weapon weapon;

    private void Update() {
        Move();
        Rotate();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (HitEnemy(collider)) {
            Destroy(gameObject);
        }
    }

    private bool HitEnemy(Collider2D collider) {
        return collider.CompareTag("Unit") && 
            collider.gameObject == enemy.gameObject;
    }

    private void Move() {
        transform.position = Vector2.MoveTowards(
            transform.position, enemy.transform.position, 10 * Time.deltaTime
        );
    }

    private void OnDestroy() {
        weapon.TakeDamage(enemy);
        unit.DelayAttack();
    }

    private void Rotate() {
        Vector3 enemyPos = enemy.transform.position;

        enemyPos.z = 0f;
        enemyPos.x -= transform.position.x;
        enemyPos.y -= transform.position.y;

        float angle = Mathf.Atan2(enemyPos.y, enemyPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void SetEnemy(Unit e) {
        enemy = e; 
    }
    
    public void SetUnit(Unit u) {
        unit = u; 
    } 
    
    public void SetWeapon(Weapon w) {
        weapon = w; 
    }
}
