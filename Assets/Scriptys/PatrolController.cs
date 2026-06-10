using UnityEngine;

public class PatrolController : MonoBehaviour
{
    [SerializeField] private Transform[] _patrolPoints;
    private int _currentPatrolIndex; //Ponto atual da patrulha

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public Vector3 GetRandomPoint()
    {
        int randomIndex = Random.Range(0, _patrolPoints.Length);
        return _patrolPoints[randomIndex].position;
        
    }
    public Vector3 MoveToNextPoint()
    { 
      if (_patrolPoints.Length == 0)
            return Vector3.zero;
        Vector3 nextPoint = _patrolPoints[_currentPatrolIndex].position;
        _currentPatrolIndex++;
        if (_currentPatrolIndex >= _patrolPoints.Length)
            _currentPatrolIndex = 0; // Volta para o primeiro ponto
        /*
         Se fosse fazer o mecanismo de booster do pokemon tcg
         para montar um esquema de "carrossel", teria que adicionar uma verificação de valor mínimo
         if (_currentPatrolIndex < 0)
            _currentPatrolIndex = _patrolPoints.Length - 1;
         */
        return nextPoint;
    }

    //Criar método para retornar o ponto de patrulha mais próximo do inimigo
    //Criar método para retornar o ponto de patrulha aleatório, mas que seja diferente do ponto atual do inimigo

}

