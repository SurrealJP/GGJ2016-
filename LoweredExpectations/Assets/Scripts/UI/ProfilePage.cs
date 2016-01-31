using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProfilePage : MonoBehaviour
{
    [SerializeField]
    private MugShot characterMugShot;
    [SerializeField]
    private Text biography;
    [SerializeField]
    private HotDeets deets;

    public void SetProfilePageDetails(CharacterData data)
    {
        characterMugShot.InitMugShot(data);
        biography.text = "";
        for (int i = 0; i < data.Profile.Bio.Count; i++)
        {
            biography.text += data.Profile.Bio.Text[i] + "\n";
        }
        deets.SetDeets(data.Profile.Age.ToString(), data.Profile.Sex, data.Profile.Location, "M/F/ROBOTS");
    }
}
