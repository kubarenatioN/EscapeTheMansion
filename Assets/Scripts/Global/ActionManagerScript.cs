using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionManagerScript : MonoBehaviour
{
    private GameObject actionLabel;
    private Text itemNameText;

    // Start is called before the first frame update
    void Start()
    {
        actionLabel = transform.Find("ActionPanel").gameObject;
        itemNameText = actionLabel.transform.Find("ItemName").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowActionLabel(ItemCustomDataScript itemData)
    {
        itemNameText.text = itemData.Name;
        actionLabel.SetActive(true);
    }

    public void HideActionLabel()
    {
        actionLabel.SetActive(false);
    }
}
