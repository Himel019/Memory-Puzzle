using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    private PuzzleMusicController puzzleMusicController;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private GameObject settingsPanel;
    private Animator settingsPanelAnimator;

    // Start is called before the first frame update
    void Start()
    {
        puzzleMusicController = GameObject.Find("Puzzle Music Controller").GetComponent<PuzzleMusicController>();
        settingsPanelAnimator = settingsPanel.GetComponent<Animator>();
    }

    public void OpenSettingsPanel() {
        slider.value = puzzleMusicController.GetMusicVolume();
        settingsPanel.SetActive(true);
        settingsPanelAnimator.Play("Slide In");
    }

    public void CloseSettingsPanel() {
        if(settingsPanel.activeInHierarchy){
            StartCoroutine(CloseSetting());
        }
    }

    private IEnumerator CloseSetting() {
        settingsPanelAnimator.Play("Slide Out");
        yield return new WaitForSeconds(0.40f);
        settingsPanel.SetActive(false);
    }

    public void GetVolume(float volume) {
        puzzleMusicController.SetMusicVolume(volume);
    }
}
