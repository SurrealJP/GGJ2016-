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
    private ClickableMugShot clickPrefab;

    [SerializeField]
    private GameObject contentNode;

    public override void ShowProfile()
    {
        base.ShowProfile();
        profilePage.SetProfilePageDetails(CharacterFactory.Instance.CharacterCollection[0].CharacterData);

        for(int i = 0; i < CharacterFactory.Instance.CharacterCollection.Count; i++)
        {
            GameObject newClickableGo = GameObject.Instantiate(clickPrefab.gameObject);
            newClickableGo.transform.SetParent(contentNode.transform);

            newClickableGo.GetComponent<ClickableMugShot>().SetClickableMugshotData(CharacterFactory.Instance.CharacterCollection[i].CharacterData);
        }
    }

    public void UpdateProfilePage(CharacterData data)
    {
        profilePage.SetProfilePageDetails(data);
    }

    int count = 0;
    public void Update()
    {
        //if(Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    count++;
        //    if (CharacterFactory.Instance.CharacterCollection.Count > count)
        //    {
        //        profilePage.SetProfilePageDetails(CharacterFactory.Instance.CharacterCollection[count].CharacterData);
        //    }
        //}
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
