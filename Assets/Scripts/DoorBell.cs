using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBell : MonoBehaviour
{
    public string scene = "Level1";
    private Vector3 originalScale;
    public AudioSource bellAudioSource;
    public AudioSource hitAudioSource;

    private bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        if (string.IsNullOrEmpty(scene))
        {
            scene = "Level1";
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PressButton()
    {
        if (isTriggered) return;
        isTriggered = true;

        if (bellAudioSource != null)
        {
            bellAudioSource.Play();
        }

        transform.localScale = new Vector3(originalScale.x, originalScale.y / 2f, originalScale.z);

        // Sequence: ding-dong audio plays, then player is hit after 1.5s
        Invoke(nameof(PlayerHit), 1.5f);
    }

    public void ReleaseButton()
    {
        if (!isTriggered)
        {
            transform.localScale = originalScale;
        }
    }

    void PlayerHit()
    {
        if (hitAudioSource != null)
        {
            hitAudioSource.Play();
        }

        // Transition directly to Level1 without CameraFade
        // Note: CameraFade uses an ortho GL quad that renders pure white on HoloLens 2 / OpenXR
        Invoke(nameof(GoToLevel), 0.5f);
    }

    void GoToLevel()
    {
        if (!string.IsNullOrEmpty(scene))
        {
            SceneManager.LoadScene(scene);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Support direct physical hand/controller poke interaction
        if (!isTriggered && (other.CompareTag("GameController") || other.name.Contains("Hand") || other.name.Contains("Controller")))
        {
            PressButton();
        }
    }
}

