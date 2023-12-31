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
    private int _maxScenes = 16;

    private void Start()
    {
        _sceneNumber = _load.Get(Save.SceneNumber, _startSceneIndex);

        if (_sceneNumber > _maxScenes)
            _sceneNumber = _startSceneIndex;
    }

    public override void OnClick()
    {
        _loadScreen.Loading(_sceneNumber);
    }
}