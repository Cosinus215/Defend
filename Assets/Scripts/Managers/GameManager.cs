using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private int mana;
    [SerializeField] private ManaBar manaBar;
    public int generalBasesHealth;
    public static GameManager instance;
    private int playerBaseHealth;
    private int enemyBaseHealth;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Debug.LogError("There is more than one GameManager on the scene");
        }
    }

    private void Start() {
        enemyBaseHealth = generalBasesHealth;
        playerBaseHealth = generalBasesHealth;

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

    public int GetEnemyBaseHealth() { 
        return enemyBaseHealth;
    }

    public int DecreasePlayerBaseHealth() {
        playerBaseHealth--; 
        return playerBaseHealth;
    }
    
    public int DecreaseEnemyBaseHealth() {
        enemyBaseHealth--; 
        return enemyBaseHealth;
    } 

    private IEnumerator IncreaseMana() {
        while (true) {
            yield return new WaitForSeconds(1);
            mana += 5;
            UpdateUI();
            CustomEvents.instance.ButtonClick();
        }
    }
}
