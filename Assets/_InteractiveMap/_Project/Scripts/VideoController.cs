using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer video;
    public Slider slider;

    //properties of the video player
    bool isDone;

    public bool IsPlaying {
        get { return video.isPlaying; }
    }

    public bool IsLooping
    {
        get { return video.isLooping; }
    }

    public bool IsPrepared
    {
        get { return video.isPrepared; }
    }

    public bool IsDone
    {
        get { return isDone; }
    }

    public double Time
    {
        get { return video.time; }
    }

    public ulong Duration
    {
        get { return (ulong)(video.frameCount / video.frameRate); }
    }

    public double NTime
    {
        get { return Time / Duration; }
    }

    private void OnEnable()
    {
        video.errorReceived += errorReceived;
        video.frameReady += frameReady;
        video.loopPointReached += loopPointReached;
        video.prepareCompleted += prepareCompleted;
        video.seekCompleted += seekCompleted;
        video.started += started;
    }

    private void OnDisable()
    {
        video.errorReceived -= errorReceived;
        video.frameReady -= frameReady;
        video.loopPointReached -= loopPointReached;
        video.prepareCompleted -= prepareCompleted;
        video.seekCompleted -= seekCompleted;
        video.started -= started;
    }

    private void errorReceived(VideoPlayer v, string msg)
    {
        Debug.Log("video player error" + msg);
    }

    private void frameReady(VideoPlayer v, long frame)
    {
        //cpu tax is heavy
    }

    private void loopPointReached(VideoPlayer v)
    {
        Debug.Log("video player loop point reached");
        isDone = true;
    }

    private void prepareCompleted(VideoPlayer v)
    {
        Debug.Log("video player finished preparing");
        isDone = false;
    }   
    
    private void seekCompleted(VideoPlayer v)
    {
        Debug.Log("video player finished seeking");
        isDone = false;
    }

    private void started(VideoPlayer v)
    {
        Debug.Log("video player started");
    }

    private void Update()
    {
        if (!IsPrepared) return;
        slider.value = (float)NTime;
    }

    public void LoadVideo(string msg)
    {
        string _temp = Application.dataPath + "/Videos/" + name; /*.mp4,.avi,.mov*/
        if (video.url == _temp) return;

        video.url = _temp;
        video.Prepare();

        Debug.Log("can set direct audio volume: " + video.canSetDirectAudioVolume);
        Debug.Log("can set playback speed: " + video.canSetPlaybackSpeed);
        Debug.Log("can set skip on drop: " + video.canSetSkipOnDrop);
        Debug.Log("can set time: " + video.canSetTime);
        Debug.Log("can step: " + video.canStep);
    }

    public void PlayVideo()
    {
        if (!IsPrepared) return;
        video.Play();
    }

    public void PauseVideo()
    {
        if (!IsPrepared) return;
        video.Pause();
    }

    public void RestartVideo()
    {
        if (!IsPlaying) return;
        PauseVideo();
        Seek(0);
    }

    public void LoopVideo(bool _toggle)
    {
        if (!IsPrepared) return;
        video.isLooping = _toggle;
    }

    public void Seek(float _nTime)
    {
        if (!video.canSetTime) return;
        if (!IsPrepared) return;
        _nTime = Mathf.Clamp(_nTime, 0, 1);
        video.time = _nTime * Duration;
    }

    public void IncrementPlaybackSpeed()
    {
        if (!video.canSetPlaybackSpeed) return;

        video.playbackSpeed += 1;
        video.playbackSpeed = Mathf.Clamp(video.playbackSpeed, 0, 10);
    }

    public void DecrementPlaybackSpeed()
    {
        if (!video.canSetPlaybackSpeed) return;

        video.playbackSpeed -= 1;
        video.playbackSpeed = Mathf.Clamp(video.playbackSpeed, 0, 10);
    }
}
