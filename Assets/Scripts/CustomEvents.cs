using System;
using UnityEngine;

public class CustomEvents : MonoBehaviour {
    public static CustomEvents instance;

    private void Awake() {
        instance = this;
    }

    public event Action onButtonClick;
    public void ButtonClick() { 
        if (onButtonClick != null) {
            onButtonClick(); 
        }
    
    }
}
