using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

using PhysRehab;

public class GoodsCollectorScene
{
    public static Gameplay Gameplay { get; private set; }
    public static UI HudController { get; private set; }
    public static LevelManager LevelManager { get; private set; }
    public static PickupObserver PickupObserver { get; private set; }
    public static PickupSpawner PickupSpawner { get; private set; }
    public static ScoreCounter ScoreCounter { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    public static void Initialize()
    {
        SceneManager.sceneLoaded += (scene, loadMode) =>
        {
            if (scene.name == "GoodsCollectorGame")
            {
                Program.ResolveStaticProperties<GoodsCollectorScene>();
            }
        };
        SceneManager.sceneUnloaded += scene =>
        {
            if (scene.name == "GoodsCollectorGame")
            {
                Program.ClearStaticProperties<GoodsCollectorScene>();
            }
        };
    }
}
