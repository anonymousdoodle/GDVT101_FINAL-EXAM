using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 7f;
    public float sideSpeed = 5f;
    public float jumpForce = 17f;
    public float fallMultiplier = 2.5f;

    private Rigidbody rb;
    private Animator animator;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool canMove = true;

    
    public Image[] hearts;
    private int currentHealth;

    
    public AudioSource jumpSFX;

    
    public GameObject loseCanvas; 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        if (animator != null)
        {
            animator.SetBool("isRunning", true);
        }

        currentHealth = hearts.Length;

        if (loseCanvas != null)
            loseCanvas.SetActive(false); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (!canMove) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(-forwardSpeed, rb.velocity.y, horizontalInput * sideSpeed);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            if (jumpSFX != null) jumpSFX.Play();
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (animator != null)
        {
            bool isMoving = rb.velocity.magnitude > 0.1f;
            animator.SetBool("isRunning", isMoving);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyTrigger"))
        {
            if (currentHealth > 0)
            {
                currentHealth--;
                hearts[currentHealth].enabled = false;
                Debug.Log("Player hit! Hearts left: " + currentHealth);

                if (currentHealth <= 0)
                {
                    TriggerLose();
                }
            }
        }
    }

    void TriggerLose()
    {
        canMove = false;
        rb.velocity = Vector3.zero;

        if (animator != null)
        {
            animator.SetBool("isRunning", false);
        }

        if (loseCanvas != null)
        {
            loseCanvas.SetActive(true);
        }

        Debug.Log("Game Over! Player lost.");
    
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
    }
}
