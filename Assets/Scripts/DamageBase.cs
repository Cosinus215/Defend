using TMPro;
using UnityEngine;

public class DamageBase : MonoBehaviour {
    [SerializeField] private team teamBase;
    [SerializeField] private TextMeshProUGUI baseHealthText;

    private void Start() {
        UpdateUI(GameManager.instance.GetGeneralBaseHealth());
        CustomEvents.instance.onEndGame += DestroySpawnPoints;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (CanDamageBase(collider)) {
            switch (teamBase) {
                case team.Player:
                    UpdateUI(
                        GameManager.instance.DecreasePlayerBaseHealth()
                    );
                    break;

                case team.Enemy:
                    UpdateUI(
                        GameManager.instance.DecreaseEnemyBaseHealth()
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

    private void DestroySpawnPoints() {
        Destroy(gameObject);
    }
}
