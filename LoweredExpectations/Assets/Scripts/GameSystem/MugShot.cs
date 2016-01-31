﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A character Mugshot
public class MugShot : MonoBehaviour
{
    [SerializeField]
    private Image[] mugShotSprites = new Image[(int)eMugShotComponents.Count];

    [SerializeField]
    private Image teeth;

    // Set the mug shot sprites
    public void InitMugShot(Sprite[] spriteArray)
    {
        for (int i = 0; i < mugShotSprites.Length && i < spriteArray.Length; i++)
        {
            mugShotSprites[i].sprite = spriteArray[i];
        }

        if (mugShotSprites[(int)eMugShotComponents.Lips].sprite.name == "femalelips2")
        {
            teeth.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }

    public void SetComponentColor(int element, Color color)
    {
        if(mugShotSprites[element] != null)
        {
            if (mugShotSprites[element].sprite != null)
            {
                mugShotSprites[element].color = color;
            }
        }
    }
}

public enum eMugShotComponents
{
    Head = 0, // 0
    Hair,    // 1
    Lips, // 2
    Eyebrows, // 3
    Nose, //4 
    EyesIris, //5
    EyesPupil, //6
    EyeLiner, //7
    Clothes, // 8
    Count // 9
}
