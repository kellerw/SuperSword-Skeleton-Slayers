﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : GridOptions {

    public SceneSwitcher sceneSwitcher;
    public GameObject creditsWindow;

    public override void OpenMenu()
    {
        canControl = true;
        UpdateCursor(listTexts, 0);
    }

    public override void CloseMenu()
    {
        canControl = false;
    }

    private void Start()
    {
        listTexts = transform.GetComponentsInChildren<RectTransform>();
        RectTransform[] temp = new RectTransform[3];
        for (int i = 1; i < listTexts.Length; i++)
        {
            temp[i - 1] = listTexts[i];
        }
        listTexts = temp;
    }

    protected override void MakeMenuSelection(int menuIndex)
    {
        Debug.Log("Make menu selection: " + menuIndex);
        switch (menuIndex)
        {
            case (0):
                // Start new game
                sceneSwitcher.SwitchToMapScene("MapGenTest");
                StartCoroutine(StartingGame());
                break;
            case (1):
                // View Controls
                Debug.Log("Go to Controls");
                break;
            case (2):
                // Go to credits
                CloseMenu();
                creditsWindow.GetComponent<CreditsScreen>().OpenMenu();
                break;
        }
    }

    IEnumerator StartingGame()
    {
        while (sceneSwitcher.isSwitching)
        {
            yield return null;
        }

        yield return new WaitForSeconds(2);
    }
}
