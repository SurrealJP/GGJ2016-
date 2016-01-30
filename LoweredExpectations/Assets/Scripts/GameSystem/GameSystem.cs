#define DEBUG_GAMESYSTEM

using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class GameSystem : Singleton<GameSystem>
{
    private eGameState currentGameState = eGameState.None;

    public delegate void GameStateChangedEvent(eGameState toState);
    public GameStateChangedEvent OnGameStateChanged;

    public override void Awake()
    {
        PrintSystemLog("System Awake");
        OnGameStateChanged += HandleOnGameStateChanged;
        //ChangeState(eGameState.Start);
        base.Awake();
    }
	// Use this for initialization
	private void Start ()
    {
        PrintSystemLog("System Start");
    }

    public void ChangeState(eGameState toState)
    {
        if(toState != currentGameState)
        {
            currentGameState = toState;
            PrintSystemLog("Game State Changed, New State: " + toState); 
            if (OnGameStateChanged != null)
            {
                OnGameStateChanged(toState);
            }
        }
    }

    // Run Routine of our game. Let's keep this simple. 
    // The update loop will do different things based on what game state we're in. 
    // It will fire a simple event that all of our systems can listen to. 
	private void Update ()
    {
        switch (currentGameState)
        {
            case eGameState.Start:
                // Splash Screen, shows the name of the game and how to play
                // Continuing transfers you to the next scene 
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    ChangeState(eGameState.CreateProfile);
                }
                break;
            case eGameState.CreateProfile:
                break;
            case eGameState.GamePlay:
                break;
            case eGameState.Results:
                break;
        }
	}

    private void HandleOnGameStateChanged(eGameState toState)
    {
        PrintSystemLog("Handling Game State Change to: " + toState);
        switch (currentGameState)
        {
            case eGameState.Start:
                SceneManager.LoadScene("StartScene");
                break;
            case eGameState.CreateProfile:
                SceneManager.LoadScene("MainScene");
                break;
            case eGameState.GamePlay:
                if(SceneManager.GetActiveScene().name != "MainScene")
                {
                    SceneManager.LoadScene("MainScene");
                }
                break;
            case eGameState.Results:
                SceneManager.LoadScene("ResultScene");
                break;
        }
    }

    private void OnDestroy()
    {
        OnGameStateChanged -= HandleOnGameStateChanged;
    }

    #region diagnostics
    // prints a formatted log
    public void PrintSystemLog(string systemLog)
    {
        Debug.LogFormat(String.Format(" <color=red><b>SYSTEM LOG</b>:</color> <i><color=black>{0}</color></i>", systemLog));
    }
    #endregion
}

public enum eGameState
{
    None = 0,
    Start,
    CreateProfile,
    GamePlay,
    Results
}