using System.Collections.Generic;
using UnityEngine;

public class selectIngridient : MonoBehaviour
{
    public string name;
    public Material _material;
    private SpriteRenderer spriteRenderer;
    public List<string> ingridients; 
    
    
    private bool selekted;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ingridients = GameObject.Find("SelectControler").GetComponent<selectcontroler>().ingridients;
        
        _material = new Material(spriteRenderer.material);

        spriteRenderer.material = _material;

        name = gameObject.name;
    }

    private void OnMouseDown()
    {
        if (!selekted)
        {
            if (selectcontroler.selectConter <5)
            {
                selekted = true;
                selectcontroler.selectConter++;
                ingridients.Add(name);
                
                _material.SetFloat("_OutlineOn", 1f);
                
                print(name+"selected");
            }
            
        }
        else
        {
            selekted = false;
            selectcontroler.selectConter--;
            ingridients.Remove(name);
            
            _material.SetFloat("_OutlineOn", 0f);
            
            print(name+"Unselected");
        }
        
    }
    
}
