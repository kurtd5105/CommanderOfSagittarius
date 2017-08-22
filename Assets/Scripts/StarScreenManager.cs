using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StarScreenManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IScrollHandler {

    public GameObject StarmapObj;
    public GameObject HomeworldObj;

    public bool mouseDown;

    public Vector2 delta = Vector2.zero;
    public Vector2 lastPos = Vector2.zero;
    public Vector2 currPos = Vector2.zero;

    void Start() {
        StarmapObj = GameObject.Find("Starmap");
        HomeworldObj = GameObject.Find("Homeworlds");
        StarmapObj.transform.localScale = new Vector3(3.0F, 3.0F, 1.0F);
        HomeworldObj.transform.localScale = StarmapObj.transform.localScale;

        mouseDown = false;
    }

    void Update() {

        if (mouseDown == true) {
            currPos = (Vector2)Input.mousePosition;

            if (lastPos.x != 0 && lastPos.y != 0) {
                delta = currPos - lastPos;
            } else {
                delta = Vector2.zero;
            }

            lastPos = currPos;

            StarmapObj.transform.position += new Vector3(delta.x / 30.0f, delta.y / 30.0f, 1.0F);
            HomeworldObj.transform.position = StarmapObj.transform.position;
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        mouseDown = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        mouseDown = false;
        delta = Vector2.zero;
        lastPos = Vector2.zero;
    }

    public void OnScroll(PointerEventData eventData)
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        //Scroll Up
        if (scroll > 0f && (StarmapObj.transform.localScale.x < 3.0F)) {
            StarmapObj.transform.localScale += new Vector3(0.1F, 0.1F, 0);
       
        //Scroll Down
        } else if (scroll < 0f && (StarmapObj.transform.localScale.x > 2.0F)) {
            StarmapObj.transform.localScale += new Vector3(-0.1F, -0.1F, 0);
        }

        HomeworldObj.transform.localScale = StarmapObj.transform.localScale;
    }
}
