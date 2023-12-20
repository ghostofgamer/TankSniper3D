using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightButton : AbstractButton
{
    [SerializeField] private Load _load;
    [SerializeField] private LoadScreen _loadScreen;

    private int _startSceneIndex = 2;
    private int _sceneNumber;

    private void Start()
    {
        _sceneNumber = _load.Get(Save.SceneNumber, _startSceneIndex);
        //Debug.Log("Номер сцены " + _sceneNumber);

        if (_sceneNumber > 16)
        {
            _sceneNumber = _startSceneIndex;
        }
    }

    public override void OnClick()
    {
        _loadScreen.Loading(_sceneNumber);
    }

    public void ResetSceneNumber()
    {
        _sceneNumber = _load.Get(Save.SceneNumber, _startSceneIndex);
    }
}