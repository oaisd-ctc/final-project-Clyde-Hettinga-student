using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlockable : MonoBehaviour
{
    [SerializeField] private Button /*challenges, */chainedMemories/*, extraStage*/;

    void Awake()
    {
        //For full version also put the challenge menu and extra stage in their own things

        if (GameManager.CanPlayChainedMemories()) chainedMemories.interactable = true;
    }
}
