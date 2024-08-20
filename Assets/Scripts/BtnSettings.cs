using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSettings : MonoBehaviour {
    private GameManager gameManager;
    private Button button;
    private int manaRequired;

    private void Awake() {
        button = GetComponent<Button>();
    }

    private void Start() {
        gameManager = GameManager.instance;
        AssignManaRequired();
    }

    private void FixedUpdate() {
        CheckMana();
    }

    private void CheckMana() {
        if (gameManager.mana < manaRequired) {
            button.interactable = false;
            return;
        } else {
            button.interactable = true;
        }
    }

    private void AssignManaRequired() {
        if (button.onClick.GetPersistentEventCount() == 0) {
            Debug.LogWarning($"No event Attached to this button: {button.name}!");
            return;
        }

        manaRequired = (button.onClick.GetPersistentTarget(0) as UnitSpawn).GetManaNeeded();
    }
}
