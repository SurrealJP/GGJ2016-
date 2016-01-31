using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProfilePageMugshot : MonoBehaviour
{
    [SerializeField]
    private Button button;

    DatingProfile profile;

    void Awake()
    {
        button.onClick.AddListener(() => DateTracker.Instance.SetCurrentTarget(profile) );
    }

    public void SetProfilePageMugshot(DatingProfile dProfile)
    {
        profile = dProfile;
    }
}
