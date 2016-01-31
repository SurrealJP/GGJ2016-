using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A character Mugshot
public class MugShot : MonoBehaviour
{
    [SerializeField]
    private Image[] mugShotSprites = new Image[(int)eMugShotComponents.Count];

    [SerializeField]
    private Image teeth;

    [SerializeField]
    private Sprite eyeShadow1;

    [SerializeField]
    private Sprite eyeShadow2;

    [SerializeField]
    private Text namePlate;

    [SerializeField]
    private GameObject namePlateNode;

    // Set the mug shot sprites
    public void InitMugShot(Sprite[] spriteArray, string name)
    {
        for (int i = 0; i < mugShotSprites.Length && i < spriteArray.Length; i++)
        {
            mugShotSprites[i].sprite = spriteArray[i];
        }

        if (mugShotSprites[(int)eMugShotComponents.Lips].sprite.name == "femalelips2")
        {
            teeth.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }

        namePlate.text = name;
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

    public void InitMugShot(CharacterData data, bool showNamePlage = true)
    {
        for (int i = 0; i < mugShotSprites.Length && i < data.MugShotSprites.Length; i++)
        {
            // hack for forcing eyeliners.. OVERSIGHT!
            if (i == (int)eMugShotComponents.EyeLiner)
            {
                if (mugShotSprites[(int)eMugShotComponents.Head].sprite.name == "face")
                {
                    mugShotSprites[i].sprite = eyeShadow1;
                }
                else
                {
                    mugShotSprites[i].sprite = eyeShadow2;
                }
            }
            else
            {
                mugShotSprites[i].sprite = data.MugShotSprites[i];
            }
            mugShotSprites[i].color = data.MugShotSpriteColorMods[i];
        }

        if (mugShotSprites[(int)eMugShotComponents.Lips].sprite.name == "femalelips2")
        {
            teeth.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
        else
        {
            teeth.color = Color.white;
        }

        namePlate.text = data.Profile.FirstName + " " + data.Profile.LastName;

        namePlateNode.SetActive(showNamePlage);
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
    Background,
    Count // 9
}
