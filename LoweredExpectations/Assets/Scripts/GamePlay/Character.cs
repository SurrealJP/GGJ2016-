using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Class for character
/// </summary>
public class Character : MonoBehaviour
{
    [SerializeField]
    private MugShot mugShot;
    public MugShot MugShot
    {
        get { return mugShot; }    
    }

    [SerializeField]
    private Text text; 

    public DatingProfile Profile;

    // This will set the character
    public void SetCharacterProperties(DatingProfile profile)
    {
        Profile = profile;
        text.text = string.Format("{0} {1}", profile.FirstName, profile.LastName);
    }
}

// This is a dating profile any information regarding who this person is is stored here.
public class DatingProfile
{
    public string FirstName;
    public string LastName;
    public int Age;
    public List<eInterests> characterIntersts;
    public Paragraph Bio;

    public DatingProfile(string fN, string lN, int age, List<eInterests> interests, Paragraph bio)
    {
        FirstName = fN;
        LastName = lN;
        Age = age;
        characterIntersts = new List<eInterests>(interests);
        Bio = bio;
    }

    public DatingProfile(string fN, string lN, int age)
    {
        FirstName = fN;
        LastName = lN;
        Age = age;
        //characterIntersts = new List<eInterests>(interests);
       // Bio = bio;
    }
}