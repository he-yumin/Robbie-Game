using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    static AudioManager current;

    [Header("Environment Audio")]
    public AudioClip ambientClip;
    public AudioClip musicClip;

    [Header("FX Audio")]
    public AudioClip deathFXClip;
    public AudioClip orbFXClip;
    public AudioClip doorFXClip;
    public AudioClip startLevelClip;
    public AudioClip winClip;

    [Header("Robbie Audio")]
    public AudioClip[] walkStepClips;
    public AudioClip[] crouchStepClips;
    public AudioClip jumpClip;
    public AudioClip deathClip;

    public AudioClip jumpVoiceClip;
    public AudioClip deathVoiceClip;
    public AudioClip orbVoiceClip;


    AudioSource ambienteSource;
    AudioSource musicSource;
    AudioSource playerSource;
    AudioSource voiceSource;
    AudioSource fxSource;

    public AudioMixerGroup ambientGroup, musicGroup, FXGroup, playerGroup, voiceGroup;

    private void Awake()
    {
        if (current != null)
        {
            Destroy(gameObject);
            return;
        }


        current = this;
        DontDestroyOnLoad(gameObject);
        ambienteSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        playerSource = gameObject.AddComponent<AudioSource>();
        voiceSource = gameObject.AddComponent<AudioSource>();
        fxSource = gameObject.AddComponent<AudioSource>();

        ambienteSource.outputAudioMixerGroup = ambientGroup;
        musicSource.outputAudioMixerGroup = musicGroup;
        fxSource.outputAudioMixerGroup = FXGroup;
        playerSource.outputAudioMixerGroup = playerGroup;
        voiceSource.outputAudioMixerGroup = voiceGroup;

        StartLevelAudio();
    }

    void StartLevelAudio()
    {
        //场景音效
        current.ambienteSource.clip = current.ambientClip;
        current.ambienteSource.loop = true;
        current.ambienteSource.Play();

        current.musicSource.clip = current.musicClip;
        current.musicSource.loop = true;
        current.musicSource.Play();

        current.fxSource.clip = current.startLevelClip;
        current.fxSource.Play();
    }

    //门打开的音效 Voz cuando la puerta está abierta
    public static void PlayDoorOpenAudio()
    {
        current.fxSource.clip = current.doorFXClip;
        current.fxSource.PlayDelayed(1f);
    }

    //走路音效 Sonido al caminar    
    public static void PlayFootstepAudio() {
        int index = Random.Range(0, current.walkStepClips.Length);

        current.playerSource.clip = current.walkStepClips[index];
        current.playerSource.Play();
    }
    //蹲下走路音效 Sonido al caminar en cuclillas
    public static void PlayCrouchFootstepAudio()
    {
        int index = Random.Range(0, current.crouchStepClips.Length);

        current.playerSource.clip = current.crouchStepClips[index];
        current.playerSource.Play();
    }
    //跳跃音效
    public static void PlayJumpAudio() {
        current.playerSource.clip = current.jumpClip;
        current.playerSource.Play();

        current.voiceSource.clip = current.jumpVoiceClip;
        current.voiceSource.Play();
    }
    //人物死亡音效
    public static void PlayDeathAudio()
    {
        current.playerSource.clip = current.deathClip;
        current.playerSource.Play();

        current.voiceSource.clip = current.deathVoiceClip;
        current.voiceSource.Play();

        current.fxSource.clip = current.deathFXClip;
        current.fxSource.Play();
    }
    //得到宝珠音效
    public static void PlayOrbAudio()
    {
        current.fxSource.clip = current.orbFXClip;
        current.fxSource.Play();

        current.voiceSource.clip = current.orbVoiceClip;
        current.voiceSource.Play();
    }


    public static void PlayerWinAudio()
    {
        current.fxSource.clip = current.winClip;
        current.fxSource.Play();
        current.playerSource.Stop();
    }

}
