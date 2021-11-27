using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
  [SerializeField] float restartDelay = 0.5f;
  [SerializeField] ParticleSystem finishEffect;


  IEnumerator coroutine;

  void ReloadScene()
  {
    SceneManager.LoadScene(0);
  }

  IEnumerator RestartDelayed(float delay)
  {
    yield return new WaitForSeconds(delay);
    ReloadScene();
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      finishEffect.Play();
      GetComponent<AudioSource>().Play();
      coroutine = RestartDelayed(restartDelay);
      StartCoroutine(coroutine);

    }
  }
}
