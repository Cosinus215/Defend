using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private int mana;
    [SerializeField] private ManaBar manaBar;
    public static GameManager instance;
    private LevelTemplate levelTemplate;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Debug.LogError("There is more than one GameManager on the scene");
        }
    }

    private void Start() {
        levelTemplate = LevelManager.instance.levelTemplate;
        if (levelTemplate == null) return;

        StartCoroutine(SpawnUnit(
            levelTemplate.unitsToSpawn, levelTemplate.spawnPlace)
        );
    }

    IEnumerator SpawnUnit(List<UnitSpawn> unitsToSpawn, SpawnPlace spawnPlace) {
        while (unitsToSpawn.Count > 0) {
            yield return new WaitForSeconds(4);
            spawnPlace.CreateUnit(unitsToSpawn[0]);
        }
    }

    private void OnValidate() {
        manaBar.maxSliderValue = mana;
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
}
