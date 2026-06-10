using System.Collections;
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
    private PatrolController _patrolController;
    private NavMeshAgent _agent; //Responsavel por calcular rotas e mover
    [SerializeField] private Transform _player;
    private EnemyState _currentState;
    [SerializeField][Range(0.5f, 5f)] private float _waitTime;
    private GameObject _nape;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        _nape = transform.GetChild(0).gameObject; //Pega o primeiro filho do inimigo, que é o pescoço
        _player = GameController.Instance.PlayerTransform;
        _patrolController = GameController.Instance.PatrolController;
        _agent = GetComponent<NavMeshAgent>();
        yield return new WaitForSeconds(1); //Espera até que o NavMeshAgent esteja pronto para ser usado
        SetState(EnemyState.Patrolling);
    }

    // Update is called once per frame
    void Update()
    {
        Vision();
        /* if (!_currentState.Equals(EnemyState.Patrolling))
            return;
        if (_agent.remainingDistance <= _agent.stoppingDistance)
            return;

        print ("Inimigo chegou ao ponto de patrulha");
        SetState(EnemyState.Idle);
        */
    }

    public void Vision()
    {
        bool playerInSight = Physics.Linecast(transform.position, _player.position, out RaycastHit hit);
        if (playerInSight) //Não Vejo o Player
        {
            /*
            //Aqui o inimigo para
            _agent.SetDestination(transform.position);
            */

            if (_currentState.Equals(EnemyState.Chasing))
            {
                SetState(EnemyState.Idle);
            }

        }
        else //Aqui Vejo o Player
        {
            /*
            //Aqui ele persegue
            _agent.SetDestination(_player.position);
            */

            if (_currentState.Equals(EnemyState.Chasing))
                return;
            StopAllCoroutines(); //Caso o inimigo esteja em outro estado, para todas as coroutines
            SetState(EnemyState.Chasing);
        }

        /*
        //Se houver um obstaculo, o inimigo não persegue o jogador
        bool playerInSight = Physics.Linecast(transform.position, _player.position, out RaycastHit hit);
        if (playerInSight)
        {
            print("Não Vejo");
            if (!_currentState.Equals(EnemyState.Chasing)) //Se não estiver perseguindo, não executa o resto
                return;
            SetState(EnemyState.Idle);//Se estiver perseguindo, passa a ficar IDLE
                return;//Aqui ainda é dentro do if, então não quero que execute o método
        }
        print("Vejo");
        //Se chegar aqui, é porque o inimigo tem visão do jogador, então ele deve perseguir
        if (!_currentState.Equals(EnemyState.Chasing)) //Se o inimigo já estiver perseguindo
            return;
        SetState(EnemyState.Chasing);
        */
    }

    public void SetState(EnemyState newState)
    {
        //O primeiro switch é para simular um OnTriggerEnter, onde o inimigo para fazer algo relacionado ao estado que ele estava, como por exemplo, se ele estava perseguindo, ele para de perseguir, ou seja, para o NavMeshAgent

        switch (_currentState)
        {
            case EnemyState.Idle:
                // Lógica para sair do estado Idle
                break;
            case EnemyState.Chasing:
                // Lógica para sair do estado Chasing
                _agent.SetDestination(_player.position); //Aqui o inimigo para de perseguir, ou seja, para o NavMeshAgent
                break;
            case EnemyState.Patrolling:
                // Lógica para sair do estado Patrolling
                print("Inimigo parou de Patrulhar");
                break;
        }
        _currentState = newState; //Aqui atualizamos o estado atual para o novo estado
        //O segundo switch é para lidar com a lógica de entrada no novo estado
        switch (_currentState)
        {
            case EnemyState.Idle:
                StartCoroutine(Wait());//Inicia a coroutine para esperar um tempo antes de começar a patrulhar
                break;
            case EnemyState.Chasing:
                _nape.SetActive(false); //Aqui o inimigo ativa o pescoço, ou seja, ele olha para o jogador
                _agent.SetDestination(_player.position);
                break;
            case EnemyState.Patrolling:
                // Implementar lógica de patrulha aqui
                print("Inimigo começou a Patrulhar");
                _agent.SetDestination(_patrolController.MoveToNextPoint());
                StartCoroutine(Patrolling());
                break;
        }
    }
    IEnumerator Wait()
    {
        //Ainda Tenho que adicionar uma verificação para o inimigo
        Debug.LogError("Temporario");
        yield return new WaitUntil(() => _agent.remainingDistance <= _agent.stoppingDistance);
        yield return new WaitForSeconds(_waitTime);
        SetState(EnemyState.Patrolling);
    }

    IEnumerator Patrolling()
    {
        // yield return new WaitForSeconds(_waitTime);
        yield return new WaitUntil(() => _agent.remainingDistance <= _agent.stoppingDistance);
        SetState(EnemyState.Idle);
    }

}
