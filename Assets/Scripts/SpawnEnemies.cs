using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
    public static SpawnEnemies instance;
    private LevelTemplate levelTemplate;
    private float unitSpawnDelay;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        levelTemplate = LevelManager.instance.GetLevelTemplate();
        unitSpawnDelay = levelTemplate.GetUnitSpawnDelay();
    }

    private void Start() {
        if (levelTemplate == null) return;

        StartCoroutine(SpawnEnemyUnits(
            levelTemplate.GetUnitsToSpawn(), levelTemplate.GetSpawnPlace())
        );
    }

    IEnumerator SpawnEnemyUnits(List<UnitSpawn> unitsToSpawn, 
        SpawnPlace spawnPlace) {

        if (unitsToSpawn.Count == 0) yield return null;

        int randomUnit = Random.Range(0, unitsToSpawn.Count);

        while (GameManager.instance.GetEnemyBaseHealth() > 0) {
            yield return new WaitForSeconds(unitSpawnDelay);
            spawnPlace.CreateUnit(unitsToSpawn[randomUnit]);
        }
    }

    public LevelTemplate GetLevelTemplate() {
        return levelTemplate;
    }
}
