using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterScriptedModel : MonoBehaviour
{
    //Штучні об'єкти рук
    private GameObject _lHand_Trigger;
    private GameObject _rHand_Trigger;
    private Animator _modelAnimator;

    public event UnityAction OnDestroying;

    private void Start()
    {
        _lHand_Trigger = transform.Find("LHand_Trigger").gameObject;
        _rHand_Trigger = transform.Find("RHand_Trigger").gameObject;
        _modelAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Задаємо координати "штучних рук"
        Transform lhand = _modelAnimator.GetBoneTransform(HumanBodyBones.LeftHand);
        _lHand_Trigger.transform.position = lhand.position;
        _lHand_Trigger.transform.rotation = lhand.rotation;
        
        Transform rhand = _modelAnimator.GetBoneTransform(HumanBodyBones.RightHand);
        _rHand_Trigger.transform.position = rhand.position;
        _rHand_Trigger.transform.rotation = rhand.rotation;
    }

    private void OnDestroy()
    {
        OnDestroying?.Invoke();
    }

    public void ApplyRig(HumanRig humanRig)
    {
        if (humanRig == null) return;
        _modelAnimator.ApplyRig(humanRig);
    }
}
