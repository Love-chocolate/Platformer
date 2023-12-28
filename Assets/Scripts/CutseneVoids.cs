using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CutseneVoids : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    [SerializeField] private GameObject firstCutsceneText;
    [SerializeField] private GameObject secondCutsceneText;

    [SerializeField] private GameObject firstBlackStripe;
    [SerializeField] private GameObject secondBlackStripe;

    public void DestroyCutsceneObjects()
    {
        Destroy(firstBlackStripe);
        Destroy(secondBlackStripe);
        Destroy(firstCutsceneText);
        Destroy(secondCutsceneText);
    }

    public void ShowText()
    {
        firstCutsceneText.SetActive(true);
    }

    public void ChangeCutsceneText()
    {
        firstCutsceneText.SetActive(false);
        secondCutsceneText.SetActive(true);
    }

    public void EnablePlayerController()
    {
        playerController.enabled = true;
    }

}
