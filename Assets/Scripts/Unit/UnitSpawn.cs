using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Units/New Unit")]
public class UnitSpawn : ScriptableObject {
    [SerializeField] private GameObject unit;
    [SerializeField] private SpawnPlace spawnPlace;

    public void CreateUnit() {
        Instantiate(unit, spawnPlace.spawnPosition.position, Quaternion.identity);
    }
}
