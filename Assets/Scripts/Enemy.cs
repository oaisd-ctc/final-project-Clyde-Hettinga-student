using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject basicPattern, standardPattern, expertPattern, drop, defeatDrop;
    [SerializeField] private float maxCooldown, cooldown, fireOffset, speed;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector3 moveDirection;
    private static float upperBound = 5.5f, lowerBound = -5.5f, rightBound = 5, leftBound = -5;

    void Awake()
    {
        switch (GameManager.GetDifficulty())
        {
            case 0:
            case 1:
                cooldown = fireOffset * 1.9f;
                break;
            case 2:
                cooldown = fireOffset * 1.35f;
                break;
            case 3:
            case 4:
            case 5:
                cooldown = fireOffset;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        if (moveDirection != null)
        {
            transform.position += moveDirection * speed * Time.deltaTime;

            if (moveDirection.x < 0) animator.SetInteger("Direction", -1);
            else animator.SetInteger("Direction", 1);
        }

        if (cooldown <= 0)
        {
            switch (GameManager.GetDifficulty())
            {
                case 0:
                    if (basicPattern) Instantiate(basicPattern, transform.position, Quaternion.identity);
                    cooldown = maxCooldown * 1.9f;
                    break;
                case 1:
                    if (standardPattern) Instantiate(standardPattern, transform.position, Quaternion.identity);
                    cooldown = maxCooldown * 1.9f;
                    break;
                case 2:
                    if (standardPattern) Instantiate(standardPattern, transform.position, Quaternion.identity);
                    cooldown = maxCooldown * 1.35f;
                    break;
                case 3:
                    if (standardPattern) Instantiate(standardPattern, transform.position, Quaternion.identity);
                    cooldown = maxCooldown;
                    break;
                case 4:
                case 5:
                    if (expertPattern) Instantiate(expertPattern, transform.position, Quaternion.identity);
                    cooldown = maxCooldown;
                    break;
                default:
                    break;
            }
        }
        else cooldown -= Time.deltaTime;

        if (transform.position.y > upperBound || transform.position.y < lowerBound || transform.position.x > rightBound || transform.position.x < leftBound)
            gameObject.SetActive(false);
    }

    public void Drop()
    {
        if (drop)
        {
            int chance = Random.Range(0, 7);
            if (chance == 6) Instantiate(drop, transform.position, Quaternion.identity);
        }
    }

    public void DefeatDrop()
    {
        if (defeatDrop) Instantiate(defeatDrop, transform.position, Quaternion.identity);

        gameObject.SetActive(false);
    }
}
