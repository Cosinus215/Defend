using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int mana;
    public ManaBar manaBar;
    public static GameManager instance;


    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Debug.LogError("There is more than one GameManager on the scene");
        }
    }

    private void Start() {
        StartCoroutine(SpawnUnit(LevelManager.instance.levelTemplate.unitsToSpawn, LevelManager.instance.levelTemplate.spawnPlace));
    }

    IEnumerator SpawnUnit(List<UnitSpawn> unitsToSpawn, SpawnPlace spawnPlace) {
        while (unitsToSpawn.Count > 0) {
            yield return new WaitForSeconds(4);
            unitsToSpawn[0].CreateUnit(spawnPlace);
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
}
