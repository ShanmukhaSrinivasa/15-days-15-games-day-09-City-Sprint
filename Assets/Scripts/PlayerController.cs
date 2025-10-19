using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator playerAnimator;
    private AudioSource playerAudio;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;
    private bool isOnGround = true;
    public bool gameOver = false;

    [Header("Particle System")]
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticleFX;

    [Header("Audio Source")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;

    public static PlayerController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity = Physics.gravity.normalized * (9.81f * gravityModifier);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticleFX.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticleFX.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticleFX.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);

            GameManager.instance.GameOver();
        }
    }
}
