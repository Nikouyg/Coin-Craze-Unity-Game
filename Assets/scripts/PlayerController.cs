using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    private Rigidbody playerRb;
    private CapsuleCollider playerCollider;
    private Animator playerAnim;
    private AudioSource playerAudio;

    public float jumpForce = 10f;
    public float gravityModifier = 1f;
    public bool isOnGround = true;
    private bool isCrouching = false;

    [Header("Game")]
    public bool gameOver = false;
    public GameManager2 gameManager;

    [Header("Effects & Sounds")]
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip coinSound;
    public AudioClip powerupSound;
    public bool hasPowerup;

    [Header("Projectile")]
    public GameObject projectilePrefab;
    public float throwForce = 500f;

    [Header("UI")]
    public TextMeshProUGUI gameOverText;
    public CoinManager cm;

    [Header("Power-Up")]
    public bool hasShield = false; // true if player picked up a power-up

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
        gameManager = GameObject.Find("GameManager2").GetComponent<GameManager2>();

        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameOver) return;

        HandleJump();
        HandleCrouch();
        HandleProjectile();
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isCrouching)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1f);
        }
    }

    private void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.M) && isOnGround)
            StartCrouch();
        if (Input.GetKeyUp(KeyCode.M))
            StopCrouch();
    }

    private void StartCrouch()
    {
        isCrouching = true;
        playerAnim.SetBool("isCrouching", true);
        playerCollider.height = 1f;
        playerCollider.center = new Vector3(0, 0.5f, 0);
    }

    private void StopCrouch()
    {
        isCrouching = false;
        playerAnim.SetBool("isCrouching", false);
        playerCollider.height = 2f;
        playerCollider.center = new Vector3(0, 1f, 0);
    }

    private void HandleProjectile()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject proj = Instantiate(projectilePrefab, transform.position + transform.forward + Vector3.up * 1f, Quaternion.identity);
            Rigidbody projRb = proj.GetComponent<Rigidbody>();
            projRb.AddForce(transform.forward * throwForce);
            Destroy(proj, 3f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            if (hasShield)
            {
                // Use shield to prevent death
                hasShield = false;
                Debug.Log("Shield absorbed the hit!");
                playerAudio.PlayOneShot(powerupSound, 1f);
            }
            else
            {
                // Game Over
                gameOver = true;
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                explosionParticle.Play();
                dirtParticle.Stop();
                playerAudio.PlayOneShot(crashSound, 1f);

                // Optional physical fall
                playerRb.constraints = RigidbodyConstraints.None;

                if (gameOverText != null)
                    gameOverText.gameObject.SetActive(true);

                if (gameManager != null)
                    gameManager.GameOver();

                Debug.Log("💀 Game Over! Player died.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);

            if (cm != null)
                cm.coinCount++;

            if (coinSound != null)
                playerAudio.PlayOneShot(coinSound, 1f);
        }
        else if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);

            // Grant shield/power-up
            hasShield = true;
            playerAudio.PlayOneShot(powerupSound, 1f);
            Debug.Log("Power-up collected! Shield active.");
        }
    }

}


