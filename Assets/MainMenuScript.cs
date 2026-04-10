using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private bool keyPressed = false;

    private void Update()
    {
        if (!keyPressed && Input.anyKeyDown) 
        { 
            keyPressed = true;
            SceneManager.LoadScene(1);
        }
    }
}
