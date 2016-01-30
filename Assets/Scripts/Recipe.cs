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
    public List<int> IngredientAmounts;

    public List<UnityEngine.UI.Text> ProgressCounters;

    public void UpdateIngredient(Ingredient id)
    {
        // TODO
    }
}
