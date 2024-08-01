using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Units/New Unit")]
public class UnitSpawn : ScriptableObject {
    [SerializeField] private GameObject unit;
    public float speed;
    [SerializeField] private SpawnPlace spawnPlace;

    public void CreateUnit() {
        GameObject unitGameObject = 
            Instantiate(unit, spawnPlace.spawnPosition.position, Quaternion.identity);

        if (unitGameObject.TryGetComponent(out Unit u))
            u.speed = speed;
    }
}
