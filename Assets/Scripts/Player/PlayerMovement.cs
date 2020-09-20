using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent _agent = null;
    [SerializeField] private Camera _camera = null;
    private float _cooldown = 0.3f;
    private bool isStopped = true;
    private RaycastHit _hit;
    private Ray _ray;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
    }
    // Каждые 0.3 сек указываем путь игроку в текущее положение мыши
    private void Update()
    {
        if (isStopped) { return; }

        _cooldown -= Time.deltaTime;

        if (_cooldown <= 0)
        {


            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit))
            {
                _agent.SetDestination(_hit.point);
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