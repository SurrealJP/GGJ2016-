using UnityEngine;
using System.Collections;
using System;

// Stores and Generates random mugshots.
public class MugShotComponents : Singleton<MugShotComponents>
{
    [SerializeField]
    private GameObject mugShotPrefab;

    [SerializeField]
    private MugShotComponent[] spriteSets = new MugShotComponent[(int)eMugShotComponents.Count];
    [SerializeField]
    private MugShotComponentColors[] spriteColors = new MugShotComponentColors[(int)eMugShotComponents.Count];
    private System.Random rngGen = new System.Random();

    void Start()
    {
        //GameObject derp = (GameObject)GameObject.Instantiate(mugShotPrefab) as GameObject;
        GenerateMugShot(mugShotPrefab.GetComponent<MugShot>());
    }

    // Generates a random mugshot by iterating over the mugshot components and picking a random sprite from each component.
    public void GenerateMugShot(MugShot mugShot)
    {
        Sprite[] randomSpriteSet = new Sprite[(int)eMugShotComponents.Count];

        // Generate a random mug shot.
        for (int i = 0; i < spriteSets.Length; i++)
        {
            randomSpriteSet[i] = spriteSets[i].Sprites[rngGen.Next(0, spriteSets[i].Sprites.Length - 1)];
        }
        mugShot.InitMugShot(randomSpriteSet);

        // Set a random color for all of the elements.
        for (int i = 0; i < spriteColors.Length; i++)
        {
            if (spriteColors[i].UseColor)
            {
                mugShot.SetComponentColor(i, spriteColors[i].Colors[rngGen.Next(0, spriteColors[i].Colors.Length - 1)]);
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


