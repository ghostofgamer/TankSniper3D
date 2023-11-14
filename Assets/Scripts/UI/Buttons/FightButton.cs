using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightButton : AbstractButton
{
    [SerializeField] private Load _load;

    private int _sceneNumber = 1;

    private void Start()
    {
        _sceneNumber = _load.GetScene();
    }

    public override void OnClick()
    {
        SceneManager.LoadScene(_sceneNumber);
    }
}
