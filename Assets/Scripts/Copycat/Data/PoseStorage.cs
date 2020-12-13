using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PoseStorage
{
    private static List<PosesPack> _posesPacks = new List<PosesPack>();
    public static IReadOnlyList<PosesPack> PosesPacks => _posesPacks;
    public static string SavingRootDirectory { get; private set; }
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    public static void Initialize()
    {
        CreateDirs();
        LoadAllPosesPacks();

        if (GetPosesPack("Default") == null)
        {
            CreatePosesPack("Default");
        }
    }
    private static void CreateDirs()
    {
        SavingRootDirectory = Path.GetDirectoryName(Application.dataPath) + "\\Data";
        Directory.CreateDirectory(SavingRootDirectory);
        SavingRootDirectory += "\\Copycat";
        Directory.CreateDirectory(SavingRootDirectory);
        SavingRootDirectory += "\\Poses";
        Directory.CreateDirectory(SavingRootDirectory);
        Debug.Log($"{nameof(SavingRootDirectory)}: {SavingRootDirectory}");
    }
    public static List<string> GetPosesPacksNames()
    {
        List<string> names = new List<string>(_posesPacks.Count);
        for (int i = 0; i < _posesPacks.Count; i++)
        {
            names.Add(_posesPacks[i].Name);
        }
        return names;
    }
    public static PosesPack CreatePosesPack(string name)
    {
        PosesPack pack = new PosesPack(name);
        _posesPacks.Add(pack);
        return pack;
    }
    public static PosesPack GetPosesPack(string name)
    {
        for (int i = 0; i < _posesPacks.Count; i++)
        {
            if (_posesPacks[i].Name.Equals(name, System.StringComparison.OrdinalIgnoreCase))
            {
                return _posesPacks[i];
            }
        }
        return null;
    }

    private static void LoadAllPosesPacks()
    {
        foreach(string path in Directory.EnumerateFiles(SavingRootDirectory, "*.json"))
        {
            string jsonContents = File.ReadAllText(path);
            if (!string.IsNullOrEmpty(jsonContents))
            {
                PosesPack posesPack = JsonUtility.FromJson<PosesPack>(jsonContents);
                if (posesPack != null)
                {
                    _posesPacks.Add(posesPack);
                }
            }
        }
    }

    public static void SavePosesPack(string name)
    {
        PosesPack posesPack = GetPosesPack(name);
        SavePosesPackInternal(posesPack);
    }

    public static void SavePosesPack(PosesPack posesPack)
    {
        if (!_posesPacks.Contains(posesPack))
            throw new System.ArgumentException($"Given {nameof(posesPack)} is not present in poses packs database.");

        SavePosesPackInternal(posesPack);
    }

    private static void SavePosesPackInternal(PosesPack posesPack)
    {
        string path = Path.Combine(SavingRootDirectory, posesPack.Name + ".json");
        File.WriteAllText(path, JsonUtility.ToJson(posesPack, true));
    }

    public static void SaveAllPosesPacks()
    {
        for (int i = 0; i < _posesPacks.Count; i++)
            SavePosesPackInternal(_posesPacks[i]);
    }
}
