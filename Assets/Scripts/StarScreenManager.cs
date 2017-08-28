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

    public Vector2 maxStarPositions;
    public Vector2 minStarPositions;

    public Vector3 starPos;

    void Start() {
        StarmapObj = GameObject.Find("Starmap");
        HomeworldObj = GameObject.Find("Homeworlds");
        StarmapObj.transform.localScale = new Vector3(3.0F, 3.0F, 1.0F);
        HomeworldObj.transform.localScale = StarmapObj.transform.localScale;

        mouseDown = false;
    }

    void Update() {
        mousePan();
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
            StarmapObj.transform.localScale += new Vector3(0.1F, 0.1F, 0.0F);
       
        //Scroll Down
        } else if (scroll < 0f && (StarmapObj.transform.localScale.x > 2.0F)) {
            StarmapObj.transform.localScale += new Vector3(-0.1F, -0.1F, 0.0F);
        }

        HomeworldObj.transform.localScale = StarmapObj.transform.localScale;
    }

    public void mousePan() {
        if (mouseDown) {
            starPos = StarmapObj.transform.position;
            currPos = (Vector2)Input.mousePosition;

            if (lastPos.x != 0 && lastPos.y != 0)
            {
                delta = currPos - lastPos;
            } else {
                delta = Vector2.zero;
            }

            //Starscreen pan Blocking
            //Todo: Fix boundaries they are hardcoded and incorrect.
            /*if (!((starPos.x >= -10 && delta.x > 0) || (starPos.x <= -17 && delta.x < 0)
                || (starPos.y <= -20 && delta.y < 0) || (starPos.y >= 0 && delta.y > 0))) */

            if (starPos.x + delta.x > minStarPositions.x) {
                delta.x = -starPos.x;
                Debug.Log("Constraining min X");
            }

            if (starPos.y + delta.y > minStarPositions.y) {
                delta.y = -starPos.y;
                Debug.Log("Constraining min Y");
            }

            if (starPos.x + delta.x < maxStarPositions.x) {
                delta.x = maxStarPositions.x - starPos.x;
                Debug.Log("Constraining max X");
            }

            if (starPos.y + delta.y < maxStarPositions.y) {
                delta.y = maxStarPositions.y - starPos.y;
                Debug.Log("Constraining max Y");
            }

            float divisor = 20.0f;//30.0f;
            /*if ((starPos.x <= 0 || delta.x < 0) && (starPos.y <= 0 || delta.y < 0)) */{
                //Not touching boundaries
                StarmapObj.transform.position += new Vector3(delta.x / divisor, delta.y / divisor, 0.0F);
                HomeworldObj.transform.position += new Vector3(delta.x / divisor, delta.y / divisor, 0.0F);
            }

            lastPos = currPos;
        }
    }
}
