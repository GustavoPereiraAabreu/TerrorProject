using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent; //Responsavel por calcular rotas e mover
    [SerializeField] private Transform _player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.GetComponent<NavMeshAgent>().speed = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_player.position);
    }
}
