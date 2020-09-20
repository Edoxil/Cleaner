using UnityEngine;
using UnityEngine.Events;

public class Detector : MonoBehaviour
{
    public UnityEvent DustCleared;
    private RaycastHit _hit;
    private Ray _ray;

    private void Start()
    {
        _ray = new Ray(transform.position, Vector3.down);
    }
    void Update()
    {
        _ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(_ray, out _hit))
        {

            if (_hit.transform.TryGetComponent(out Dust dust))
            {
                dust.Clear();
                DustCleared?.Invoke();
            }
        }

    }
}
