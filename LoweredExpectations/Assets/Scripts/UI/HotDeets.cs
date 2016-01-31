using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HotDeets : MonoBehaviour
{
    [SerializeField]
    private Text age;

    [SerializeField]
    private Text sex;

    [SerializeField]
    private Text location;

    [SerializeField]
    private Text lookingFor;

    public void SetDeets(string ageString, string sexString, string locationString, string lookingForString)
    {
        age.text = "AGE: " + ageString;
        sex.text = "SEX: " + sexString;
        location.text = "LOCATION: " + locationString;
        lookingFor.text = "LOOKING FOR: " + lookingForString;
    }
}
