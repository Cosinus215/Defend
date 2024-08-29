using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private int mana;
    [SerializeField] private ManaBar manaBar;
    public static GameManager instance;
    private int playerBaseHealth;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Debug.LogError("There is more than one GameManager on the scene");
        }
    }

    private void Start() {
        playerBaseHealth = 6;

        StartCoroutine(IncreaseMana());
    }

    public void DecreaseMana(int value) {
        mana -= value;
        UpdateUI();
    }

    private void UpdateUI() {
        manaBar.UpdateManaBar(mana);
    }

    public int GetMana() {
        return mana;
    }

    private IEnumerator IncreaseMana() {
        while (true) {
            yield return new WaitForSeconds(2);
            mana++;
            UpdateUI();

        }
    }
}
