using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLocker : MonoBehaviour
{
    private PuzzleGameSaver puzzleGameSaver;
    private StarsLocker starsLocker;

    [SerializeField]
    private GameObject[] levelStarsHolders;
    [SerializeField]
    private GameObject[] levelPadlocks;

    private bool[] candyPuzzleLevels;
    private bool[] transportPuzzleLevels;
    private bool[] fruitPuzzleLevels;

    void Awake() {
        puzzleGameSaver = GameObject.Find("Puzzle Game Saver").GetComponent<PuzzleGameSaver>();
        starsLocker = GetComponent<StarsLocker>();
        DeactivatePadlocksAndStarHolders();
    }

    void Start() {
        GetLevels();
    }

    public void CheckWhichLevelsAreUnlocked(string selectedPuzzle) {
        DeactivatePadlocksAndStarHolders();
        GetLevels();

        switch(selectedPuzzle) {
            case "Candy Puzzle Button":
                for(int i = 0; i < candyPuzzleLevels.Length; i++){
                    if(candyPuzzleLevels[i]) {
                        levelStarsHolders[i].SetActive(true);
                        starsLocker.ActivateStars(i, selectedPuzzle);
                    } else {
                        levelPadlocks[i].SetActive(true);
                    }
                }
                break;
            case "Transport Puzzle Button":
                for(int i = 0; i < transportPuzzleLevels.Length; i++) {
                    if(transportPuzzleLevels[i]) {
                        levelStarsHolders[i].SetActive(true);
                        starsLocker.ActivateStars(i, selectedPuzzle);
                    } else {
                        levelPadlocks[i].SetActive(true);
                    }
                }
                break;
            case "Fruits Puzzle Button":
                for(int i = 0; i < fruitPuzzleLevels.Length; i++) {
                    if(fruitPuzzleLevels[i]){
                        levelStarsHolders[i].SetActive(true);
                        starsLocker.ActivateStars(i, selectedPuzzle);
                    } else {
                        levelPadlocks[i].SetActive(true);
                    }
                }
                break;
        }
    }

    private void DeactivatePadlocksAndStarHolders() {
        for(int i = 0; i < levelStarsHolders.Length; i++) {
            levelStarsHolders[i].SetActive(false);
            levelPadlocks[i].SetActive(false);
        }
    }

    private void GetLevels() {
        candyPuzzleLevels = puzzleGameSaver.candyPuzzleLevels;
        transportPuzzleLevels = puzzleGameSaver.transportPuzzleLevels;
        fruitPuzzleLevels = puzzleGameSaver.fruitPuzzleLevels;
    }

    public bool[] GetPuzzleLevels(string selectedPuzzle) {
        switch(selectedPuzzle) {
            case "Candy Puzzle Button":
                return this.candyPuzzleLevels;
            case "Transport Puzzle Button":
                return this.transportPuzzleLevels;
            case "Fruits Puzzle Button":
                return this.fruitPuzzleLevels;
            default:
                return null;
        }
    }
}
