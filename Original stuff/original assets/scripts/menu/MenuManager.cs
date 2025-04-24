using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject howToPlayCanvas;
    public GameObject page1Panel;
    public GameObject page2Panel;

    
    public void PlayGame()
    {
        Debug.Log("PlayGame function called");
        SceneManager.LoadScene("level 1");
    }

    
    public void ShowHowToPlay()
    {
        menuCanvas.SetActive(false);
        howToPlayCanvas.SetActive(true);
        page1Panel.SetActive(true);
        page2Panel.SetActive(false);
    }

   
    public void NextPage()
    {
        page1Panel.SetActive(false);
        page2Panel.SetActive(true);
    }

    
    public void BackToPage1()
    {
        page2Panel.SetActive(false);
        page1Panel.SetActive(true);
    }

 
    public void BackToMenu()
    {
        howToPlayCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }
}
