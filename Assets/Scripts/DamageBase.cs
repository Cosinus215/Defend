using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBase : MonoBehaviour {
    [SerializeField] private team teamBase;

    private void OnTriggerEnter2D(Collider2D collider) {
        if (CanDamageBase(collider)) {
            switch (teamBase) {
                case team.Player:
                    GameManager.instance.DecreaseEnemyBaseHealth();
                    break;

                case team.Enemy:
                    GameManager.instance.DecreasePlayerBaseHealth();
                    break;
            }

            Destroy(collider.gameObject);
            
        }
    }

    private bool CanDamageBase(Collider2D collider) {
        return collider.CompareTag("Unit") &&
            collider.TryGetComponent(out Unit u) &&
            u.GetUnitTeam() != teamBase;
    }
}
