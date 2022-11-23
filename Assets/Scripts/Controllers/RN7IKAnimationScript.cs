using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RN7IKAnimationScript : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;
    private bool canInteract = false;
    private Vector3 IKposition;
    private float animWeight = 0f;
    private float animWeightDelta = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (canInteract)
        {
            if (animWeight < 1)
            {
                animWeight += animWeightDelta;
            }
        }
        else
        {
            if (animWeight > 0)
            {
                animWeight -= animWeightDelta * 1.5f;
            }
        }

        anim.SetLookAtPosition(IKposition);
        anim.SetLookAtWeight(animWeight);
        anim.SetIKPosition(AvatarIKGoal.RightHand, IKposition);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, animWeight);
    }

    public void StartIK(Vector3 pos, ItemCustomDataScript data = null)
    {
        IKposition = pos;
        canInteract = true;
    }

    public void StopIK()
    {
        canInteract = false;
    }
}
