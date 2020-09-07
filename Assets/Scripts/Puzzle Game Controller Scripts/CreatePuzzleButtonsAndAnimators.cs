using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CreatePuzzleButtonsAndAnimators : MonoBehaviour
{
    private LayoutPuzzleButtons layoutPuzzleButtons;

    [SerializeField]
    private Button puzzleButton;

    [SerializeField]
    private int puzzleGame1 = 6;
    [SerializeField]
    private int puzzleGame2 = 12;
    [SerializeField]
    private int puzzleGame3 = 18;
    [SerializeField]
    private int puzzleGame4 = 24;
    [SerializeField]
    private int puzzleGame5 = 30;

    private List<Button> level1Button = new List<Button>();
    private List<Button> level2Button = new List<Button>();
    private List<Button> level3Button = new List<Button>();
    private List<Button> level4Button = new List<Button>();
    private List<Button> level5Button = new List<Button>();

    private List<Animator> level1Animator = new List<Animator>();
    private List<Animator> level2Animator = new List<Animator>();
    private List<Animator> level3Animator = new List<Animator>();
    private List<Animator> level4Animator = new List<Animator>();
    private List<Animator> level5Animator = new List<Animator>();

    void Awake() {
        layoutPuzzleButtons = GetComponent<LayoutPuzzleButtons>();
        CreateButtons(level1Button, level1Animator, puzzleGame1);
        CreateButtons(level2Button, level2Animator, puzzleGame2);
        CreateButtons(level3Button, level3Animator, puzzleGame3);
        CreateButtons(level4Button, level4Animator, puzzleGame4);
        CreateButtons(level5Button, level5Animator, puzzleGame5);
        AssignButtonsAndAnimators();
    }

    private void CreateButtons(List<Button> levelButtonList, List<Animator> levelAnimatorList, int totalButtons) {
        for(int i = 0; i < totalButtons; i++) {
            Button button = Instantiate(puzzleButton);
            button.gameObject.name = i.ToString();
            levelButtonList.Add(button);
            levelAnimatorList.Add(levelButtonList[i].gameObject.GetComponent<Animator>());
            levelButtonList[i].gameObject.SetActive(false);
        }
    }

    private void AssignButtonsAndAnimators() {
        layoutPuzzleButtons.SetLevelButtonLists(level1Button, level2Button, level3Button, level4Button, level5Button);
        layoutPuzzleButtons.SetLevelAnimatorLists(level1Animator, level2Animator, level3Animator, level4Animator, level5Animator);
    }
}
