using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
    private LevelTemplate levelTemplate;
    private int enemyBaseHealth;

    private void Start() {
        enemyBaseHealth = 6;

        levelTemplate = LevelManager.instance.levelTemplate;
        if (levelTemplate == null) return;

        StartCoroutine(SpawnEnemyUnits(
            levelTemplate.unitsToSpawn, levelTemplate.spawnPlace)
        );
    }

    IEnumerator SpawnEnemyUnits(List<UnitSpawn> unitsToSpawn, SpawnPlace spawnPlace) {
        if (unitsToSpawn.Count == 0) yield return null;

        int randomUnit = Random.Range(0, unitsToSpawn.Count);

        while (enemyBaseHealth > 0) {
            yield return new WaitForSeconds(4);
            spawnPlace.CreateUnit(unitsToSpawn[randomUnit]);
        }
    }
}
