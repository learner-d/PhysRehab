using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TransformData
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 localPosition;
    public Quaternion localRotation;
    public TransformData(Transform transform)
    {
        position = transform.position;
        rotation = transform.rotation;
        localPosition = transform.localPosition;
        localRotation = transform.localRotation;
    }
}

[Serializable]
public class HumanRig
{
    public static readonly HumanBodyBones[] BodyBoneTypes = Enum.GetValues(typeof(HumanBodyBones)) as HumanBodyBones[];
    [SerializeField]
    private List<TransformData> _bodyBoneTransforms = new List<TransformData>(BodyBoneTypes.Length - 1);

    public IReadOnlyList<TransformData> BodyBoneTransforms => _bodyBoneTransforms;
    
    public HumanRig(GameObject gameObject) : this(gameObject.GetComponent<Animator>())
    {}
    public HumanRig(Animator animator)
    {
        for (int i = 0; i < BodyBoneTypes.Length - 1; i++)
        {
            Transform transform = animator.GetBoneTransform(BodyBoneTypes[i]);
            TransformData transformData = transform? new TransformData(transform) : null;
            _bodyBoneTransforms.Add(transformData);
        }
    }
}

public static class AnimatorExt
{
    public static void ApplyRig(this Animator animator, HumanRig rig)
    {
        for (int i = 0; i < HumanRig.BodyBoneTypes.Length - 1; i++)
        {
            Transform origBoneTransform = animator.GetBoneTransform(HumanRig.BodyBoneTypes[i]);
            TransformData newBoneTransform = rig.BodyBoneTransforms[i];
            if (origBoneTransform != null && newBoneTransform != null)
            {
                origBoneTransform.SetLocalTransform(newBoneTransform);
            }
        }
    }

    public static HumanRig CaptureRig(this Animator animator)
    {
        HumanRig rig = new HumanRig(animator);
        return rig;
    }
}

public static class GameObjectExt
{
    public static void ApplyRig(this GameObject gameObject, HumanRig rig)
    {
        gameObject.GetComponent<Animator>()?.ApplyRig(rig);
    }
    public static HumanRig CaptureRig(this GameObject gameObject)
    {
        return gameObject.GetComponent<Animator>()?.CaptureRig();
    }
}

public static class TransformExt
{
    public static void SetLocalTransform(this Transform transform, TransformData transformData)
    {
        transform.localPosition = transformData.localPosition;
        transform.localRotation = transformData.localRotation;
    }
    public static void SetGlobalTransform(this Transform transform, TransformData transformData)
    {
        transform.position = transformData.position;
        transform.rotation = transformData.rotation;
    }
}