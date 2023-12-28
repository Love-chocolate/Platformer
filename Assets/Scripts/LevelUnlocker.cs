using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;

    void Start()
    {
        int levelToUnlock = PlayerPrefs.GetInt("LevelToUnlock");

        for (int i = 0; i <= levelToUnlock; i++)
        {
            if (levelButtons[i].transform.childCount > 1)
            {
                Destroy(levelButtons[i].transform.GetChild(1).gameObject);
                levelButtons[i].interactable = true;
                levelButtons[i].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
