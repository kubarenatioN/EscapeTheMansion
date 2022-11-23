using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCanvasScript : MonoBehaviour
{
    private Button resumeButton;
    private Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        resumeButton = gameObject.transform.GetChild(0).GetComponent<Button>();
        exitButton = gameObject.transform.GetChild(1).GetComponent<Button>();
        exitButton.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        MainManagerScript.SceneManager.OpenScene(0);
    }
}
