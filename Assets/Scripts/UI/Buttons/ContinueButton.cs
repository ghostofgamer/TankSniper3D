using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ContinueButton : AbstractButton
{
    private const string MainMenu = "MainScene";

    public override void OnClick()
    {
        SceneManager.LoadScene(MainMenu);
    }
}
