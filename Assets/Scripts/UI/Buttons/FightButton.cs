using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightButton : AbstractButton
{
    [SerializeField] private Load _load;
    [SerializeField] private LoadScreen _loadScreen;

    private int _sceneNumber = 1;

    private void Start()
    {
        _sceneNumber = _load.GetScene();
    }

    public override void OnClick()
    {
        _loadScreen.Loading(_sceneNumber);
        //SceneManager.LoadScene(_sceneNumber);
    }
}
