using UnityEngine;

public class WeaponActions : StateMachineBehaviour {
    private Unit enemy;
    private Unit unit;
    private float damageValue;
    private Weapon weapon;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (unit == null) {
            return;
        }

        if (enemy == null) {
            unit.DelayAttack();
            animator.enabled = false;
            return;
        }
        weapon.TakeDamage(enemy);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (unit == null) {
            return;
        }

        unit.DelayAttack();
        animator.enabled = false;
    }

    public void SetUnits(Unit e, Unit u) {
        enemy = e;
        unit = u;
    }

    public void SetDamage(float d) { 
        damageValue = d;
    }

    public void SetWeaponScript(Weapon w) {
        weapon = w;
    }
}
