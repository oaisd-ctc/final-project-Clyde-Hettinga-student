using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float speed, stopAt;
    [SerializeField] private StageProgression progressor;

    void Awake()
    {
        progressor = FindObjectOfType<StageProgression>();
    }

    void Update()
    {
        if (transform.position.y > stopAt)
        {
            if (!progressor.DialogueCurrentlyRunning() && !progressor.FightingBoss())
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }
    }
}
