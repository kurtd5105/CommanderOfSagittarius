using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPaneSlider {
    public GameObject SliderLeftObj;
    public GameObject SliderRightObj;
    public GameObject SliderBarObj;

    public Button SliderLeft;
    public Button SliderRight;
    public Slider SliderBar;

    public void Init(string leftArrow, string rightArrow, string sliderBar, string type, InfoPaneManager manager) {
        SliderLeftObj = GameObject.Find(leftArrow);
        SliderRightObj = GameObject.Find(rightArrow);
        SliderBarObj = GameObject.Find(sliderBar);

        SliderLeft = SliderLeftObj.GetComponent<Button>();
        SliderRight = SliderRightObj.GetComponent<Button>();

        SliderLeft .onClick.AddListener(() => manager.UpdateSlider(type, -0.1f, "arrow"));
        SliderRight.onClick.AddListener(() => manager.UpdateSlider(type,  0.1f, "arrow"));

        SliderBar = SliderBarObj.GetComponent<Slider>();

        SliderBar.onValueChanged.AddListener(delegate { manager.UpdateSlider(type, SliderBar.value, "slider"); });
    }

    public void Enable(bool enable) {
        SliderLeft .enabled = enable;
        SliderRight.enabled = enable;
        SliderBar  .enabled = enable;

        //SliderLeftObj. GetComponent<Image>().enabled = enable;
        //SliderRightObj.GetComponent<Image>().enabled = enable;
    }

    public void SetValue(float value) {
        SliderBar.value = value;
    }
}
