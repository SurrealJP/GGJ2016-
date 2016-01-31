using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickableMugShot : MonoBehaviour
{
    [SerializeField]
    private MugShot characterMugShot;

    [SerializeField]
    private Button button;

    private CharacterData Data;

    public void SetClickableMugshotData(CharacterData data)
    {
        Data = data;
        characterMugShot.InitMugShot(data, false);
    }

    void Awake()
    {
        button.onClick.AddListener(() => ComputerMonitor.Instance.UpdateProfilePage(Data));
    }
}
