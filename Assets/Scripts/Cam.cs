using UnityEngine;

//~~~~~~    Падение    ~~~~~~//
public class Cam : MonoBehaviour
{
    public Camera cam;
    public LayerMask monsters;

    void LateUpdate()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        //~~~~~~    Проверка нажатия ЛКМ и пересечения курсора со слоем monsters    ~~~~~~//
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 1000, monsters))
        {
            //~~~~~~    Смерть противника    ~~~~~~//
            Smilr smile = hit.transform.GetComponent<Smilr>();
            if (smile != null)
                smile.Death();
        }
    }
}
