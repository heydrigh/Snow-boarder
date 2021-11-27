using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
  [SerializeField] float restartDelay = 0.5f;
  [SerializeField] ParticleSystem crashEffect;
  [SerializeField] AudioClip crashSFX;
  IEnumerator coroutine;

  bool hasCrashed = false;

  void OnTriggerEnter2D(Collider2D other)
  {
    void ReloadScene()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator RestartDelayed(float delay)
    {
      yield return new WaitForSeconds(delay);
      ReloadScene();
    }

    if (other.tag == "Ground" && !hasCrashed)
    {
      hasCrashed = true;
      FindObjectOfType<PlayerController>().DisableControls();
      crashEffect.Play();
      GetComponent<AudioSource>().PlayOneShot(crashSFX);
      coroutine = RestartDelayed(restartDelay);
      StartCoroutine(coroutine);
    }

  }
}
