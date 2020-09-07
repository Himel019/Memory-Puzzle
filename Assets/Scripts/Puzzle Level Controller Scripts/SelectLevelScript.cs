﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelScript : MonoBehaviour
{
    private LoadPuzzleGame loadPuzzleGame;

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
        loadPuzzleGame = GameObject.Find("Puzzle Game Controller").GetComponent<LoadPuzzleGame>();
        selectPuzzleMenuAnimator = selectPuzzleMenuPanel.GetComponent<Animator>();
        selectPuzzleLevelAnimator = selectPuzzleLevelPanel.GetComponent<Animator>();
    }

    public void BackToPuzzleSelectMenu() {
        StartCoroutine(ShowPuzzleSelectMenu());
    }

    public void SelectPuzzleLevel() {
        int level = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        Debug.Log(level);
        loadPuzzleGame.LoadPuzzle(level, selectedPuzzle);
    }

    private IEnumerator ShowPuzzleSelectMenu() {
        selectPuzzleMenuPanel.SetActive(true);
        selectPuzzleMenuAnimator.Play("Slide In");
        selectPuzzleLevelAnimator.Play("Slide Out");
        yield return new WaitForSeconds(0.40f);
        selectPuzzleLevelPanel.SetActive(false);
    }

    public void SetSelectedPuzzle(string selectedPuzzle) {
        this.selectedPuzzle = selectedPuzzle;
        Debug.Log("The selected level is " + selectedPuzzle);
    }
}