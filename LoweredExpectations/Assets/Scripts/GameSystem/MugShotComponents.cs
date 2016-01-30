using UnityEngine;
using System.Collections;
using System;

// Stores and Generates random mugshots.
public class MugShotComponents : Singleton<MugShotComponents>
{
    [SerializeField]
    private MugShotComponent[] spriteSets = new MugShotComponent[(int)eMugShotComponents.Count];
    private System.Random rngGen = new System.Random();

    // Generates a random mugshot by iterating over the mugshot components and picking a random sprite from each component.
    public void GenerateMugShot(MugShot mugShot)
    {
        Sprite[] randomSpriteSet = new Sprite[(int)eMugShotComponents.Count];
        for (int i = 0; i < spriteSets.Length; i++)
        {
            randomSpriteSet[i] = spriteSets[i].Sprites[rngGen.Next(0, spriteSets[i].Sprites.Length - 1)];
        }
        mugShot.InitMugShot(randomSpriteSet);
    }
} 

[Serializable]
public class MugShotComponent
{
    public Sprite[] Sprites;
}

