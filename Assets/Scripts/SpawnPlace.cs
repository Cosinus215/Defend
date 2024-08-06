using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum team {
    Player,
    Enemy
}

[CreateAssetMenu(fileName = "SpawnPlace", menuName = "SpawnPlace/new spawn place")]
public class SpawnPlace : ScriptableObject {
    public Transform spawnPosition;
    public team unitTeam;

}
