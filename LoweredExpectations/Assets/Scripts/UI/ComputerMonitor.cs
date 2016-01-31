using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// This thing is the root of the game. It's also a canvas. Since we use only UI for the game.
public class ComputerMonitor : Singleton<ComputerMonitor>
{
    [SerializeField]
    private Canvas mainCanvas;

    [SerializeField]
    private ProfileScreen profileScreen;

    public override void Awake()
    {
        GameSystem.Instance.OnGameStateChanged += HandleOnGameStateChanged;
        base.Awake();
    }

    //Use this for initialization
    void Start()
    {
        profileScreen.ShowProfile();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleOnGameStateChanged(eGameState toState)
    {
        switch (toState)
        {
            case eGameState.Start:
                break;
            case eGameState.CreateProfile:
                Debug.Log("po");
                profileScreen.ShowProfile();
                break;
            case eGameState.GamePlay:
                break;
            case eGameState.Results:
                break;
        }
    }
}
