using UnityEngine;
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

    private GameObject recipeImage;
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
        recipeImage = GameObject.FindGameObjectWithTag("RecipeImage");
        if (recipeImage != null)
        {
            winPanel = GameObject.FindGameObjectWithTag("WinPanel");
            levelParent = GameObject.FindGameObjectWithTag("LevelParent");
            progressPanel = GameObject.FindGameObjectWithTag("ProgressPanel");
            // Disable everything except the recipe panel
            winPanel.SetActive(false);
            levelParent.SetActive(false);
            progressPanel.SetActive(false);

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
                    recipeImage.SetActive(false);
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
        if(nextLevel >= Application.levelCount)
        {
            // If we have finished the last level, load the start screen and self destroy
            Application.LoadLevel(0);
            Destroy(gameObject);            
        }
        else
        {
            // Otherwise, load the next level and increment
            Application.LoadLevel(nextLevel);
            ++nextLevel;
        }        
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
