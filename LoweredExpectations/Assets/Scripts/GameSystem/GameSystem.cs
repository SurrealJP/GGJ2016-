using UnityEngine;
using System.Collections;
using System;

public class GameSystem : Singleton<GameSystem>
{
    private eGameState currentGameState = eGameState.Start;

    public delegate void GameStateChangedEvent(eGameState toState);
    public GameStateChangedEvent OnGameStateChanged;

    public override void Awake()
    {
        currentGameState = eGameState.Start;
        base.Awake();
    }
	// Use this for initialization
	void Start () {
	}

    public void ChangeState(eGameState toState)
    {
        if(toState != currentGameState)
        {
            currentGameState = toState;
            if (OnGameStateChanged != null)
            {
                OnGameStateChanged(toState);
            }
        }
    }

    // Run Routine of our game. Let's keep this simple. 
    // The update loop will do different things based on what game state we're in. 
    // It will fire a simple event that all of our systems can listen to. 
	void Update ()
    {
        switch (currentGameState)
        {
            case eGameState.Start:
                break;
            case eGameState.CreateProfile:
                break;
            case eGameState.GamePlay:
                break;
            case eGameState.Results:
                break;
        }

	}
}

public enum eGameState
{
    Start = 0,
    CreateProfile,
    GamePlay,
    Results
}
