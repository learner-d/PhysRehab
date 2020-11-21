using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Gameplay Gameplay { get; private set; }
    public static UI HudController { get; private set; }
    public static LevelManager LevelManager { get; private set; }
    public static PickupObserver PickupObserver { get; private set; }
    public static PickupSpawner PickupSpawner { get; private set; }
    public static ScoreCounter ScoreCounter { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        Gameplay = FindObjectOfType<Gameplay>();
        HudController = FindObjectOfType<UI>();
        LevelManager = FindObjectOfType<LevelManager>();
        PickupObserver = FindObjectOfType<PickupObserver>();
        PickupSpawner = FindObjectOfType<PickupSpawner>();
        ScoreCounter = FindObjectOfType<ScoreCounter>();
    }
}
