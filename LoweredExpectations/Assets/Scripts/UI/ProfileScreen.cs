using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProfileScreen : MonoBehaviour
{
    [SerializeField]
    private Character character;

    [SerializeField]
    private Text age;

    [SerializeField]
    private Text sex;

    [SerializeField]
    private Text location;

    [SerializeField]
    private Text lookingFor;

    [SerializeField]
    private Text biography;

    void Start()
    {
        character = MugShotComponents.Instance.GenerateCharacter();
        SetDetails(character);
    }

    void SetDetails(Character chara)
    {
        character = chara;
        age.text = chara.Profile.Age.ToString();
        sex.text = chara.Profile.Sex;
        location.text = chara.Profile.Location;
        lookingFor.text = "M";

        string bioText = "";
        for(int i = 0; i < chara.Profile.Bio.Count; i++)
        {
            bioText += chara.Profile.Bio.Text[i] + "\n";
        }
        biography.text = bioText;
    }

}
