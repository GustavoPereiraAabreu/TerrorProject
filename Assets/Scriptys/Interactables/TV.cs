using UnityEngine;
using UnityEngine.Video;

public class TV : MonoBehaviour, IInteractable
{
    private VideoPlayer _VideoPlayer;
    private GameObject _VideoContainer;
    private Outline _Outline;

    public void HideOutline()
    {
        if (_Outline != null)
        {
            _Outline.enabled = false;
        }
    }
    public void ShowOutline()
    {
        if (_Outline != null)
        {
            _Outline.enabled = true;
        }
    }

    public void Interact()
    {
        if (_VideoPlayer.isPlaying)
        {
            _VideoPlayer.Stop();
        }
        else
        {
            _VideoContainer.SetActive(true);
            _VideoPlayer.Play();
        }
    }


    void Start()
    {
        _Outline = GetComponent<Outline>();
        _Outline.enabled = false;
        _VideoPlayer = GetComponent<VideoPlayer>();
        _VideoContainer = transform.GetChild(0).gameObject;
    }
}