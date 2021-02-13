using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using PhysRehab.Core;
using PhysRehab.Scenes;
using PhysRehab.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Program
{
    public static void ResolveStaticProperties<T>()
    {
        PropertyInfo[] staticProperties = typeof(T).GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        for (int i = 0; i < staticProperties.Length; i++)
        {
            if (staticProperties[i].PropertyType.IsSubclassOf(typeof(Object)))
            {
                if (staticProperties[i].GetValue(null, null) == null)
                {
                    var value = Object.FindObjectOfType(staticProperties[i].PropertyType, true);
                    staticProperties[i].SetValue(null, value);
                }
            }
        }
    }

    public static void ClearStaticProperties<T>()
    {
        PropertyInfo[] staticProperties = typeof(T).GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        for (int i = 0; i < staticProperties.Length; i++)
        {
            if (staticProperties[i].PropertyType.IsSubclassOf(typeof(Object)))
                staticProperties[i].SetValue(null, null);
        }
    }

    public static void LaunchCollectorGame()
    {
        LaunchGame(EGame.Collector);
    }

    public static void LaunchCopycatGame()
    {
        LaunchGame(EGame.Copycat);
    }

    public static void LaunchFlappyBirdGame()
    {
        LaunchGame(EGame.Bird);
    }

    public static void LaunchGame(EGame game)
    {
        //TODO: remove LoadUi
        if (game == EGame.Collector)
        {
            CollectorGameScene.Instance.EnsureLoaded();
        }
        else if(game == EGame.Copycat)
        {
            CopycatGameScene.Instance.EnsureLoaded();
        }
        else if(game == EGame.Bird)
        {
            BirdGameScene.Instance.EnsureLoaded();
        }
    }
    public static void GoToMainMenu()
    {
        UI_MAIN.Instance.HideGameUi();
        MainMenuScene.Instance.EnsureLoaded();
    }

    public static void Quit()
    {
        Application.Quit();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    public static void OnAppStartup()
    {
        
    }

    public static void LoadUi()
    {
        UI_MAIN.EnsureLoaded();
    }
}
