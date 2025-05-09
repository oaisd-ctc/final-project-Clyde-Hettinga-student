using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private static int difficulty = 2;
    private static bool canRushBosses = false;

    void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }

    public static void GoToScreen(int scene)
    {
        SceneManager.LoadScene(scene);
    }


    public static void SetDifficulty(int d)
    {
        difficulty = d;
    }

    public static void UnlockChainedMemories()
    {
        canRushBosses = true;
    }

    public static int GetDifficulty()
    {
        return difficulty;
    }

    public static bool CanPlayChainedMemories()
    {
        return canRushBosses;
    }
}
