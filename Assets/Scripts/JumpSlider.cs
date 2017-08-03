using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JumpSlider : Slider {

	// Use this for initialization
	public override void OnPointerDown(PointerEventData eventData) {
        base.OnPointerDown(eventData);

        Vector2 clickOnSlider;
        bool res = RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out clickOnSlider);

        if (res) {
            Debug.Log(clickOnSlider.x);
        } else {
            Debug.Log("Transform failed.");
        }
    }
}
