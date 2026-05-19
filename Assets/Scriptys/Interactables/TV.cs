using UnityEngine;
using UnityEngine.Video;

public class TV : MonoBehaviour, IInteractable
{
    private VideoPlayer _videoPlayer;
    private GameObject _videoContainer;

    public void Interact()
    {
        if (_videoContainer.isPlaying)
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
       _videoPlayer = GetComponent<VideoPlayer>();
       _videoContainer = _videoPlayer.gameObject;

    }

}
