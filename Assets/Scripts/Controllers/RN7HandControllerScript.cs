using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RN7HandControllerScript : MonoBehaviour
{
    private Transform objToInteract;
    private ItemCustomDataScript objCustomData;

    [SerializeField]
    private RN7IKAnimationScript playerIK;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("item"))
        {
            objToInteract = other.transform;
            objCustomData = other.gameObject.GetComponent<ItemCustomDataScript>();
            playerIK.StartIK(objToInteract.position, objCustomData);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerIK.StopIK();
        objCustomData.ToggleActionLabel(false);
        objToInteract = null;
        objCustomData = null;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (objToInteract != null && objCustomData != null)
    //    {
    //        objCustomData.ToggleActionLabel(true);
    //    }
    //}

    private void OnCollisionStay(Collision collision)
    {
        if (objToInteract != null && objCustomData != null)
        {
            objCustomData.ToggleActionLabel(true);

            if (Input.GetKey(KeyCode.E))
            {
                TakeItem(objToInteract.gameObject);
                playerIK.StopIK();
                MainManagerScript.MessageManager.WriteMessage("?? ????????? " + objCustomData.Name);
                Dispose();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (objToInteract != null && objCustomData != null)
        {
            objCustomData.ToggleActionLabel(false);
        }
    }

    private void TakeItem(GameObject item)
    {
        item.SetActive(false);
    }

    private void Dispose()
    {
        objCustomData.ToggleActionLabel(false);
        objToInteract = null;
        objCustomData = null;
    }
}
