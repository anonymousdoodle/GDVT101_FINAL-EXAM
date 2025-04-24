using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseTrigger : MonoBehaviour
{
    public GameObject winPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached the house!");
            winPanel.SetActive(true);
            Time.timeScale = 0f; // freeze game
        }
    }
}
