﻿using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EGame
{
    None, Collector, Copycat, FlappyBird
}

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

    }

    public static void LaunchGame(EGame game)
    {
        if (game == EGame.Collector)
        {
            SceneManager.LoadScene("GoodsCollectorGame");
        }
        else if(game == EGame.Copycat)
        {
            SceneManager.LoadScene("CopycatGame");
        }
        else if(game == EGame.FlappyBird)
        {

        }
    }
    public static void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}