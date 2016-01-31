using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Recipe : MonoBehaviour
{
    public enum Ingredient
    {
        Yearbook,
        Dildo,
        Garlic,
        Underpants,
        Tampon,
        Pizza
    }

    public List<Ingredient> Ingredients;
    public List<int> NeededAmounts;
    public List<int> CollectedAmounts;

    public List<UnityEngine.UI.Text> ProgressCounters;

    private GameManager gm;

    public void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        for (int i = 0; i < Ingredients.Count; ++i)
        {

            ProgressCounters[i].text = CollectedAmounts[i] + " / " + NeededAmounts[i];
        }

    }

    public void UpdateIngredient(Ingredient id)
    {
        // Find index
        int index = Ingredients.IndexOf(id);
        // If the ingredient is part of the recipe
        if(index != -1)
        {
            // Increment
            ++CollectedAmounts[index];
            // Update UI progress
            ProgressCounters[index].text = CollectedAmounts[index] + " / " + NeededAmounts[index];
            // Check victory conditions
            if(HasWon())
            {
                gm.ShowWinScreen();
            }
        }
    }

    private bool HasWon()
    {
        for(int i = 0; i < CollectedAmounts.Count; ++i)
        {
            if(CollectedAmounts[i] < NeededAmounts[i])
            {
                return false;
            }
        }
        return true;
    }
}
