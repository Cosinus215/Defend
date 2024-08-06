using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Units/New Unit")]
public class UnitSpawn : ScriptableObject {
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private GameObject unit;
    //[SerializeField] private SpawnPlace spawnPlace;
    [SerializeField] private Sprite unitGraphics;

    public void CreateUnit(SpawnPlace spawnPlace) {
        GameObject unitGameObject = 
            Instantiate(unit, spawnPlace.spawnPosition.position, Quaternion.identity);

        if (unitGameObject.TryGetComponent(out Unit u)) {
            u.SetSpeed(speed);
            u.SetGraphics(unitGraphics);
            u.SetHealth(health);
            u.SetUnitTeam(spawnPlace.unitTeam);

            if (spawnPlace.unitTeam == team.Enemy &&
                u.TryGetComponent(out SpriteRenderer sR)) {
                sR.flipY = true;
                unitGameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
    }
}
