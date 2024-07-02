using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    [SerializeField] public VideoClip videoClip;
    [SerializeField] public RenderTexture targetRenderTexture;
    VideoPlayer videoPlayer;
    public VideoAudioOutputMode audioOutputMode;
    AudioSource audioSource;
    Vector3 originalScale;
    [SerializeField] private bool startOnInitiate = false;
    public UnityEngine.Events.UnityEvent OnLoopReached;
    // Start is called before the first frame update
    void Start()
    {
        if (OnLoopReached == null)
            OnLoopReached = new UnityEngine.Events.UnityEvent();
        originalScale = transform.localScale;
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        videoPlayer.audioOutputMode = audioOutputMode;
        if (audioOutputMode != VideoAudioOutputMode.None)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            videoPlayer.SetTargetAudioSource(0, audioSource);
        }

        
        videoPlayer.isLooping = false;
        videoPlayer.aspectRatio = VideoAspectRatio.FitInside;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = targetRenderTexture;
        videoPlayer.clip = videoClip;
        videoPlayer.playOnAwake = false;
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Pause();

    }

    public void LoadAndPlay()
    {
        //videoPlayer.clip = videoClip;
        //videoPlayer.playOnAwake = true;

        //if (videoPlayer.isPlaying)
        //{
        //    videoPlayer.Pause();
        //}
        //else
        //{
        //    videoPlayer.frame = 0;
        //    videoPlayer.Play();
        //}
        videoPlayer.frame = 0;
        ResumePlay();
    }
    public void StopPlay()
    {
        videoPlayer.Pause();
        audioSource.Pause();
    }
    public void ResumePlay()
    {
        videoPlayer.Play();
        if (audioSource != null)
            audioSource.Play();
    }
    public void SwitchPlay()
    {
        if (videoPlayer.isPlaying)
            StopPlay();
        else
            LoadAndPlay();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        OnLoopReached.Invoke();
    }

    int count = 0;
    private void Update()
    {
        if (count % 30 == 0)
            Debug.Log($"Video is playing: {videoPlayer.isPlaying}");
        count++;
    }


}
