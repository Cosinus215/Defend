using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level/New Level")]
public class LevelTemplate : ScriptableObject {
    [SerializeField] private List<UnitSpawn> unitsToSpawn = new List<UnitSpawn>();
    [SerializeField] private SpawnPlace spawnPlace;
    [SerializeField] private float unitSpawnDelay;
    [SerializeField] private bool isWon;

    public void AddToLevelManager() {
        LevelManager.instance.SetLevelTemplate(this);
    }

    public float GetUnitSpawnDelay() { 
        return unitSpawnDelay;
    }

    public List<UnitSpawn> GetUnitsToSpawn() {
        return unitsToSpawn;
    }

    public SpawnPlace GetSpawnPlace() { 
        return spawnPlace;
    }

    public bool GetIsWon() { 
       return isWon; 
    }

    public void SetIsWon(bool value) {
        isWon = value;
    }
}
