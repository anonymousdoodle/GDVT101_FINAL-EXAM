using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public PlayerMovement playerScript; 
    private bool gamePaused = true;

    void Start()
    {
        playerScript.canMove = false; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Restart();
        }
    }

    void Restart()
    {
        playerScript.canMove = false; 
    }

    void Update()
    {
        if (gamePaused && Input.GetKeyDown(KeyCode.Space))
        {
            playerScript.canMove = true;
            gamePaused = false;
        }
    }
}
