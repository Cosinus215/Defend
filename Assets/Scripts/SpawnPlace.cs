using UnityEngine;

public enum team {
    Player,
    Enemy
}

[CreateAssetMenu(fileName = "SpawnPlace", menuName = "SpawnPlace/new spawn place")]
public class SpawnPlace : ScriptableObject {
    public Transform spawnPosition;
    public team unitTeam;

    public void CreateUnit(UnitSpawn uS) {
        GameObject unitGameObject =
            Instantiate(
                uS.GetUnitTypeTemplate(),
                spawnPosition.position,
                Quaternion.identity
            );

        if (unitGameObject.TryGetComponent(out Unit u)) {
            u.SetSpeed(uS.GetSpeed());
            u.SetGraphics(uS.GetUnitGraphics());
            u.SetHealth(uS.GetHealth());
            u.SetUnitTeam(unitTeam);

            if (Instantiate(uS.GetWeapon(), u.transform).TryGetComponent(out Weapon w))
                u.SetWeapon(w);

            if (unitTeam == team.Enemy) {
                unitGameObject.transform.rotation = Quaternion.Euler(180, 0, 180);
                return;
            }
            TakeMana(uS);

        }
    }

    private void TakeMana(UnitSpawn uS) {
        GameManager.instance.DecreaseMana(uS.GetManaNeeded());
    }

}
