using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private GameObject startPrompt;
    private Rigidbody2D rb;
    private Animator animator;
    private PlayerInputActions inputActions;
    private bool isGrounded;
    private bool gameStarted = false;
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
        gameStarted = false;
        isGrounded = true;
        animator.SetBool("isRunning", false);
        animator.SetBool("isGrounded", true);
        startPrompt.SetActive(true);
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
}