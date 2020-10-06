using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionDetection : MonoBehaviour
{
    [SerializeField] Door door;
    [SerializeField] Animator screenFadeAnimator;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PuzzleArea")
        {
            door.Close();
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3.0f);
        screenFadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
