using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int character;
    private static int hits;

    [SerializeField] private GameObject grazeBox, parryRange;
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject bulletPrefab, abilityObject;
    [SerializeField] private Animator animator;

    private float attackTimer = 0, parryActiveFor = 0, skillCooldown = 0;
    [SerializeField] private int power = 0, skill = 0, currentCharge = 0, maxCharge, lvOne, lvTwo, lvThree, lvFour;
    [SerializeField] private float invulnerable;
    [SerializeField] private bool canParry;
    [SerializeField] private StageProgression progressor;

    void Awake()
    {
        progressor = FindObjectOfType<StageProgression>();

        hits = 0;
        invulnerable = 3;
        lvOne = 10;

        switch (character)
        {
            case 0:
                speed = 3.5f;
                maxCharge = 5;
                lvTwo = 40;
                lvThree = 100;
                lvFour = 200;
                break;
            case 1:
                speed = 2.875f;
                maxCharge = 25;
                lvTwo = 35;
                lvThree = 85;
                lvFour = 145;
                break;
            case 2:
                speed = 2.25f;
                maxCharge = 10;
                lvTwo = 25;
                lvThree = 50;
                lvFour = 90;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        if (!progressor.DialogueCurrentlyRunning())
        {
            // Movement. You also can't move if you're parrying.
            if (parryActiveFor <= 0)
            {
                if (Input.GetKey(KeyCode.LeftShift)) // Focused/slow movement
                {
                    // Vertical
                    if (Input.GetKey(KeyCode.UpArrow)) transform.position += Vector3.up * (speed / 2.25f) * Time.deltaTime;
                    else if (Input.GetKey(KeyCode.DownArrow)) transform.position += Vector3.down * (speed / 2.25f) * Time.deltaTime;

                    // Horizontal
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        animator.SetInteger("LeftRight", -1);
                        transform.position += Vector3.left * (speed / 2.25f) * Time.deltaTime;
                    }
                    else if (Input.GetKey(KeyCode.RightArrow))
                    {
                        animator.SetInteger("LeftRight", 1);
                        transform.position += Vector3.right * (speed / 2.25f) * Time.deltaTime;
                    }
                    else
                    {
                        animator.SetInteger("LeftRight", 0);
                    }
                }
                else // Regular movement
                {
                    // Vertical
                    if (Input.GetKey(KeyCode.UpArrow)) transform.position += Vector3.up * speed * Time.deltaTime;
                    else if (Input.GetKey(KeyCode.DownArrow)) transform.position += Vector3.down * speed * Time.deltaTime;
                    else transform.position += Vector3.zero;

                    // Horizontal
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        animator.SetInteger("LeftRight", -1);
                        transform.position += Vector3.left * speed * Time.deltaTime;
                    }
                    else if (Input.GetKey(KeyCode.RightArrow))
                    {
                        animator.SetInteger("LeftRight", 1);
                        transform.position += Vector3.right * speed * Time.deltaTime;
                    }
                    else
                    {
                        animator.SetInteger("LeftRight", 0);
                        transform.position += Vector3.zero;
                    }
                }
            }

            // Fire bullets
            if (Input.GetKey(KeyCode.Z))
            {
                if (attackTimer <= 0)
                {
                    if (Input.GetKey(KeyCode.LeftShift)) // Focused shots (less range while slowed)
                    {
                        if (power < lvOne)
                            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z), Quaternion.identity);
                        else if (power < lvTwo)
                        {
                            Instantiate(bulletPrefab, new Vector3(transform.position.x + .025f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, -1.25f));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x - .025f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, 1.25f));
                        }
                        else if (power < lvThree)
                        {
                            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z), Quaternion.identity);
                            Instantiate(bulletPrefab, new Vector3(transform.position.x + .05f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, -2.5f));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x - .05f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, 2.5f));
                        }
                        else if (power < lvFour)
                        {
                            Instantiate(bulletPrefab, new Vector3(transform.position.x + .025f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, -1.25f));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x - .025f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, 1.25f));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x + .075f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, -3.75f));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x - .075f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, 3.75f));
                        }
                        else
                        {
                            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z), Quaternion.identity);
                            Instantiate(bulletPrefab, new Vector3(transform.position.x + .05f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, -2.5f));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x - .05f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, 2.5f));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x + .1f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, -5));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x - .1f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, 5));
                        }
                    }
                    else // Regular shots (more range while normal speed)
                    {
                        if (power < lvOne)
                            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z), Quaternion.identity);
                        else if (power < lvTwo)
                        {
                            Instantiate(bulletPrefab, new Vector3(transform.position.x + .025f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, -2.5f));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x - .025f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, 2.5f));
                        }
                        else if (power < lvThree)
                        {
                            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z), Quaternion.identity);
                            Instantiate(bulletPrefab, new Vector3(transform.position.x + .05f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, -5));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x - .05f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, 5));
                        }
                        else if (power < lvFour)
                        {
                            Instantiate(bulletPrefab, new Vector3(transform.position.x + .025f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, -2.5f));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x - .025f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, 2.5f));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x + .075f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, -7.5f));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x - .075f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, 7.5f));
                        }
                        else
                        {
                            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z), Quaternion.identity);
                            Instantiate(bulletPrefab, new Vector3(transform.position.x + .05f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, -5));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x - .05f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, 5));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x + .1f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, -10));
                            Instantiate(bulletPrefab, new Vector3(transform.position.x - .1f, transform.position.y + .5f, transform.position.z), Quaternion.Euler(0, 0, 10));
                        }
                    }

                    attackTimer = 1;
                }
                else attackTimer -= 10 * Time.deltaTime;
            }
            else attackTimer = 0;

            // Parrying
            if (canParry)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    parryRange.SetActive(true);
                    parryActiveFor = 1;
                }
                else
                {
                    if (parryActiveFor > 0) parryActiveFor -= 8 * Time.deltaTime;
                    else parryRange.SetActive(false);
                }
            }
            else parryRange.SetActive(false);

            if (Input.GetKeyUp(KeyCode.X))
            {
                if (skill > 0)
                {
                    if (skillCooldown <= 0)
                    {
                        switch (character)
                        {
                            case 0:
                                animator.SetBool("Invulnerable", true);
                                invulnerable = 3;

                                skillCooldown = .2f;
                                speed = 12;
                                break;
                            case 1:
                                Instantiate(abilityObject, new Vector3(transform.position.x + .75f, transform.position.y + .5f, transform.position.z), Quaternion.identity);
                                Instantiate(abilityObject, new Vector3(transform.position.x - .75f, transform.position.y + .5f, transform.position.z), Quaternion.identity);
                                
                                animator.SetBool("Invulnerable", true);
                                invulnerable = 4;

                                skillCooldown = 3.5f;
                                break;
                            case 2:
                                Instantiate(abilityObject, transform.position, Quaternion.identity);
                                skillCooldown = 1;
                                break;
                            default:
                                break;
                        }

                        skill--;
                    }
                }
            }
        }

        if (invulnerable > 0) invulnerable -= Time.deltaTime;
        else animator.SetBool("Invulnerable", false);

        if (skillCooldown > 0) skillCooldown -= Time.deltaTime;
        else
        {
            if (character == 0 && speed > 5)
            {
                speed = 3.5f;
                Instantiate(abilityObject, transform.position, Quaternion.identity);
                skillCooldown = 1;
            }
        }
    }

    public void IncreasePower()
    {
        power++;
    }

    public void DownALevel()
    {
        hits++;

        if (power >= lvFour) power = lvThree;
        else if (power >= lvThree) power = lvTwo;
        else if (power >= lvTwo) power = lvOne;
        else if (power >= lvOne) power = 0;
    }

    public void IncreaseCharge()
    {
        currentCharge++;

        if (currentCharge == maxCharge)
        {
            skill++;
            currentCharge = 0;
        }
    }

    public void SetInvulnerable()
    {
        animator.SetBool("Invulnerable", true);
        invulnerable = 3;
    }

    public bool IsInvulnerable()
    {
        return invulnerable > 0;
    }


    public int Ability()
    {
        return skill;
    }

    public int GetCharge()
    {
        return currentCharge;
    }

    public int GetTotal()
    {
        return maxCharge;
    }

    public int GetPower()
    {
        return power;
    }

    public int GetMaxPower()
    {
        return lvFour;
    }


    public int PlayingAs()
    {
        return character;
    }

    public static int GetHits()
    {
        return hits;
    }
}
