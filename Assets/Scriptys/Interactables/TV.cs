using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TV : MonoBehaviour, IInteractable
{
    private VideoPlayer _videoPlayer;
    private GameObject _videoContainer;
    private Outline _outline;

    public void Interact()
    {
        if (_videoPlayer.isPlaying)
        {
            _videoPlayer.Stop();
            _videoContainer.SetActive(false);
        }
        else
        {
            _videoContainer.SetActive(true);
            _videoPlayer.Play();
        }

    }

    public void HideOutline()
    {
        if (_outline != null)
        {
            _outline.enabled = false;
        }
    }

    public void ShowOutline()
    {
        if (_outline != null)
        {
            _outline.enabled = true;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
       _videoPlayer = GetComponent<VideoPlayer>();
       _videoContainer = _videoPlayer.gameObject;
        _videoContainer = transform.GetChild(0).gameObject;

    }

}
