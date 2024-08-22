using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour {
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject slider;
    public float maxSliderValue;
    public float sliderValue;
    private RectTransform backgroundRectTransform;
    private RectTransform sliderRectTransform;

    private void Awake() {
        GetRectTranform();
    }

    private void Start() {
        sliderValue = maxSliderValue;
        backgroundRectTransform.sizeDelta = new Vector2(maxSliderValue, backgroundRectTransform.sizeDelta.y);
    }

    public void UpdateManaBar(float value) {
        sliderValue = value;
        sliderRectTransform.sizeDelta = new Vector2(sliderValue, 100);
        sliderValue = Mathf.Clamp(sliderValue, 0, maxSliderValue);
    }

    private void GetRectTranform() {
        backgroundRectTransform = background.GetComponent<RectTransform>();
        sliderRectTransform = slider.GetComponent<RectTransform>();
    }

}
