using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

// Stores and Generates random mugshots.
public class CharacterFactory : Singleton<CharacterFactory>
{ 
    [SerializeField]
    private MugShotComponent[] spriteSets = new MugShotComponent[(int)eMugShotComponents.Count];
    [SerializeField]
    private MugShotComponentColors[] spriteColors = new MugShotComponentColors[(int)eMugShotComponents.Count];
 
    private System.Random rngGen = new System.Random();

    [SerializeField]
    private List<Character> CharacterCollection;

    void Start()
    {
        CharacterCollection = new List<Character>();
        for (int i = 0; i < 50; i++)
        {
            CharacterCollection.Add(GenerateCharacter());
        }
        GenerateCharacter();
    }

    private string[] ExtractLinesFromFile(string filename)
    {
        TextAsset data = Resources.Load("Text/" + filename) as TextAsset;
        return data.text.Split("\n"[0]);
    }

    public Character GenerateCharacter()
    {
        string[] firstNames = ExtractLinesFromFile("firstnames");
        string[] lastNames = ExtractLinesFromFile("lastnames");

        string firstName = firstNames[rngGen.Next(0, firstNames.Length - 1)];
        string lastName = lastNames[rngGen.Next(0, lastNames.Length - 1)];

        List<eInterests> interests = new List<eInterests>();

        int interestCount = rngGen.Next(1, (int)eInterests.Count + 1);
        int rndInterestId = 0;

        for (int i = 0; i < interestCount; i++)
        {
            rndInterestId = rngGen.Next(0, (int)eInterests.Count);

            while (interests.Contains((eInterests)rndInterestId))
            {
                rndInterestId = rngGen.Next(0, (int)eInterests.Count);
            }

            interests.Add((eInterests)rndInterestId);
        }

        Paragraph test = InterestGenerator.GenerateBiography(firstName, interests);

        DatingProfile profile = new DatingProfile(firstName, lastName, 19, "female", "Canada", interests, test);
        CharacterData data = RandomizeSpriteData(profile);

        Character character = new Character(profile, data);

        return character;
    } 
    public CharacterData RandomizeSpriteData(DatingProfile profile)
    {
        // We'll temporarily store this information here.
        Sprite[] randomSpriteSet = new Sprite[(int)eMugShotComponents.Count];
        Color[] randomColorSet = new Color[(int)eMugShotComponents.Count];

        // Generate a random mug shot.
        for (int i = 0; i < spriteSets.Length; i++)
        {
            randomSpriteSet[i] = spriteSets[i].Sprites[rngGen.Next(0, spriteSets[i].Sprites.Length)];
        }

        // Set a random color for all of the elements.
        for (int i = 0; i < spriteColors.Length; i++)
        {
            if (spriteColors[i].UseColor)
            {
                randomColorSet[i] = spriteColors[i].Colors[rngGen.Next(0, spriteColors[i].Colors.Length)];
            }
            else
            {
                // "No color mod"
                randomColorSet[i] = Color.white;
            }
        }

        CharacterData data = new CharacterData(profile, randomSpriteSet, randomColorSet);
        return data;
    }
} 

[Serializable]
public class MugShotComponent
{
    public Sprite[] Sprites;
}

[Serializable]
public class MugShotComponentColors
{
    public Color[] Colors;
    public bool UseColor = false;
}