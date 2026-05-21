using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private Light _light;
    private float _originalIntensity;
    [SerializeField] private float _intensityDecreaseRate = 0.5f;
    void Start()
    {
        _light = GetComponent<Light>();
        _originalIntensity = _light.intensity;
    }


    void Update()
    {
        if (_light.intensity <= 0)
            return;
        _light.intensity -= Time.deltaTime * _intensityDecreaseRate;
    }
}