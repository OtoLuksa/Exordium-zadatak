using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GUIManager : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            ToggleVisibility("InventoryGUIElement");
        }
        if (Input.GetKeyDown("e"))
        {
            ToggleVisibility("EquipmentGUIElement");
        }
        if (Input.GetKeyDown("c"))
        {
            ToggleVisibility("CharacterGUIElement");
        }
    }

    public void ToggleVisibility(string tag)
    {
        GameObject[] interfaceElements = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject interfaceElement in interfaceElements)
        {
            CanvasGroup group = interfaceElement.GetComponentInChildren<CanvasGroup>();
            if (group.alpha == 0)
            {
                group.alpha = 1;
            }
            else if (group.alpha == 1)
            {
                group.alpha = 0;
            }
        }
    }
}
