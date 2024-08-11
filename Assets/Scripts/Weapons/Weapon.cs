using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    private Animator animator;
    [SerializeField] private float damageValue;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        transform.localPosition = new Vector2(0.6f, 0.3f);
    }

    public void Damage(Unit e, Unit u) {
        if (animator == null) return;

        animator.enabled = true;

        WeaponActions weaponActions = animator.GetBehaviour<WeaponActions>();
        if (weaponActions == null) return;

        weaponActions.animator = animator;
        weaponActions.enemy = e;
        weaponActions.unit = u;
        weaponActions.damageValue = damageValue;
    }
}
