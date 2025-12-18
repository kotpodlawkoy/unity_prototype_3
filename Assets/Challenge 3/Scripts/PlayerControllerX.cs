using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    private bool bounceDown = false;
    public float bounceImpulse;
    private Vector3 startScale;

    public float bounceSpeed;
    public float floatForce;
    public float upperBorder, lowerBorder;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    public ParticleSystem explosionParticle;

    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent < Rigidbody > ();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        startScale = transform.localScale;
    }

    void Update ()
    {
        if ( transform.position.y > upperBorder )
        {
            transform.position = new Vector3 ( transform.position.x,
                                               upperBorder,
                                               transform.position.z );
        }
        if ( transform.localScale.y > 0.7f * startScale.y && bounceDown )
        {
            transform.localScale = new Vector3 ( transform.localScale.x,
                                                 transform.localScale.y - bounceSpeed * Time.deltaTime,
                                                 transform.localScale.z );
        }
        else if ( bounceDown )
        {
            bounceDown = false;
        }
        Debug.Log ( bounceDown );
        if ( transform.localScale.y < 1f * startScale.y && !bounceDown )
        {
            transform.localScale = new Vector3 ( transform.localScale.x,
                                                 transform.localScale.y + bounceSpeed * Time.deltaTime,
                                                 transform.localScale.z );
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && transform.position.y < upperBorder - 1 )
        {
            playerRb.AddForce( Vector3.up * floatForce );
        }
        if ( transform.position.y < lowerBorder && !gameOver )
        {
            playerRb.AddForce ( Vector3.up * bounceImpulse, ForceMode.Impulse );
            bounceDown = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
