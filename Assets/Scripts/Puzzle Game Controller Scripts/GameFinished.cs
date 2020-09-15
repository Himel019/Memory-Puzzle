using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinished : MonoBehaviour
{
    [SerializeField]
    private GameObject gameFinishedPanel;

    private Animator gameFinishedAnimator;
    [SerializeField]
    private Animator star1Animator;
    [SerializeField]
    private Animator star2Animator;
    [SerializeField]
    private Animator star3Animator;
    [SerializeField]
    private Animator textAnimator;

    // Start is called before the first frame update
    void Start()
    {
        gameFinishedAnimator = gameFinishedPanel.GetComponent<Animator>();
        //ShowGameFinishedPanel(3);
    }

    public void ShowGameFinishedPanel(int stars) {
        StartCoroutine(ShowPanel(stars));
    }

    public void HiddenGameFinishedPanel(int stars) {
        if(gameFinishedPanel.activeInHierarchy) {
            StartCoroutine(HidePanel(stars));
        }
    }

    private IEnumerator ShowPanel(int stars) {
        gameFinishedPanel.SetActive(true);
        gameFinishedAnimator.Play("Fade In");

        yield return new WaitForSeconds(0.5f);

        switch(stars) {
            case 1:
                star1Animator.Play("Fade In");
                yield return new WaitForSeconds(.1f);
                textAnimator.Play("Fade In");
                break;
            case 2:
                star1Animator.Play("Fade In");
                yield return new WaitForSeconds(0.2f);
                star2Animator.Play("Fade In");
                yield return new WaitForSeconds(0.1f);
                textAnimator.Play("Fade In");
                break;
            case 3:
                star1Animator.Play("Fade In");
                yield return new WaitForSeconds(0.2f);
                star2Animator.Play("Fade In");
                yield return new WaitForSeconds(0.2f);
                star3Animator.Play("Fade In");
                yield return new WaitForSeconds(0.1f);
                textAnimator.Play("Fade In");
                break;
        }
    }

    private IEnumerator HidePanel(int stars) {
        gameFinishedAnimator.Play("Fade Out");

        if(stars == 1){
            star1Animator.Play("Fade Out");
            textAnimator.Play("Fade Out");
        }
        if(stars == 2){
            star1Animator.Play("Fade Out");
            star2Animator.Play("Fade Out");
            textAnimator.Play("Fade Out");
        }
        if(stars == 3){
            star1Animator.Play("Fade Out");
            star2Animator.Play("Fade Out");
            star3Animator.Play("Fade Out");
            textAnimator.Play("Fade Out");
        }

        yield return new WaitForSeconds(1f);

        gameFinishedPanel.SetActive(false);
    }
}
