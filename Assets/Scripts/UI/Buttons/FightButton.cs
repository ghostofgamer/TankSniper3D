using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightButton : AbstractButton
{
    private int _sceneNumber = 3;

    public override void OnClick()
    {
        SceneManager.LoadScene(_sceneNumber);
    }
}
