using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _isOnGround = true;
    private Rigidbody _playerRB;
    private Animator playerAnimator;

    public bool isGameOver = false;
    public float jumpForce;
    public float gravityModifier = 1;
    public ParticleSystem explosionParticle, runningParticle;

    private AudioSource playerAudioSource;
    public AudioClip jumpSound, explosionSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRB = gameObject.GetComponent < Rigidbody > ();
        Physics.gravity *= gravityModifier;

        playerAnimator = GetComponent < Animator > ();

        playerAudioSource = GetComponent < AudioSource > ();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown ( KeyCode.Space ) && _isOnGround && !isGameOver )
        {
            _playerRB.AddForce ( Vector3.up * jumpForce, ForceMode.Impulse );
            _isOnGround = false;

            playerAudioSource.PlayOneShot ( jumpSound );

            runningParticle.Stop ();
            playerAnimator.SetTrigger ( "Jump_trig" );

        }
    }

    void OnCollisionEnter ( Collision collision )
    {
        if ( collision.gameObject.CompareTag ( "Ground" ) )
        {
            _isOnGround = true;
            runningParticle.Play ();
        }
        else if ( collision.gameObject.CompareTag ( "Obstacle" ) && !isGameOver )
        {
            isGameOver = true;

            playerAnimator.SetBool ( "Death_b", true );

            explosionParticle.Play ();
            runningParticle.Stop ();

            playerAudioSource.PlayOneShot ( explosionSound );
        }
    }
}
