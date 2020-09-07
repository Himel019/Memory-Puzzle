using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPuzzleGame : MonoBehaviour
{
    private LayoutPuzzleButtons layoutPuzzleButtons;

    [SerializeField]
    private GameObject puzzleLevelSelectPanel;
    private Animator puzzleLevelSelectAnimator;

    [SerializeField]
    private GameObject puzzleGamePanel1;
    private Animator puzzleGamePanelAnimator1;

    [SerializeField]
    private GameObject puzzleGamePanel2;
    private Animator puzzleGamePanelAnimator2;

    [SerializeField]
    private GameObject puzzleGamePanel3;
    private Animator puzzleGamePanelAnimator3;

    [SerializeField]
    private GameObject puzzleGamePanel4;
    private Animator puzzleGamePanelAnimator4;

    [SerializeField]
    private GameObject puzzleGamePanel5;
    private Animator puzzleGamePanelAnimator5;

    private int puzzleLevel;
    private string selectedPuzzle;

    /// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
    void Start()
    {
        layoutPuzzleButtons = GetComponent<LayoutPuzzleButtons>();
        puzzleLevelSelectAnimator = puzzleLevelSelectPanel.GetComponent<Animator>();
        puzzleGamePanelAnimator1 = puzzleGamePanel1.GetComponent<Animator>();
        puzzleGamePanelAnimator2 = puzzleGamePanel2.GetComponent<Animator>();
        puzzleGamePanelAnimator3 = puzzleGamePanel3.GetComponent<Animator>();
        puzzleGamePanelAnimator4 = puzzleGamePanel4.GetComponent<Animator>();
        puzzleGamePanelAnimator5 = puzzleGamePanel5.GetComponent<Animator>();
    }

    public void LoadPuzzle(int level, string puzzle) {
        this.puzzleLevel = level;
        this.selectedPuzzle = puzzle;

        layoutPuzzleButtons.LayoutButtons(level, selectedPuzzle);

        switch(puzzleLevel) {
            case 0:
                StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel1, puzzleGamePanelAnimator1));
                break;
            case 1:
                StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel2, puzzleGamePanelAnimator2));
                break;
            case 2:
                StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel3, puzzleGamePanelAnimator3));
                break;
            case 3:
                StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel4, puzzleGamePanelAnimator4));
                break;
            case 4:
                StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel5, puzzleGamePanelAnimator5));
                break;
        }
    }

    public void BackToPuzzleLevelSelectMenu() {
        switch(puzzleLevel) {
            case 0:
                StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel1, puzzleGamePanelAnimator1));
                break;
            case 1:
                StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel2, puzzleGamePanelAnimator2));
                break;
            case 2:
                StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel3, puzzleGamePanelAnimator3));
                break;
            case 3:
                StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel4, puzzleGamePanelAnimator4));
                break;
            case 4:
                StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel5, puzzleGamePanelAnimator5));
                break;
        }
    }

    private IEnumerator LoadPuzzleLevelSelectMenu(GameObject puzzleGamePanel, Animator puzzleGamePanelAnimator) {
        puzzleLevelSelectPanel.SetActive(true);
        puzzleLevelSelectAnimator.Play("Slide In");
        puzzleGamePanelAnimator.Play("Slide Out");
        yield return new WaitForSeconds(0.40f);
        puzzleGamePanel.SetActive(false);
    }

    private IEnumerator LoadPuzzleGamePanel(GameObject puzzleGamePanel, Animator puzzleGamePanelAnimator) {
        puzzleGamePanel.SetActive(true);
        puzzleGamePanelAnimator.Play("Slide In");
        puzzleLevelSelectAnimator.Play("Slide Out");
        yield return new WaitForSeconds(0.40f);
        puzzleLevelSelectPanel.SetActive(false);
    }
}
