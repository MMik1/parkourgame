using UnityEngine;
using UnityEngine.SceneManagement;


public class WinningObject : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
