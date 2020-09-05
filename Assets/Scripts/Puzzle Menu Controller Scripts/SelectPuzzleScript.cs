using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPuzzleScript : MonoBehaviour
{
    [SerializeField]
    private GameObject selectPuzzleMenuPanel;
    [SerializeField]
    private GameObject selectPuzzleLevelPanel;
    private Animator selectPuzzleMenuAnimator;
    private Animator selectPuzzleLevelAnimator;

    private string selectedPuzzle;

    /// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
    void Start()
    {
        selectPuzzleMenuAnimator = selectPuzzleMenuPanel.GetComponent<Animator>();
        selectPuzzleLevelAnimator = selectPuzzleLevelPanel.GetComponent<Animator>();
    }

    public void SelectedPuzzle() {
        selectedPuzzle = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        StartCoroutine(ShowPuzzleLevelSelectMenu());
    }

    private IEnumerator ShowPuzzleLevelSelectMenu() {
        selectPuzzleLevelPanel.SetActive(true);
        selectPuzzleMenuAnimator.Play("Slide Out");
        selectPuzzleLevelAnimator.Play("Slide In");
        yield return new WaitForSeconds(0.40f);
        selectPuzzleMenuPanel.SetActive(false);
    }
}
