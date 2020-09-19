using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private Camera _camera;
    private float _cooldown = 0.3f;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _cooldown -= Time.deltaTime;

        if (_cooldown <= 0)
        {

            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                _agent.SetDestination(hit.point);
            }
            _cooldown = 0.3f;
        }

    }
}