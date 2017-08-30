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
    public Vector2 clampPos = Vector2.zero;
    public Vector2 lastPos = Vector2.zero;
    public Vector2 currPos = Vector2.zero;

    public Vector2 maxStarPositions;
    public Vector2 minStarPositions;
    public Vector2 oldmax;
    public Vector2 oldmin;

    public Vector3 starPos;

    public Vector3 scale = Vector2.zero;

    void Start() {
        StarmapObj = GameObject.Find("Starmap");
        HomeworldObj = GameObject.Find("Homeworlds");

        Debug.Log("Min x is: " + minStarPositions.x);
        oldmax = maxStarPositions;
        oldmin = minStarPositions;

        scale = new Vector3(3.0F, 3.0F, 1.0F);

        updateScale(scale.x, scale.y);

        StarmapObj.transform.position = new Vector3(((maxStarPositions.x - minStarPositions.x) / 2) - (maxStarPositions.x / 4), 
            ((maxStarPositions.y - minStarPositions.y) / 2) - (maxStarPositions.x / 4), 1.0F);
        HomeworldObj.transform.position = StarmapObj.transform.position;

        try {
            StarmapObj.transform.localScale = scale;
            HomeworldObj.transform.localScale = StarmapObj.transform.localScale;
        } catch (Exception) {
            Debug.Log("Did not create Game manager from start screen.");
        }

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
        float val = 0F;

        //Scroll Up
        if (scroll > 0f && (StarmapObj.transform.localScale.x < 3.0F)) {
            val = 0.1F;
        }

        //Scroll Down
        if (scroll < 0f && (StarmapObj.transform.localScale.x > 2.0F)) {
            val = -0.1F;
        }

        StarmapObj.transform.localScale += new Vector3(val, val, 0.0F);

        updateScale(StarmapObj.transform.localScale.x + val, StarmapObj.transform.localScale.y + val);
        Debug.Log("Scale is: " + StarmapObj.transform.localScale.x + val);

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

            //Clamp next star position between the boundaries of the stars returns value if in bounds or bounds if out.
            clampPos.x = Mathf.Clamp(starPos.x + (delta.x / 20.0F), maxStarPositions.x, minStarPositions.x);
            clampPos.y = Mathf.Clamp(starPos.y + (delta.y / 20.0F), maxStarPositions.y, minStarPositions.y);

            //X panning and boundary check.
            if ((clampPos.x != minStarPositions.x && clampPos.x != maxStarPositions.x) || 
                (((StarmapObj.transform.position.x < maxStarPositions.x) && (delta.x > 0)) || 
                ((StarmapObj.transform.position.x < maxStarPositions.x) && (delta.x > 0) ))) {

                StarmapObj.transform.position += new Vector3(delta.x / 20.0F, 0, 0.0F);
                HomeworldObj.transform.position += new Vector3(delta.x / 20.0F, 0, 0.0F);
            }

            //Y panning and boundary check.
            if ((clampPos.y != minStarPositions.y && clampPos.y != maxStarPositions.y) ||
                (((StarmapObj.transform.position.y < maxStarPositions.y) && (delta.y > 0)) ||
                ((StarmapObj.transform.position.y < maxStarPositions.y) && (delta.y > 0)))) {
                StarmapObj.transform.position += new Vector3(0, delta.y / 20.0F, 0.0F);
                HomeworldObj.transform.position += new Vector3(0, delta.y / 20.0F, 0.0F);
            }

            lastPos = currPos;
        }
    }

    public void updateScale(float scaleX, float scaleY) {
        Debug.Log(" ( " + oldmax.x + " * " + scaleX + " ) " + " + " + oldmax.x);
        Debug.Log(" ( " + oldmin.x + " * " + scaleX + " ) " + " + " + oldmin.x);
        maxStarPositions.x = (oldmax.x * scaleX) - (oldmax.x);
        maxStarPositions.y = (oldmax.y * scaleY) - (oldmax.y);
        minStarPositions.x = (oldmin.x * scaleX) - (oldmin.x);
        //minStarPositions.y = (minStarPositions.y * scaleY) + StarmapObj.transform.position.y;

        Debug.Log("New max is: " + maxStarPositions);
        Debug.Log("New min is: " + minStarPositions);
    }
}
