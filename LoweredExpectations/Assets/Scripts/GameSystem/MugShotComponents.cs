using UnityEngine;
using System.Collections;
using System;

// Stores and Generates random mugshots.
public class MugShotComponents : Singleton<MugShotComponents>
{
    [SerializeField]
    private Character charPrefab;

    [SerializeField]
    private MugShotComponent[] spriteSets = new MugShotComponent[(int)eMugShotComponents.Count];
    [SerializeField]
    private MugShotComponentColors[] spriteColors = new MugShotComponentColors[(int)eMugShotComponents.Count];
    private System.Random rngGen = new System.Random();

    void Start()
    {
        GenerateCharacter();
    }

    private string[] ExtractLinesFromFile(string filename)
    {
        TextAsset data = Resources.Load("Text/" + filename) as TextAsset;
        return data.text.Split("\n"[0]);
    }

    public void GenerateCharacter()
    {
        string[] firstNames = ExtractLinesFromFile("firstnames");
        string[] lastNames = ExtractLinesFromFile("lastnames");

        string firstName = firstNames[rngGen.Next(0, firstNames.Length - 1)];
        string lastName = lastNames[rngGen.Next(0, lastNames.Length - 1)];

        GameObject character = (GameObject)GameObject.Instantiate(charPrefab.gameObject) as GameObject;
        character.name = firstName + "_" + lastName;
        Character newChar = character.GetComponent<Character>();
        DatingProfile profile = new DatingProfile(firstName, lastName, 19);
        newChar.SetCharacterProperties(profile);
        GenerateMugShot(newChar.MugShot);
    }

    // Generates a random mugshot by iterating over the mugshot components and picking a random sprite from each component.
    public void GenerateMugShot(MugShot mugShot)
    {
        Sprite[] randomSpriteSet = new Sprite[(int)eMugShotComponents.Count];

        // Generate a random mug shot.
        for (int i = 0; i < spriteSets.Length; i++)
        {
            randomSpriteSet[i] = spriteSets[i].Sprites[rngGen.Next(0, spriteSets[i].Sprites.Length)];
        }
        mugShot.InitMugShot(randomSpriteSet);

        // Set a random color for all of the elements.
        for (int i = 0; i < spriteColors.Length; i++)
        {
            if (spriteColors[i].UseColor)
            {
                mugShot.SetComponentColor(i, spriteColors[i].Colors[rngGen.Next(0, spriteColors[i].Colors.Length)]);
            }
        }
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


