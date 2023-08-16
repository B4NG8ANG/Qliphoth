using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rankingPanelAnimationManager : MonoBehaviour
{
    public GameObject rankingPanel;
    public GameObject rankingShowingButton;
    public GameObject rankingHidingButton;
    public Animator animator;

    public void ShowRankingPanel()
    {
        animator = rankingPanel.GetComponent<Animator>();
        animator.SetTrigger("doShow");
        rankingHidingButton.SetActive(true);
        rankingShowingButton.SetActive(false);
    }

    public void HideRankingPanel()
    {
        animator = rankingPanel.GetComponent<Animator>();
        animator.SetTrigger("doHide");
        rankingHidingButton.SetActive(false);
        rankingShowingButton.SetActive(true);
    }
}
