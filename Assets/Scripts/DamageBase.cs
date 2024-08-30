using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageBase : MonoBehaviour {
    [SerializeField] private team teamBase;
    [SerializeField] private TextMeshProUGUI baseHealthText;

    private void Start() {
        UpdateUI(GameManager.instance.generalBasesHealth);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (CanDamageBase(collider)) {
            switch (teamBase) {
                case team.Player:
                    UpdateUI(
                        GameManager.instance.DecreaseEnemyBaseHealth()
                    );
                    break;

                case team.Enemy:
                    UpdateUI(
                        GameManager.instance.DecreasePlayerBaseHealth()
                    );
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

    private void UpdateUI(int value) {
        baseHealthText.SetText($"Health: {value}");
    }
}
