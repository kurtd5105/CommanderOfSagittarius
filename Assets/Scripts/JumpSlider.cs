using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JumpSlider : Slider {

	// Use this for initialization
	public override void OnPointerDown(PointerEventData eventData) {
        base.OnPointerDown(eventData);
        Debug.Log(eventData.pressPosition.x);
    }
}
