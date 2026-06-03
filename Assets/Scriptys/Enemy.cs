using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Idle,
    Chasing,
    Patrolling
}


public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent; //Responsavel por calcular rotas e mover
    [SerializeField] private Transform _player;
    private EnemyState _currentState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameController.Instance.PlayerTransform;
        _agent.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetState(EnemyState newState)
    {
        switch (_currentState)
        {
            case EnemyState.Idle:
                // Lógica para sair do estado Idle
                break;
            case EnemyState.Chasing:
                // Lógica para sair do estado Chasing
                break;
            case EnemyState.Patrolling:
                // Lógica para sair do estado Patrolling
                break;
        }

        _currentState = newState; //Aqui atualizamos o estado atual para o novo estado
        //O segundo switch é para lidar com a lógica de entrada no novo estado
        switch (_currentState)
        {
            case EnemyState.Idle:
                _agent.isStopped = true;
                break;
            case EnemyState.Chasing:
                _agent.isStopped = false;
                _agent.SetDestination(_player.position);
                break;
            case EnemyState.Patrolling:
                // Implementar lógica de patrulha aqui
                break;
        }
    }

}
