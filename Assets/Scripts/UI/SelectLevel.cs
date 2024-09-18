using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {
    [SerializeField] private LevelTemplate level;
    [SerializeField] private GameObject unitsForLevelParent;
    [SerializeField] private GameObject unitIconTamplate;
    private Button button;
    private Image image;

    private void Awake() {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    private void Start() {
        if (level == null) return;

        if (level.GetIsWon()) image.color = Color.green;

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
