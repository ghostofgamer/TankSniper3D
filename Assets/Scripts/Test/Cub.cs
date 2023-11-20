using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cub : MonoBehaviour
{
    private Color _defaultColor = Color.red;

    public bool IsStay = false;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Merge merge))
            IsStay = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Merge merge))
        {
            IsStay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Merge merge))
            IsStay = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Merge merge))
            IsStay = false;
    }

    //private void Update()
    //{
    //    GetRaycast();
    //}

    public void ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.black;
        Debug.Log("1");
    }

    public void ResetColor()
    {
        GetComponent<Renderer>().material.color = _defaultColor;
        Debug.Log("2");
    }

    private void GetRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.up);
        Physics.Raycast(ray, out hit);

        if (hit.collider.GetComponent<DragAndDrop>())
        {
            ChangeColor();
        }
        else
        {
            ResetColor();
            return;
        }
    }
}
