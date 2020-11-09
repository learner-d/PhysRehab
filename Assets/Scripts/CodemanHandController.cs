using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodemanHandController : MonoBehaviour
{
    //Штучні об'єкти рук
    GameObject LHand_Trigger;
    GameObject RHand_Trigger;
    
    Animator ModelAnimator;
    void Start()
    {
        LHand_Trigger = GameObject.Find("LHand_Trigger");
        RHand_Trigger = GameObject.Find("RHand_Trigger");
        ModelAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        //Задаємо координати "штучних рук"
        Transform lhand = ModelAnimator.GetBoneTransform(HumanBodyBones.LeftHand);
        LHand_Trigger.transform.position = lhand.position;
        LHand_Trigger.transform.rotation = lhand.rotation;
        
        Transform rhand = ModelAnimator.GetBoneTransform(HumanBodyBones.RightHand);
        RHand_Trigger.transform.position = rhand.position;
        RHand_Trigger.transform.rotation = rhand.rotation;
    }
}
