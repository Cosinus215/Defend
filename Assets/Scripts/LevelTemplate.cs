using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "LEvel/New Level")]
public class LevelTemplate : ScriptableObject {
    public List<UnitSpawn> unitsToSpawn = new List<UnitSpawn>();
    public SpawnPlace spawnPlace;

    public void AddToLevelManager() {
        LevelManager.instance.levelTemplate = this;
    }
}
