using UnityEngine;
using System.Collections;

// A character Mugshot
public class MugShot : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] mugShotSprites = new SpriteRenderer[(int)eMugShotComponents.Count];

    // Set the mug shot sprites
    public void InitMugShot(Sprite[] spriteArray)
    {
        for(int i = 0; i < mugShotSprites.Length && i < spriteArray.Length; i++)
        {
            mugShotSprites[i].sprite = spriteArray[i];
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
    Head = 0,
    Hair,
    Mouth,
    Eyes,
    Ears,
    Nose,
    Count
}
