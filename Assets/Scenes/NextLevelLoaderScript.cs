using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelLoaderScript : MonoBehaviour
{
    private bool isLocked = false;
    private LevelCheckerScript levelChecker;

    // Start is called before the first frame update
    void Start()
    {
        levelChecker = GetComponent<LevelCheckerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.N) && levelChecker.CanEnterNextLevel() && !isLocked)
        {
            isLocked = true;
            MainManagerScript.SceneManager.LoadNextLevel();
        }
    }
}
