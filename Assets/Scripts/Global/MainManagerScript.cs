using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManagerScript : MonoBehaviour
{
    private static SceneManagerScript sceneManager;
    private static ActionManagerScript actionManager;
    private static MessageManager messageManager;

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

    public static MessageManager MessageManager
    {
        get
        {
            if (messageManager == null)
            {
                messageManager = FindObjectOfType<MessageManager>();
            }
            return messageManager;
        }
        private set 
        {
            messageManager = value;
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
