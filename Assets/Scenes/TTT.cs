using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class TTT : MonoBehaviour
//{
//    RaycastHit hit;
//    Ray MyRay;
//    //��������� �������� ����� ��� ����� ��������� ����� ����
//    //Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);
//    // Update is called once per frame
//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Mouse0))
//        {
//            MyRay = Camera.main.ScreenPointToRay(Input.mousePosition);
//            Debug.DrawRay(MyRay.origin, MyRay.direction * 10000, Color.yellow);
//            Debug.Log("���");
//            if (Physics.Raycast(MyRay, out hit, 100))
//            {
//                MeshFilter filter = hit.collider.GetComponent(typeof(MeshFilter)) as MeshFilter;
//                if (filter)
//                {
//                    //��� ������� �� �������� �������� �����               
//                    Debug.Log(filter.gameObject.name);
//                }
//            }
//        }
//    }
//}
