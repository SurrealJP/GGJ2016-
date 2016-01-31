using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

/// <summary>
/// Class for character
/// </summary>
[Serializable]
public class Character
{
    public DatingProfile Profile;
    public CharacterData CharacterData;

    public Character(DatingProfile profile, CharacterData data)
    {
        Profile = profile;
        CharacterData = data;
    }
}
[Serializable]
public class CharacterData
{
    public DatingProfile Profile;
    public Sprite[] MugShotSprites;
    public Color[] MugShotSpriteColorMods;

    public CharacterData(DatingProfile profile, Sprite[] mugShotSprites, Color[] mugShotColors)
    {
        Profile = profile;
        MugShotSprites = mugShotSprites;
        MugShotSpriteColorMods = mugShotColors;
    }
}

// This is a dating profile any information regarding who this person is is stored here.
[Serializable]
public class DatingProfile
{
    public string FirstName;
    public string LastName;
    public int Age;
    public string Sex;
    public string Location;
    public List<eInterests> characterIntersts;
    public Paragraph Bio;
    public eOrientations Orientation;

    public DatingProfile(string fN, string lN, int age, string sex, string location, List<eInterests> interests, Paragraph bio, eOrientations orientation)
    {
        FirstName = fN;
        LastName = lN;
        Age = age;
        Sex = sex;
        Location = location;
        characterIntersts = new List<eInterests>(interests);
        Bio = bio;
        Orientation = orientation;
    }
}