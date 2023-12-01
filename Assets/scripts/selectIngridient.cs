using System.Collections.Generic;
using UnityEngine;

public class selectIngridient : MonoBehaviour
{
    public string name;
    private Material selfMaterials;
    public Material _material;
    public Material OutlineMaterial;
    private SpriteRenderer spriteRenderer;
    public List<string> ingridients; 
    
    
    private bool selekted;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ingridients = GameObject.Find("SelectControler").GetComponent<selectcontroler>().ingridients;
        
        selfMaterials = new Material(spriteRenderer.material);

        spriteRenderer.material = selfMaterials;

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

                selfMaterials = _material;
                
                print(name+"selected");
            }
            
        }
        else
        {
            selekted = false;
            selectcontroler.selectConter--;
            ingridients.Remove(name);
            
            selfMaterials = _material;
            
            print(name+"Unselected");
        }
        
    }
    
}
