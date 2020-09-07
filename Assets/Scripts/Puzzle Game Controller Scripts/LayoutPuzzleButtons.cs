using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutPuzzleButtons : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleLevel1;
    [SerializeField]
    private Transform puzzleLevel2;
    [SerializeField]
    private Transform puzzleLevel3;
    [SerializeField]
    private Transform puzzleLevel4;
    [SerializeField]
    private Transform puzzleLevel5;

    private List<Button> level1Button;
    private List<Button> level2Button;
    private List<Button> level3Button;
    private List<Button> level4Button;
    private List<Button> level5Button;

    private List<Animator> level1Animator;
    private List<Animator> level2Animator;
    private List<Animator> level3Animator;
    private List<Animator> level4Animator;
    private List<Animator> level5Animator;

    [SerializeField]
    private Sprite[] puzzleButtonsBacksideImages;

    private int puzzleLevel;
    private string selectedPuzzle;

    public void LayoutButtons(int level, string puzzle) {
        this.puzzleLevel = level;
        this.selectedPuzzle = puzzle;

        LayoutPuzzle();
    }

    private void LayoutPuzzle() {
        switch(puzzleLevel) {
            case 0:
                SetButtonList(level1Button, puzzleLevel1);
                break;
            case 1:
                SetButtonList(level2Button, puzzleLevel2);
                break;
            case 2:
                SetButtonList(level3Button, puzzleLevel3);
                break;
            case 3:
                SetButtonList(level4Button, puzzleLevel4);
                break;
            case 4:
                SetButtonList(level5Button, puzzleLevel5);
                break;
        }
    }

    public void SetLevelButtonLists (List<Button> level1List, List<Button> level2List,
                                     List<Button> level3List, List<Button> level4List, List<Button> level5List) {
        level1Button = level1List;
        level2Button = level2List;
        level3Button = level3List;
        level4Button = level4List;
        level5Button = level5List;
    }

    public void SetLevelAnimatorLists (List<Animator> level1List, List<Animator> level2List,
                                     List<Animator> level3List, List<Animator> level4List, List<Animator> level5List) {
        level1Animator = level1List;
        level2Animator = level2List;
        level3Animator = level3List;
        level4Animator = level4List;
        level5Animator = level5List;
    }

    private void SetButtonList(List<Button> buttonList, Transform puzzleLevel) {
        foreach(Button button in buttonList) {
            if(!button.gameObject.activeInHierarchy){
                button.gameObject.SetActive(true);
                button.gameObject.transform.SetParent(puzzleLevel, false);

                ChangeButtonSprite(button);
            }
        }
    }

    private void ChangeButtonSprite(Button button) {
        if(selectedPuzzle == "Candy Puzzle Button") {
            button.image.sprite = puzzleButtonsBacksideImages[0];
        } else if(selectedPuzzle == "Transport Puzzle Button") {
            button.image.sprite = puzzleButtonsBacksideImages[1];
        } else if(selectedPuzzle == "Fruits Puzzle Button") {
            button.image.sprite = puzzleButtonsBacksideImages[2];
        }
    }
}
