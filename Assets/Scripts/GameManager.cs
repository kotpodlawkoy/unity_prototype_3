using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string prototypeScene;
    [SerializeField] private string challengeScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown ( KeyCode.Escape ) )
        {
            SceneManager.LoadScene ( "Main Menu" );
        }
    }

    public void PrototypeButtonHandler ()
    {
        SceneManager.LoadScene ( prototypeScene );
    }

    public void ChallengeButtonHandler ()
    {
        SceneManager.LoadScene ( challengeScene );
    }
}
