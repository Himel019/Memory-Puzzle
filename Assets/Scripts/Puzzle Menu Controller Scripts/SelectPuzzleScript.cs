using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPuzzleScript : MonoBehaviour
{
    private SelectLevelScript selectLevelScript;
    private PuzzleGameManager puzzleGameManager;
    private LevelLocker levelLocker;
    private StarsLocker starsLocker;

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
        puzzleGameManager = GameObject.Find("Puzzle Game Controller").GetComponent<PuzzleGameManager>();
        selectLevelScript = GameObject.Find("Puzzle Level Controller").GetComponent<SelectLevelScript>();
        levelLocker = GameObject.Find("Puzzle Level Controller").GetComponent<LevelLocker>();
        starsLocker = GameObject.Find("Puzzle Level Controller").GetComponent<StarsLocker>();
        selectPuzzleMenuAnimator = selectPuzzleMenuPanel.GetComponent<Animator>();
        selectPuzzleLevelAnimator = selectPuzzleLevelPanel.GetComponent<Animator>();
    }

    public void SelectedPuzzle() {
        starsLocker.DeactivateStars(); 

        selectedPuzzle = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        puzzleGameManager.SetSelectedPuzzle(selectedPuzzle);

        levelLocker.CheckWhichLevelsAreUnlocked(selectedPuzzle);

        selectLevelScript.SetSelectedPuzzle(selectedPuzzle);

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
