using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent _agent = null;
    [SerializeField] private Camera _camera = null;
    private float _cooldown = 0.3f;
    private bool isStopped = true;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (isStopped) { return; }

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
    public void StartMoving()
    {
        isStopped = false;
    }
    public void StopMoving()
    {
        isStopped = true;
    }
}