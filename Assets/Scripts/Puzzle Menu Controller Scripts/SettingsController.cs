using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SettingsController : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsPanel;
    private Animator settingsPanelAnimator;

    // Start is called before the first frame update
    void Start()
    {
        settingsPanelAnimator = settingsPanel.GetComponent<Animator>();
    }

    public void OpenSettingsPanel() {
        settingsPanel.SetActive(true);
        settingsPanelAnimator.Play("Slide In");
    }

    public void CloseSettingsPanel() {
        StartCoroutine(CloseSetting());
    }

    private IEnumerator CloseSetting() {
        settingsPanelAnimator.Play("Slide Out");
        yield return new WaitForSeconds(0.40f);
        settingsPanel.SetActive(false);
    }
}
