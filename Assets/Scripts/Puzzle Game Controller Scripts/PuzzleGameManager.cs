using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PuzzleGameManager : MonoBehaviour
{
    private List<Button> puzzleButtons = new List<Button>();
    private List<Animator> puzzleButtonAnimators = new List<Animator>();
    [SerializeField]
    private List<Sprite> gamePuzzleSprites = new List<Sprite>();

    private int level;
    private string selectedPuzzle;

    private bool firstGuess, secondGuess;
    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessPuzzle, secondGuessPuzzle;

    public void PickAPuzzle() {
        
        if(!firstGuess) {
            firstGuess = true;

            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzleSprites[firstGuessIndex].name;

            StartCoroutine(TurnPuzzleButtonUp(puzzleButtonAnimators[firstGuessIndex],
                                              puzzleButtons[firstGuessIndex], gamePuzzleSprites[firstGuessIndex]));

        } else if(!secondGuess) {
            secondGuess = true;

            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzleSprites[secondGuessIndex].name;

            StartCoroutine(TurnPuzzleButtonUp(puzzleButtonAnimators[secondGuessIndex],
                                                puzzleButtons[secondGuessIndex], gamePuzzleSprites[secondGuessIndex]));
            
            Debug.Log("First Guess Puzzle Name is " + firstGuessPuzzle + " Second Guess Puzzle Name is " + secondGuessPuzzle);
        }
    }

    private IEnumerator TurnPuzzleButtonUp(Animator animator, Button button, Sprite puzzleImage){
        animator.Play("Turn Up");
        yield return new WaitForSeconds(0.4f);
        button.image.sprite = puzzleImage;
    }

    private IEnumerator TurnPuzzleButtonBack(Animator animator, Button button, Sprite puzzleImage) {
        animator.Play("Turn Back");
        yield return new WaitForSeconds(0.4f);
        button.image.sprite = puzzleImage;
    }

    private void AddListeners() {
        foreach(Button button in puzzleButtons) {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => PickAPuzzle());
        }
    }

    public void SetUpButtonsAndAnimators(List<Button> buttons, List<Animator> animators) {
        this.puzzleButtons = buttons;
        this.puzzleButtonAnimators = animators;

        AddListeners();
    }

    public void SetGamePuzzleSprites(List<Sprite> gamePuzzleSprites) {
        this.gamePuzzleSprites = gamePuzzleSprites;
    }

    public void SetLevel(int level) {
        this.level = level;
    }

    public void SetSelectedPuzzle(string selectedPuzzle) {
        this.selectedPuzzle = selectedPuzzle;
    }
}
