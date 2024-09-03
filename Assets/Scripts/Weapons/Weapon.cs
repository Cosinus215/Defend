using UnityEngine;

public class Weapon : MonoBehaviour {
    private Animator animator;
    [SerializeField] private float damageValue;
    [SerializeField] private GameObject ammo;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void Damage(Unit e, Unit u, type unitType) {
        switch (unitType) {
            case type.meele:
                MeeleAttack(e, u);
                break;

            case type.range:
                RangeAttack(e, u);
                break;
        }
    }

    private void MeeleAttack(Unit e, Unit u) {
        if (animator == null) return;
        animator.enabled = true;

        WeaponActions weaponActions = animator.GetBehaviour<WeaponActions>();
        if (weaponActions == null) return;

        weaponActions.animator = animator;
        weaponActions.enemy = e;
        weaponActions.unit = u;
        weaponActions.damageValue = damageValue;
        weaponActions.weapon = this;
    }

    private void RangeAttack(Unit e, Unit u) {
        GameObject arrowGameobject = Instantiate(ammo, transform, false);
        
        if (arrowGameobject.TryGetComponent(out Ammo a)) {
            a.SetEnemy(e);
            a.SetUnit(u);
            a.SetWeapon(this);
        }
    }

    public void TakeDamage(Unit e) {
        e.DecreaseHealth(damageValue);
    }
}
