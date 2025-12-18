using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    public Vector3 obstacleSpawn;
    private float spawnTime = 1f;
    private PlayerController playerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating ( "SpawnObstacle", spawnTime, spawnTime );
        playerControllerScript = GameObject.Find ( "Player" ).GetComponent < PlayerController > ();
    }

    void Update ()
    {
        if ( playerControllerScript.isGameOver == true )
        {
            CancelInvoke ( "SpawnObstacle" );
        }
    }

    void SpawnObstacle ()
    {
        Instantiate ( obstacle, obstacleSpawn, obstacle.transform.rotation );
        CancelInvoke ( "SpawnObstacle" );
        spawnTime = Random.Range ( 1f, 3f );
        InvokeRepeating ( "SpawnObstacle", spawnTime, spawnTime );
    }
}
