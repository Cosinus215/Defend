using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {
    [SerializeField] private LevelTemplate level;
    [SerializeField] private GameObject unitsForLevelParent;
    [SerializeField] private GameObject unitIconTamplate;
    private Button button; 

    private void Awake() {
        button = GetComponent<Button>();
    }

    private void Start() {
        if (level == null) return;

        button.onClick.AddListener(delegate {
            level.AddToLevelManager(); 
        });

        AddUsedUnitsIcons();
    }

    private void AddUsedUnitsIcons() {
        foreach(UnitSpawn unit in level.GetUnitsToSpawn()) {
            GameObject unitIcon = Instantiate(unitIconTamplate, unitsForLevelParent.transform);
            if (unitIcon.TryGetComponent(out Image i)) {
                i.sprite = unit.GetUnitGraphics();
            }
        }
    }
}
