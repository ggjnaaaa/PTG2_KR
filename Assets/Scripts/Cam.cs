using UnityEngine;

//~~~~~~    �������    ~~~~~~//
public class Cam : MonoBehaviour
{
    public Camera cam;
    public LayerMask monsters;

    void LateUpdate()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        //~~~~~~    �������� ������� ��� � ����������� ������� �� ����� monsters    ~~~~~~//
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 1000, monsters))
        {
            //~~~~~~    ������ ����������    ~~~~~~//
            Smilr smile = hit.transform.GetComponent<Smilr>();
            if (smile != null)
                smile.Death();
        }
    }
}
