using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class GameData
{
    private bool[] candyPuzzleLevels;
    private bool[] transportPuzzleLevels;
    private bool[] fruitPuzzleLevels;

    private int[] candyPuzzleLevelStars;
    private int[] transportPuzzleLevelStars;
    private int[] fruitPuzzleLevelStars;

    private bool hasGameStartedForTheFirstTime;

    private float musicVolume;

    public void SetCandyPuzzleLevels(bool[] candyPuzzleLevels) {
        this.candyPuzzleLevels = candyPuzzleLevels;
    }

    public bool[] GetCandyPuzzleLevels() {
        return this.candyPuzzleLevels;
    }

    public void SetTransportPuzzleLevels(bool[] transportPuzzleLevels) {
        this.transportPuzzleLevels = transportPuzzleLevels;
    }

    public bool[] GetTransportPuzzleLevels() {
        return this.transportPuzzleLevels;
    }

    public void SetFruitPuzzleLevels(bool[] fruitPuzzleLevels) {
        this.fruitPuzzleLevels = fruitPuzzleLevels;
    }

    public bool[] GetFruitPuzzleLevels() {
        return this.fruitPuzzleLevels;
    }

    public void SetCandyPuzzleLevelStars(int[] candyPuzzleLevelStars) {
        this.candyPuzzleLevelStars = candyPuzzleLevelStars;
    }

    public int[] GetCandyPuzzleLevelStars() {
        return this.candyPuzzleLevelStars;
    }

    public void SetTransportPuzzleLevelStars(int[] transportPuzzleLevelStars) {
        this.transportPuzzleLevelStars = transportPuzzleLevelStars;
    }

    public int[] GetTransportPuzzleLevelStars() {
        return this.transportPuzzleLevelStars;
    }

    public void SetFruitPuzzleLevelStars(int[] fruitPuzzleLevelStars) {
        this.fruitPuzzleLevelStars = fruitPuzzleLevelStars;
    }

    public int[] GetFruitPuzzleLevelStars() {
        return this.fruitPuzzleLevelStars;
    }

    public void SetHasGameStartedForTheFirstTime(bool hasGameStartedForTheFirstTime) {
        this.hasGameStartedForTheFirstTime = hasGameStartedForTheFirstTime;
    }

    public bool GetHasGameStartedForTheFirstTime() {
        return this.hasGameStartedForTheFirstTime;
    }

    public void SetMusicVolume(float musicVolume) {
        this.musicVolume = musicVolume;
    }

    public float GetMusicVolume() {
        return this.musicVolume;
    }
}
