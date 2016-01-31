using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// Tracks a current date.
public class DateTracker : Singleton<DateTracker>
{
    // Tracks a date and some interests
    private DatingProfile profile;
    private List<eInterests> interests;

    [SerializeField]
    private Text dateTarget;

    [SerializeField]
    private List<Text> Interests;

    public override void Awake()
    {
        base.Awake();
        for (int i = 0; i < Interests.Count; i++)
        {
            Interests[i].gameObject.SetActive(false);
        }
    }

    public void SetCurrentTarget(DatingProfile dProfile)
    {
        profile = dProfile;
        dateTarget.text = dProfile.FirstName + " " + dProfile.LastName;

        for (int i = 0; i < Interests.Count; i++)
        {
            Interests[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < dProfile.characterIntersts.Count; i++)
        {
            Interests[i].gameObject.SetActive(true);
            Interests[i].text = "INTEREST: " + dProfile.characterIntersts[i].ToString();
        }
    }
}
