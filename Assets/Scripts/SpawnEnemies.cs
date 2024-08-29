using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
    private LevelTemplate levelTemplate;

    private void Start() { 

        levelTemplate = LevelManager.instance.levelTemplate;
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
