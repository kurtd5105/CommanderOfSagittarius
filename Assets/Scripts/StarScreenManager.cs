using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StarScreenManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public GameObject StarmapObj;

    bool mouseDown;

    public Vector2 delta = Vector2.zero;
    public Vector2 lastPos = Vector2.zero;
    public Vector2 currPos = Vector2.zero;
    public Vector3 temp = Vector3.zero;

    void Start() {
        StarmapObj = GameObject.Find("Starmap");
        mouseDown = false;
    }

    void Update() {

        if (mouseDown == true) {
            currPos = (Vector2)Input.mousePosition;

            if (lastPos.x != 0 && lastPos.y != 0) {
                delta = currPos - lastPos;
            }
            else {
                delta = Vector2.zero;
            }

            //Debug.Log("Delta is: " + delta);
            lastPos = currPos;

            temp.x = delta.x/10f;
            temp.y = delta.y/10f;
            StarmapObj.transform.position += temp;
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        mouseDown = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        mouseDown = false;
        delta = Vector2.zero;
        lastPos = Vector2.zero;
        //Debug.Log("Delta is: " + delta);
    }
}
