using UnityEngine;
using UnityEngine.UI;

public class ResearchMenuManager : MonoBehaviour {

    //public Text TitleText;
    //public Text DescriptionText;

    //public GameObject TitleTextObj;
    //public GameObject DescriptionTextObj;

    //public Button ResearchButton1;

    public GameObject ResearchUIObj;
    public bool researchstate = false;

    public void Init() {
        ResearchUIObj = GameObject.Find("ResearchMenu");
        ResearchUIObj.SetActive(researchstate);

        ButtonManager.MenuClick += TurnOn;

        //TitleTextObj = GameObject.Find("TitleText");
        //DescriptionTextObj = GameObject.Find("DescriptionText");

        //TitleText = TitleTextObj.GetComponent<Text>();
        //DescriptionText = DescriptionTextObj.GetComponent<Text>()
    }

    public void TurnOn() {
        researchstate = !researchstate;
        ResearchUIObj.SetActive(researchstate);
    }

    private void OnDestroy() {
        ButtonManager.MenuClick -= TurnOn;
    }
}
