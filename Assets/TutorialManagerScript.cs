using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialPrompt : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    private bool moved = false;
    private bool ran = false;

    void Start()
    {
        tutorialText.text = "Use A/D to Move";
    }

    void Update()
    {
        if (!moved && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
        {
            moved = true;
            StartCoroutine(ShowRunInstruction());
        }
        else if (moved && !ran && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)))
        {
            ran = true;
            tutorialText.text = "Impresive";
            StartCoroutine(HideText());
        }
    }

    IEnumerator ShowRunInstruction()
    {
        tutorialText.text = "Good...";
        yield return new WaitForSeconds(2f);
        tutorialText.text = "Now try to hold shift to run";
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(2f);
        tutorialText.gameObject.SetActive(false);
    }
}
