using UnityEngine;
using UnityEngine.UI;

public class SpawnUnitButton : MonoBehaviour {
    private GameManager gameManager;
    private Button button;
    private int manaRequired;
    [SerializeField] private SpawnPlace spawnPlace;
    [SerializeField] private UnitSpawn unitToSpawn;
    private Image buttonImage;
    private bool disabled;

    private void Awake() {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
    }

    private void Start() {
        AssignManaRequired();
        AssignButtonSprite();
        if (!SpawnEnemies.instance.levelTemplate.unitsToSpawn.Contains(unitToSpawn)) {
            buttonImage.color = Color.black;
            Destroy(button);
            Destroy(this);
            return;
        }

        if (spawnPlace.unitTeam == team.Enemy) return;

        gameManager = GameManager.instance;
        CustomEvents.instance.onButtonClick += ButtonClick;
        button.onClick.AddListener(delegate { 
            spawnPlace.CreateUnit(unitToSpawn); 
        });

        button.onClick.AddListener(delegate { 
            OnButtonClick(); 
        });

    }

    private void OnButtonClick() {
        CustomEvents.instance.ButtonClick();
    } 
    
    private void ButtonClick() {
        if (gameManager.GetMana() < manaRequired) {
            button.interactable = false;
            return;
        } 
        
        button.interactable = true;
    }

    private void AssignManaRequired() {
        manaRequired = unitToSpawn.GetManaNeeded();
    }

    private void AssignButtonSprite() {
        buttonImage.sprite = unitToSpawn.GetUnitGraphics();
    }
}
