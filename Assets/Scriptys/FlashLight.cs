using System.Collections;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
     private Light _light;
     private float _originalIntensity;
    [SerializeField] private float _intensityDecreaseRate = 0.5f;
    [SerializeField] private float _betteryDuration = 10;
    private bool _lostingPower = true;//Boleana que habilita a perda de intensidade da luz, para que a lanterna não perca intensidade antes do tempo determinado

    void Start()
    {
        _light = GetComponent<Light>();
        _originalIntensity = _light.intensity;
        GameController.Instance.OnUseBattery.AddListener(Recharge);
    }

    private void Recharge()
    {
        _light.intensity = _originalIntensity;
        _lostingPower = false;
        StopAllCoroutines();//Se o player usar uma pilha antes da antiga acabar, a contagem de tempo resetará
        StartCoroutine(FullBattery());//Inicia a contagem de tempo para a bateria acabar
    }

    IEnumerator FullBattery()
    {
        yield return new WaitForSeconds(_betteryDuration); //Tempo em que a lanterna não perde intensidade de luz
        _lostingPower = true;
    }

     void Update()
     {
        if (!_lostingPower) //Se não estiver perdendo energia, não faça nada
            return;
        if (_light.intensity <= 0) //Nullcheck para evitar que a intensidade da luz fique negativa
            return;
       _light.intensity -= Time.deltaTime * _intensityDecreaseRate;
     }
}