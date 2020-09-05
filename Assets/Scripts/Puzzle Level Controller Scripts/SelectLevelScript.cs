using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelScript : MonoBehaviour
{
    [SerializeField]
    private GameObject selectPuzzleMenuPanel;
    [SerializeField]
    private GameObject selectPuzzleLevelPanel;
    private Animator selectPuzzleMenuAnimator;
    private Animator selectPuzzleLevelAnimator;

    /// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
    void Start()
    {
        selectPuzzleMenuAnimator = selectPuzzleMenuPanel.GetComponent<Animator>();
        selectPuzzleLevelAnimator = selectPuzzleLevelPanel.GetComponent<Animator>();
    }

    public void BackToPuzzleSelectMenu() {
        StartCoroutine(ShowPuzzleSelectMenu());
    }

    private IEnumerator ShowPuzzleSelectMenu() {
        selectPuzzleMenuPanel.SetActive(true);
        selectPuzzleMenuAnimator.Play("Slide In");
        selectPuzzleLevelAnimator.Play("Slide Out");
        yield return new WaitForSeconds(0.40f);
        selectPuzzleLevelPanel.SetActive(false);
    }
}
