using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCustomDataScript : MonoBehaviour
{
    public string Name;
    public ObjectType Type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleActionLabel(bool isActive)
    {
        if (isActive)
        {
            MainManagerScript.ActionManager.ShowActionLabel(this);
        }
        else
        {
            MainManagerScript.ActionManager.HideActionLabel();
        }
    }
}
