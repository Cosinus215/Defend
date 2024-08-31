using UnityEngine;

public class ManaBar : MonoBehaviour {
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject slider;
    private float maxSliderValue;
    private RectTransform backgroundRectTransform;
    private RectTransform sliderRectTransform;

    private void Awake() {
        GetRectTranform();
    }

    public void SetMaxMana(int value) {
        maxSliderValue = value;
    }

    public void UpdateManaBar(float newMana) {
        float sliderSize = backgroundRectTransform.sizeDelta.x;
        float manaToWidthScale = sliderSize / maxSliderValue;

        sliderRectTransform.sizeDelta = new Vector2( 
            newMana * manaToWidthScale, 25 
        );
    }

    private void GetRectTranform() {
        backgroundRectTransform = background.GetComponent<RectTransform>();
        sliderRectTransform = slider.GetComponent<RectTransform>();
    }
}
