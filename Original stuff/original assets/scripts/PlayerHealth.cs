using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image[] hearts; 
    private int currentHealth;

    void Start()
    {
        currentHealth = hearts.Length;
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
            }
        }
    }
}
