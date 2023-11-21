using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    public int Id { get; private set; }

    private void Start()
    {
        Id = GetInstanceID();
    }

    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
