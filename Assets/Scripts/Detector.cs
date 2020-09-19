using UnityEngine;

public class Detector : MonoBehaviour
{

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit))
        {

            if (hit.transform.TryGetComponent(out Dust dust))
            {
                dust.Disolve();
            }
        }

    }
}
