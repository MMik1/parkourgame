using UnityEngine;
using UnityEngine.SceneManagement;


public class winninggame : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
