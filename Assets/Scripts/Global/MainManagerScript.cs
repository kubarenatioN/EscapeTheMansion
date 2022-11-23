using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManagerScript : MonoBehaviour
{
    private static SceneManagerScript sceneManager;
    private static ActionManagerScript actionManager;

    public static SceneManagerScript SceneManager {
        get
        {
            return sceneManager;
        }
    }

    public static ActionManagerScript ActionManager
    {
        get
        {
            if (actionManager == null)
            { 
                actionManager = FindObjectOfType<ActionManagerScript>(); 
            }
            return actionManager;
        }
        private set 
        { 
            actionManager = value; 
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
        sceneManager = GetComponent<SceneManagerScript>();
    }

}
