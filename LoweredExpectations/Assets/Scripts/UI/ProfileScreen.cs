using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProfileScreen : ComputerScreen
{ 
    [SerializeField]
    private GameObject characterNode;

    [SerializeField]
    ScrollRect scrollRect;

    public override void ShowProfile()
    {
        base.ShowProfile();
    }

    void SetDetails(Character chara)
    {
        //age.text = chara.Profile.Age.ToString();
        //sex.text = chara.Profile.Sex;
        //location.text = chara.Profile.Location;
        //lookingFor.text = "M";

        //string bioText = "";
        //for(int i = 0; i < chara.Profile.Bio.Count; i++)
        //{
        //    bioText += chara.Profile.Bio.Text[i] + "\n";
        //}
        //biography.text = bioText;
    }

}
