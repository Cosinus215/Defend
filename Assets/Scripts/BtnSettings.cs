using UnityEngine;
using UnityEngine.UI;

public class BtnSettings : MonoBehaviour {
    private GameManager gameManager;
    private Button button;
    private int manaRequired;
    [SerializeField] private SpawnPlace spawnPlace;
    [SerializeField] private UnitSpawn unitToSpawn;
    private Image buttonImage;

    private void Awake() {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
    }

    private void Start() {
        gameManager = GameManager.instance;
        CustomEvents.instance.onButtonClick += ButtonClick;
        button.onClick.AddListener(delegate { spawnPlace.CreateUnit(unitToSpawn); });
        button.onClick.AddListener(delegate { OnButtonClick(); });
        AssignManaRequired();
        AssignButtonSprite();
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
