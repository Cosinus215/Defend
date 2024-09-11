using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour {
    [SerializeField] private GameObject background;
    [SerializeField] private List<RectTransform> sliders = new List<RectTransform>();
    private float maxSliderValue;
    private Vector2 backgroundDeltaSize;

    private void Awake() {
        GetRectTranform();
    }

    public void SetMaxMana(int value) {
        maxSliderValue = value;
    }

    public void UpdateManaBar(float newMana) {
        float sliderSize = backgroundDeltaSize.x;
        float manaToWidthScale = sliderSize / maxSliderValue;

        foreach (RectTransform sliderRectTransform in sliders) {
            sliderRectTransform.sizeDelta = new Vector2(
                newMana * manaToWidthScale, 25
            );
        }
    }

    private void GetRectTranform() {
        Vector2 bakcgroundSize = background.GetComponent<RectTransform>().sizeDelta;
        backgroundDeltaSize = new Vector2(bakcgroundSize.x, bakcgroundSize.y);

    }
}
