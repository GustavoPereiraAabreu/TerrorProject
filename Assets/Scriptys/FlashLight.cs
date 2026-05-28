using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public enum ActiveState
{
    OFF, ON
}

public class FlashLight : MonoBehaviour
{
    private ActiveState _activeState = ActiveState.ON;
    private Light _light;
    private float _originalIntensity;
    [SerializeField] private float _intensityDecreaseRate = 0.5f;
    [SerializeField] private float _betteryDuration = 10;
    private bool _lostingPower;//Boleana que habilita a perda de intensidade da luz, para que a lanterna não perca intensidade antes do tempo determinado
    private bool _isFullBattery = true;
    private float _batteryTimer; //Timer para controlar o tempo de duração da bateria

    void Start()
    {
        _light = GetComponent<Light>();
        _originalIntensity = _light.intensity;
        GameController.Instance.OnUseBattery.AddListener(Recharge);
        GameController.Instance.OnUseFlashlight.AddListener(TurnFlashlight);
        _batteryTimer = _betteryDuration;
    }

    private void Recharge()
    {
        _light.intensity = _originalIntensity;
        _batteryTimer = _betteryDuration;
        _lostingPower = false;
    }


    void Update()
    {
        switch (_activeState) 
        {   
            case ActiveState.OFF:
                //Se a lanterna estiver desligada, não precisa executar nada
                //Os sistemas relacionandos a bateria ficam "Suspensos"
                break;
            case ActiveState.ON:
                if (_lostingPower) //Aqui é caso a lanterna esteja perdendo a luz já
                {
                    if (_light.intensity <= 0) //Nullcheck para evitar que a intensidade da luz fique negativa
                        return;
                    _light.intensity -= Time.deltaTime * _intensityDecreaseRate;
                }
                else //Aqui é caso a lanterna esteja com bateria ainda boa
                {
                    _batteryTimer -= Time.deltaTime; //Diminui o timer da bateria a cada frame
                    if (_batteryTimer <= 0)//Se o timer chegar acabar
                    {
                        _lostingPower = true; //Começa a perder intensidade
                    }
                }
                     break;
            default:
                 break;
        }

    
    }

    public void TurnFlashlight()
    {
        if (_activeState.Equals(ActiveState.ON))
        {
            SetState(ActiveState.OFF);
        }
        else 
        {
            SetState(ActiveState.ON);
        }
        
    }

    public void SetState(ActiveState newState)
    {
        switch (newState) 
        {   
            case ActiveState.OFF:
                _light.enabled = false;
                break;
            case ActiveState.ON: 
                _light.enabled = true;
                break;
            default:
                 break;
        }
        _activeState = newState;
    }

}