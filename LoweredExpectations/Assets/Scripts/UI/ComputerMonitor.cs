﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// This thing is the root of the game. It's also a canvas. Since we use only UI for the game.
public class ComputerMonitor : Singleton<ComputerMonitor>
{
    [SerializeField]
    private Canvas mainCanvas;

    [SerializeField]
    private GameObject splashScreen;

    [SerializeField]
    private List<ComputerScreen> computerScreens = new List<ComputerScreen>((int)eComputerScreens.Count);

    public override void Awake()
    {
        splashScreen.SetActive(true);
        GameSystem.Instance.OnGameStateChanged += HandleOnGameStateChanged;
        base.Awake();
    }

    private void HandleOnGameStateChanged(eGameState toState)
    {
        switch (toState)
        {
            case eGameState.Start:
                Debug.Log("Start");
                
                break;
            case eGameState.CreateProfile:
                splashScreen.SetActive(false);
                computerScreens[(int)eComputerScreens.CreateProfile].ShowProfile();
                break;
            case eGameState.BrowseProfiles:
                splashScreen.SetActive(false);
                computerScreens[(int)eComputerScreens.BrowseProfiles].ShowProfile();
                break;
            case eGameState.ViewProfile:
                splashScreen.SetActive(false);
                computerScreens[(int)eComputerScreens.ViewProfile].ShowProfile();
                break;
            case eGameState.Results:
                splashScreen.SetActive(false);
                break;
        }
    }
}

public enum eComputerScreens
{
    CreateProfile,
    BrowseProfiles,
    ViewProfile,
    Chat,
    Count
}

