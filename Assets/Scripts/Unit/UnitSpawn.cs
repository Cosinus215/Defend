using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Units/New Unit")]
public class UnitSpawn : ScriptableObject {
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private GameObject unitTypeTemplate;
    [SerializeField] private Sprite unitGraphics;
    [SerializeField] private GameObject weapon;
    [SerializeField] private int manaNeeded;
    [SerializeField] private RuntimeAnimatorController animatorController;

    public int GetManaNeeded() {
        return manaNeeded;
    }

    public float GetHealth() {
        return health;
    }

    public GameObject GetWeapon() {
        return weapon;
    }

    public Sprite GetUnitGraphics() {
        return unitGraphics;
    }

    public float GetSpeed() {
        return speed; 
    }

    public GameObject GetUnitTypeTemplate() {
        return unitTypeTemplate;
    }

    public RuntimeAnimatorController GetAnimatorController() {
        return animatorController;
    }
}
