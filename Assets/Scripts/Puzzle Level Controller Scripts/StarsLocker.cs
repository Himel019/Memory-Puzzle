using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsLocker : MonoBehaviour
{
    private PuzzleGameSaver puzzleGameSaver;

    [SerializeField]
    private GameObject[] level1Stars;
    [SerializeField]
    private GameObject[] level2Stars;
    [SerializeField]
    private GameObject[] level3Stars;
    [SerializeField]
    private GameObject[] level4Stars;
    [SerializeField]
    private GameObject[] level5Stars;

    public int[] candyPuzzleLevelStars;
    public int[] transportPuzzleLevelStars;
    public int[] fruitPuzzleLevelStars;

    void Awake() {
        puzzleGameSaver = GameObject.Find("Puzzle Game Saver").GetComponent<PuzzleGameSaver>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ActivateStars(int level, string selectedPuzzle) {
        GetStars();

        int stars;

        switch(selectedPuzzle) {
            case "Candy Puzzle Button":
                stars = candyPuzzleLevelStars[level];
                ActivateLevelStars(level, stars);

                break;
            case "Transport Puzzle Button":
                stars = transportPuzzleLevelStars[level];
                ActivateLevelStars(level, stars);

                break;
            case "Fruits Puzzle Button":
                stars = fruitPuzzleLevelStars[level];
                ActivateLevelStars(level, stars);

                break;
        }
    }

    private void ActivateLevelStars(int level, int looper) {
        switch(level) {
            case 0:
                if(looper != 0) {
                    for(int i = 0; i < looper; i++) {
                        level1Stars[i].SetActive(true);
                    }
                }
                break;
            case 1:
                if(looper != 0) {
                    for(int i = 0; i < looper; i++) {
                        level2Stars[i].SetActive(true);
                    }
                }
                break;
            case 2:
                if(looper != 0) {
                    for(int i = 0; i < looper; i++) {
                        level3Stars[i].SetActive(true);
                    }
                }
                break;
            case 3:
                if(looper != 0) {
                    for(int i = 0; i < looper; i++)  {
                        level4Stars[i].SetActive(true);
                    }
                }
                break;
            case 4:
                if(looper != 0) {
                    for(int i = 0; i < looper; i++) {
                        level5Stars[i].SetActive(true);
                    }
                }
                break;
        }
    }

    public void DeactivateStars() {
        for(int i = 0; i < level1Stars.Length; i++) {
            level1Stars[i].SetActive(false);
            level2Stars[i].SetActive(false);
            level3Stars[i].SetActive(false);
            level4Stars[i].SetActive(false);
            level5Stars[i].SetActive(false);
        }
    }

    private void GetStars() {
        candyPuzzleLevelStars = puzzleGameSaver.candyPuzzleLevelStars;
        transportPuzzleLevelStars = puzzleGameSaver.transportPuzzleLevelStars;
        fruitPuzzleLevelStars = puzzleGameSaver.fruitPuzzleLevelStars;
    }
}
