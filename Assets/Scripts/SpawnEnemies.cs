using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
    public static SpawnEnemies instance;
    public LevelTemplate levelTemplate;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        levelTemplate = LevelManager.instance.levelTemplate;
    }

    private void Start() {
        
        if (levelTemplate == null) return;

        StartCoroutine(SpawnEnemyUnits(
            levelTemplate.unitsToSpawn, levelTemplate.spawnPlace)
        );
    }

    IEnumerator SpawnEnemyUnits(List<UnitSpawn> unitsToSpawn, SpawnPlace spawnPlace) {
        if (unitsToSpawn.Count == 0) yield return null;

        int randomUnit = Random.Range(0, unitsToSpawn.Count);

        while (GameManager.instance.GetEnemyBaseHealth() > 0) {
            yield return new WaitForSeconds(4);
            spawnPlace.CreateUnit(unitsToSpawn[randomUnit]);
        }
    }
}
