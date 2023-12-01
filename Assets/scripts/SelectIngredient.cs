using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SelectIngredient : MonoBehaviour
{
    public string ingredientName;
    public Material material;
    public List<string> ingredients; 
    
    private SpriteRenderer _spriteRenderer;
    private bool _selected;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        ingredients = GameObject.Find("SelectController").GetComponent<SelectController>().ingredients;
        
        material = new Material(_spriteRenderer.material);

        _spriteRenderer.material = material;

        ingredientName = gameObject.name;
    }

    private void OnMouseDown()
    {
        if (!_selected)
        {
            if (SelectController.SelectCounter <5)
            {
                _selected = true;
                SelectController.SelectCounter++;
                ingredients.Add(ingredientName);
                
                material.SetFloat("_OutlineOn", 1f);
                
                print(ingredientName+"selected");
            }
            
        }
        else
        {
            _selected = false;
            SelectController.SelectCounter--;
            ingredients.Remove(ingredientName);
            
            material.SetFloat("_OutlineOn", 0f);
            
            print(ingredientName+"Unselected");
        }
        
    }
    
}
