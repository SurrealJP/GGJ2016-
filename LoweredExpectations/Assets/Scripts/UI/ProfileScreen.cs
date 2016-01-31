using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProfileScreen : MonoBehaviour
{ 
    [SerializeField]
    private GameObject characterNode;

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

    public void ShowProfile()
    {
        this.gameObject.SetActive(true);
        GameObject charGo = CharacterFactory.Instance.GenerateCharacter().gameObject;
        SetDetails(charGo.GetComponent<Character>());
        charGo.transform.parent = characterNode.transform;
        charGo.transform.localPosition = Vector3.zero;
    }

    void SetDetails(Character chara)
    {
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
