using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Units/New Unit")]
public class UnitSpawn : ScriptableObject {
    [SerializeField] private GameObject unit;
    [SerializeField] private float speed;
    [SerializeField] private SpawnPlace spawnPlace;
    [SerializeField] private Sprite unitGraphics;

    public void CreateUnit() {
        GameObject unitGameObject = 
            Instantiate(unit, spawnPlace.spawnPosition.position, Quaternion.identity);

        if (unitGameObject.TryGetComponent(out Unit u)) {
            u.SetSpeed(speed);
            u.SetGraphics(unitGraphics);
        }
    }
}
