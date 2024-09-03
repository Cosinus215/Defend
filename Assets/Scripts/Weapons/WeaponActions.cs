using UnityEngine;

public class WeaponActions : StateMachineBehaviour {
    public Animator animator;
    public Unit enemy;
    public Unit unit;
    public float damageValue;
    public Weapon weapon;

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
}
