using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberDisplayText {
    public GameObject text;
    public void Init(string prefix, int number/*, GameObject toInstantiate, Vector3 position*/) {
        //char[] s = new char[prefix.Length + 6];
        //for (int i = 0; i < prefix.Length; i++) {
        //    s[i] = prefix[i];
        //}
        //s[prefix.Length + 1] = ':';
        //s[prefix.Length + 2] = ' ';
        //string num = number.ToString();
        //for (int i = num.Length; i > 0; i--) {
        //    //s[prefix.Length];
        //}
        //for (int i = 0; i < num.Length; i++) {
        //    s[i] = prefix[i];
        //}
        //s[prefix.Length + 5] = '\0';
        //text = Instantiate(toInstantiate, position, Quaternion.identity) as GameObject;
        text.GetComponent<UnityEngine.UI.Text>().text = prefix;
    }

}
