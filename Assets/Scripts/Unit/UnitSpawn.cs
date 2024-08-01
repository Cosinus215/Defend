using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawn : MonoBehaviour {
    [SerializeField] private Transform unitsParent;

    public void CreateUnit(GameObject unit) {
        Instantiate(unit, unitsParent);
    }
}
