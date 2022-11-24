using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    private Text label;
    private Coroutine RunMessage;
    
    public GameObject messagePanel;

    // Start is called before the first frame update
    void Start()
    {
        label = messagePanel.GetComponentInChildren<Text>();
        WriteMessage("Test 123...");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteMessage(string message)
    {
        if (RunMessage != null)
        {
            StopCoroutine(RunMessage);
        }
        RunMessage = StartCoroutine(Message(message));
    }

    private IEnumerator Message(string text)
    {
        messagePanel.SetActive(true);
        label.text = text;
        yield return new WaitForSeconds(4f);
        messagePanel.SetActive(false);
        label.text = "";
    }
}
