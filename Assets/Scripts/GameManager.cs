﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int StartingLevel = 1;
    private int nextLevel;

    public enum State
    {
        StartScreen,
        RecipeScreen,
        Playing,
        WinScreen,
        Default
    }
    private State state;

    private GameObject recipePanel;
    private GameObject winPanel;
    private GameObject levelParent;
    private GameObject progressPanel;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        nextLevel = StartingLevel;
    }

    void OnLevelWasLoaded(int level)
    {
        // If it's not the start screen
        recipePanel = GameObject.FindGameObjectWithTag("RecipePanel");
        if (recipePanel != null)
        {
            winPanel = GameObject.FindGameObjectWithTag("WinPanel");
            levelParent = GameObject.FindGameObjectWithTag("LevelParent");
            progressPanel = GameObject.FindGameObjectWithTag("ProgressPanel");
            state = State.RecipeScreen;
        }
    }

    void Update()
    {
        switch(state)
        {
            case State.StartScreen:
                if (Input.GetButtonDown("Submit"))
                {
                    state = State.Default;
                    LoadNextLevel();
                }
                break;
            case State.RecipeScreen:
                if (Input.GetButtonDown("Submit"))
                {
                    state = State.Playing;
                    // Disable recipe panel and enable game
                    recipePanel.SetActive(false);
                    levelParent.SetActive(true);
                    progressPanel.SetActive(true);
                }
                break;
            case State.Playing:
                // No behaviour
                // Transition to win or lose triggered elsewhere (player?)
                break;
            case State.WinScreen:
                if (Input.GetButtonDown("Submit"))
                {
                    state = State.Default;
                    LoadNextLevel();
                }
                break;
        }
        
    }

    public void LoadNextLevel()
    {
        Application.LoadLevel(nextLevel);
        ++nextLevel;
    }
    
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ShowWinScreen()
    {
        state = State.WinScreen;
        // Disable game and show win panel
        levelParent.SetActive(false);
        progressPanel.SetActive(false);
        winPanel.SetActive(true);
    }
}
