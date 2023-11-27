using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : AbstractButton
{
    [SerializeField] private Save _save;
    [SerializeField] private Load _load;
    [SerializeField] private Storage _storage;

    public override void OnClick()
    {
        _save.Reset();
        _load.ResetLoad();
        _storage.ResetStorage();
    }
}
