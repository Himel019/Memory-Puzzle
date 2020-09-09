using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SetupPuzzleGame : MonoBehaviour
{
    private PuzzleGameManager puzzleGameManager;

    private Sprite[] candyPuzzleSprites;
    private Sprite[] transportPuzzleSprites;
    private Sprite[] fruitPuzzleSprites;

    private List<Sprite> gamePuzzles = new List<Sprite>();
    private List<Button> puzzleButtons = new List<Button>();
    private List<Animator> puzzleButtonAnimators = new List<Animator>();

    private int level;
    private string selectedPuzzle;

    private int looper;

    void Awake() {
        puzzleGameManager = GetComponent<PuzzleGameManager>();

        candyPuzzleSprites = Resources.LoadAll<Sprite> ("Sprites/Game Assets/Candy");
        transportPuzzleSprites = Resources.LoadAll<Sprite> ("Sprites/Game Assets/Transport");
        fruitPuzzleSprites = Resources.LoadAll<Sprite> ("Sprites/Game Assets/Fruits");
    }

    private void PrepareGameSprites() {
        gamePuzzles.Clear();
        gamePuzzles = new List<Sprite>();

        int index = 0;
        
        switch(level) {
            case 0:
                looper = 6;
                break;
            case 1:
                looper = 12;
                break;
            case 2:
                looper = 18;
                break;
            case 3:
                looper = 24;
                break;
            case 4:
                looper = 30;
                break;
        }

        switch(selectedPuzzle) {
            case "Candy Puzzle Button":
                AddSpritesToGamePuzzle(looper, index, candyPuzzleSprites);
                break;
            case "Transport Puzzle Button":
                AddSpritesToGamePuzzle(looper, index, transportPuzzleSprites);
                break;
            case "Fruits Puzzle Button":
                AddSpritesToGamePuzzle(looper, index, fruitPuzzleSprites);
                break;
        }

        Shuffle(gamePuzzles);
    }

    private void AddSpritesToGamePuzzle(int looper, int index, Sprite[] puzzleSprites) {
        for(int i = 0; i < looper; i++) {
            if(index == (looper/2)){
                index = 0;
            }

            gamePuzzles.Add(puzzleSprites[index]);
            index++;
        }
    }

    private void Shuffle(List<Sprite> list) {
        for(int i = 0; i < list.Count; i++) {
            int randomIndex = Random.Range(i, list.Count);
            Sprite temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    } 

    public void SetLevelAndPuzzle(int level, string selectedPuzzle) {
        this.level = level;
        this.selectedPuzzle = selectedPuzzle;

        PrepareGameSprites();

        puzzleGameManager.SetGamePuzzleSprites(this.gamePuzzles);
    }

    public void SetPuzzleButtonsAndAnimators(List<Button> puzzleButtons, List<Animator> puzzleButtonAnimators) {
        this.puzzleButtons = puzzleButtons;
        this.puzzleButtonAnimators = puzzleButtonAnimators;

        puzzleGameManager.SetUpButtonsAndAnimators(puzzleButtons, puzzleButtonAnimators);
    }
}
