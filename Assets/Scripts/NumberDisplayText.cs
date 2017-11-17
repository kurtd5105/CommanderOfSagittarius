using UnityEngine;

public class NumberDisplayText {
    public GameObject text;
    public void Init(string prefix, int number) {
        text.GetComponent<UnityEngine.UI.Text>().text = prefix + ": " + number.ToString();
    }

}
