using UnityEngine;
using UnityEngine.Events;

public class StageChange : MonoBehaviour
{
    [SerializeField] private int stage, playerHealth;
    [SerializeField] private string title, location;
    [SerializeField] private FlavorText flavorText;
    [SerializeField] private Health player;
    [SerializeField] private UnityEvent OnAwake;

    void Awake()
    {
        flavorText.ChallengeNextStage(stage, title, location);
        player.SetHealth(playerHealth);
        OnAwake.Invoke();
    }
}