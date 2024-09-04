using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int generalBasesHealth;
    [SerializeField] private Transform spawnUnitButtonsPanel;
    [SerializeField] private ButtonManager buttonManager;
    [SerializeField] private GameObject wonPanel;
    [SerializeField] private GameObject lostPanel;
    [SerializeField] private int mana;
    [SerializeField] private int maxMana;
    [SerializeField] private ManaBar manaBar;
    public static GameManager instance;
    private int playerBaseHealth;
    private int enemyBaseHealth;
    private bool gameEnded;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Debug.LogError("There is more than one GameManager on the scene"); 
            Destroy(gameObject);
        }

        enemyBaseHealth = generalBasesHealth;
        playerBaseHealth = generalBasesHealth;
    }

    private void Start() {
        gameEnded = false;
        
        manaBar.SetMaxMana(maxMana);
        UpdateUI();

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

        if (playerBaseHealth <= 0) {
            EnableEndGamePanel(lostPanel);
        }

        return playerBaseHealth;
    }
    
    public int DecreaseEnemyBaseHealth() {
        enemyBaseHealth--;

        if (enemyBaseHealth <= 0) {
            EnableEndGamePanel(wonPanel);
        }

        return enemyBaseHealth;
    } 

    private void EnableEndGamePanel(GameObject panel) {
        buttonManager.ToggleAllSpawnUnitsButtons(spawnUnitButtonsPanel);
        panel.SetActive(true);
        CustomEvents.instance.EndGame();
        gameEnded = true;
    }

    private IEnumerator IncreaseMana() {
        while (!gameEnded) {
            if (mana < maxMana) {
                mana += 5;
                UpdateUI();
                mana = Mathf.Clamp(mana, 0, maxMana);
            }
            CustomEvents.instance.ButtonClick();
            yield return new WaitForSeconds(2);
        }
    }
}
