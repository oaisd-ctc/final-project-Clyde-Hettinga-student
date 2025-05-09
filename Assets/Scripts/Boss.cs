using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    [SerializeField] private int healthPerHeart, nextPosition, speech;
    [SerializeField] private List<GameObject> patterns = new List<GameObject>();
    [SerializeField] private List<Vector3> positions = new List<Vector3>();
    [SerializeField] private List<float> fireOffsets = new List<float>();
    [SerializeField] private Animator animator;
    [SerializeField] private float cooldown, speed = 1;
    [SerializeField] private bool moving, hasDialogue, started;
    [SerializeField] private GameObject drop, clearScreen;
    [SerializeField] private StageProgression progressor;
    [SerializeField] private Dialogue box;
    [SerializeField] private UnityEvent OnAwake, OnBeginFight, OnDefeat;

    void Awake()
    {
        progressor = FindObjectOfType<StageProgression>();
        box = FindObjectOfType<Dialogue>();

        progressor.SetBossActive();

        transform.position = positions[0];

        if (hasDialogue)
        {
            box.RunDialogue(speech, 1);
            OnAwake.Invoke();
        }

        cooldown = fireOffsets[0] * 2;
    }

    void Update()
    {
        if (!progressor.DialogueCurrentlyRunning())
        {
            if (!started)
            {
                OnBeginFight.Invoke();
                started = true;
            }

            if (patterns.Count > 0)
            {
                if (!moving)
                {
                    if (cooldown <= 0)
                    {
                        if (patterns[0])
                        {
                            Instantiate(patterns[0], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                            animator.SetBool("Firing", true);
                        }
                        cooldown = fireOffsets[0];

                        if (positions.Count > 1)
                        {
                            moving = true;
                            do
                            {
                                nextPosition = Random.Range(0, positions.Count);
                            } while (transform.position == positions[nextPosition]);
                        }
                        else moving = true;
                    }
                    else cooldown -= Time.deltaTime;
                }
                else
                {
                    if (cooldown <= 0)
                    {
                        if (Vector3.Distance(transform.position, positions[nextPosition]) > 0f)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, positions[nextPosition], speed * Time.deltaTime);
                            animator.SetBool("Firing", false);
                            animator.SetBool("Moving", true);
                        }
                        else
                        {
                            moving = false;
                            animator.SetBool("Moving", false);
                            cooldown = 1.75f;
                        }
                    }
                    else cooldown -= Time.deltaTime;
                }
            }
            else
            {
                progressor.KickBoss();
                gameObject.SetActive(false);
            }
        }
    }

    public void NextPattern()
    {
        cooldown = 2.5f;

        if (patterns.Count > 0)
        {
            patterns.RemoveAt(0);
            fireOffsets.RemoveAt(0);

            Health health = GetComponent<Health>();

            health.SetHealth(healthPerHeart);
        }

        if (patterns.Count == 1 && hasDialogue) FinalPattern();

        if (patterns.Count == 0 && hasDialogue)
        {
            box.RunDialogue(speech, 2);
            OnDefeat.Invoke();
        }
    }

    public void FinalPattern()
    {
        while (positions.Count > 1)
        {
            positions.RemoveAt(1);
        }

        nextPosition = 0;
        moving = true;
    }

    public void Drop()
    {
        if (drop) Instantiate(drop, transform.position, Quaternion.identity);
        if (clearScreen) Instantiate(clearScreen);
    }
}
