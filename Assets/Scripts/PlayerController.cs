using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private GameObject startPrompt;
    [SerializeField] private LivesUI livesUI;
    private Rigidbody2D rb;
    private Animator animator;
    private PlayerInputActions inputActions;
    private bool isGrounded;
    private bool gameStarted = false;
    private bool invulnerable = false;
    private SpriteRenderer spriteRenderer;
    private const int maxLives = 9;
    private int lives = maxLives;
    public bool GameStarted => gameStarted;
    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameStarted = false;
        isGrounded = true;
        animator.SetBool("isRunning", false);
        animator.SetBool("isGrounded", true);
        startPrompt.SetActive(true);
        livesUI.InitializeLives(lives);
    }
    private void Update()
    {
        if (!gameStarted)
        {
            if (inputActions.Player.StartGame.triggered)
            {
                StartGame();
            }
            return;
        }

        if (inputActions.Player.Jump.triggered && isGrounded)
        {
            Jump();
        }
    }
    private void StartGame()
    {
        gameStarted = true;
        animator.SetBool("isRunning", true);
        startPrompt.SetActive(false);
    }
    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false;
        animator.SetBool("isGrounded", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            animator.SetBool("isGrounded", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") && !invulnerable)
        {
            //StartCoroutine(InvulnerabilityRoutine());
            LoseLife();
        }
        if (other.CompareTag("Collectible"))
        {
            GainLife();
            Destroy(other.gameObject);
        }
    }
    private IEnumerator InvulnerabilityRoutine()
    {
        invulnerable = true;

        float duration = 1f;
        float flickerInterval = 0.1f;
        float timer = 0f;

        while (timer < duration)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(flickerInterval);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(flickerInterval);
            timer += flickerInterval * 2;
        }

        spriteRenderer.enabled = true;
        invulnerable = false;
    }
    private void LoseLife()
    {
        lives--;

        livesUI.RemoveHeart();

        StartCoroutine(InvulnerabilityRoutine());

        if (lives <= 0)
        {
            GameOver();
        }
    }
    private void GainLife()
    {
        if (lives >= maxLives)
            return;
        lives++;
        livesUI.AddHeart();
    }
    private void GameOver()
    {
        GameManager.Instance.GameOver();
    }
}