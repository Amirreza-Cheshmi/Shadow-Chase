using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    public Transform playerTransform;
    public Animator playerAnimator;
    public List<Movement_Enemy> enemyScripts;
    public List<Animator> enemyAnimators;

    public float catchDistance = 1f;

    public TextMeshProUGUI scoreText;

    private int score = 0;
    private Dictionary<Movement_Enemy, bool> playerWasInRange = new Dictionary<Movement_Enemy, bool>();
    private bool playerCaught = false;

    private void Start()
    {
        foreach (var enemy in enemyScripts)
        {
            playerWasInRange[enemy] = false;
        }
        UpdateScoreUI();
    }

    private void Update()
    {
        if (playerTransform == null || enemyScripts.Count == 0)
            return;

        for (int i = 0; i < enemyScripts.Count; i++)
        {
            Movement_Enemy enemy = enemyScripts[i];
            Animator enemyAnim = (i < enemyAnimators.Count) ? enemyAnimators[i] : null;

            if (enemy == null) continue;

            float distance = Vector2.Distance(playerTransform.position, enemy.detectionPoint.position);

            if (distance <= catchDistance)
            {
                if (!playerCaught)
                {
                    HandlePlayerCaught(enemy, enemyAnim);
                    playerCaught = true;
                }
                continue;
            }

            bool isPlayerInRange = distance <= enemy.detectionRange;

            if (isPlayerInRange)
            {
                playerWasInRange[enemy] = true;
            }
            else
            {
                if (playerWasInRange[enemy])
                {
                    score++;
                    UpdateScoreUI();
                    playerWasInRange[enemy] = false;
                }
            }
        }
    }

    private void HandlePlayerCaught(Movement_Enemy enemy, Animator enemyAnim)
    {
        enemy.enabled = false;

        if (enemyAnim != null)
            enemyAnim.SetBool("IsMoving", false);

        
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("GameOver");
            FindObjectOfType<GameOverUI>().ShowGameOver();
        }

        if (playerTransform != null)
        {
            Movement playerMovement = playerTransform.GetComponent<Movement>();
            if (playerMovement != null)
                playerMovement.enabled = false;
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score : " + score;
    }
}
