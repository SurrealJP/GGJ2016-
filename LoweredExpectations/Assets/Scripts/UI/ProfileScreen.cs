using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProfileScreen : ComputerScreen
{
    [SerializeField]
    private GameObject characterNode;

    [SerializeField]
    private ProfilePage profilePage;

    [SerializeField]
    ScrollRect scrollRect;

    public override void ShowProfile()
    {
        base.ShowProfile();
        profilePage.SetProfilePageDetails(CharacterFactory.Instance.CharacterCollection[0].CharacterData);
    }

    int count = 0;
    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            count++;
            if (CharacterFactory.Instance.CharacterCollection.Count > count)
            {
                profilePage.SetProfilePageDetails(CharacterFactory.Instance.CharacterCollection[count].CharacterData);
            }
        }
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
