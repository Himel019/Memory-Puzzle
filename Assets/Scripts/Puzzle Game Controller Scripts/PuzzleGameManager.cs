using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PuzzleGameManager : MonoBehaviour
{
    private GameFinished gameFinished;

    private List<Button> puzzleButtons = new List<Button>();
    private List<Animator> puzzleButtonAnimators = new List<Animator>();
    [SerializeField]
    private List<Sprite> gamePuzzleSprites = new List<Sprite>();

    private int level;
    private string selectedPuzzle;
    private Sprite puzzleBackgroundImage;

    private bool firstGuess, secondGuess;
    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessPuzzle, secondGuessPuzzle;

    private int countTryGuess;
    private int countCorrectGuess;
    private int gameGuess;
    private int totalStar;

    void Start() {
        gameFinished = GetComponent<GameFinished>();
    }

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
            StartCoroutine(CheckIfThePuzzlesMatch());

            countTryGuess++;
        }
    }

    private IEnumerator CheckIfThePuzzlesMatch() {
        yield return new WaitForSeconds(1f);

        if(firstGuessPuzzle == secondGuessPuzzle) {
            puzzleButtonAnimators[firstGuessIndex].Play("Fade Out");
            puzzleButtonAnimators[secondGuessIndex].Play("Fade Out");

            CheckIfTheGameIsFinished();
        } else {
            StartCoroutine(TurnPuzzleButtonBack(puzzleButtonAnimators[firstGuessIndex],
                                                puzzleButtons[firstGuessIndex], puzzleBackgroundImage));

            StartCoroutine(TurnPuzzleButtonBack(puzzleButtonAnimators[secondGuessIndex],
                                                puzzleButtons[secondGuessIndex], puzzleBackgroundImage));
        }

        yield return new WaitForSeconds(0.6f);

        firstGuess = secondGuess = false;
    }

    private void CheckIfTheGameIsFinished() {
        countCorrectGuess++;

        if(countCorrectGuess == gameGuess) {
            Debug.Log("Game ends no more puzzles");
            CheckHowManyGuesses();
        }
    }

    private void CheckHowManyGuesses() {
        int howManyGuesses = 0;

        switch(level) {
            case 0:
                howManyGuesses = 5;
                break;
            case 1:
                howManyGuesses = 10;
                break;
            case 2:
                howManyGuesses = 15;
                break;
            case 3:
                howManyGuesses = 20;
                break;
            case 4:
                howManyGuesses = 25;
                break;
        }

        if(countTryGuess < howManyGuesses) {
            gameFinished.ShowGameFinishedPanel(3);
            totalStar = 3;
        } else if(countTryGuess < (howManyGuesses + 2)) {
            gameFinished.ShowGameFinishedPanel(2);
            totalStar = 2;
        } else {
            gameFinished.ShowGameFinishedPanel(1);
            totalStar = 1;
        }
    }

    public List<Animator> ResetGameplay() {
        firstGuess = secondGuess = false;

        countTryGuess = 0;
        countCorrectGuess = 0;

        gameFinished.HiddenGameFinishedPanel(totalStar);

        return puzzleButtonAnimators;
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

        gameGuess = puzzleButtons.Count / 2;

        puzzleBackgroundImage = puzzleButtons[0].image.sprite;

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
