using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Units/New Unit")]
public class UnitSpawn : ScriptableObject {
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private GameObject unitTypeTemplate;
    [SerializeField] private Sprite unitGraphics;
    [SerializeField] private GameObject weapon;

    private void Reset() {
        if (unitTypeTemplate == null) {
            string unitTemplatePath = "Assets/Prefabs/Units/Types/MeleeUnitTemplate.prefab";
            unitTypeTemplate = AssetDatabase.LoadAssetAtPath<GameObject>(unitTemplatePath);
        }
    }

    public void CreateUnit(SpawnPlace spawnPlace) {
        GameObject unitGameObject = 
            Instantiate(
                unitTypeTemplate, spawnPlace.spawnPosition.position, Quaternion.identity
            );

        if (unitGameObject.TryGetComponent(out Unit u)) {
            u.SetSpeed(speed);
            u.SetGraphics(unitGraphics);
            u.SetHealth(health);
            u.SetUnitTeam(spawnPlace.unitTeam);

            if (Instantiate(weapon, u.transform).TryGetComponent(out Weapon w))
                u.SetWeapon(w);

            if (spawnPlace.unitTeam == team.Enemy) {
                unitGameObject.transform.rotation = Quaternion.Euler(180, 0, 180);
            }
        }
    }
}
