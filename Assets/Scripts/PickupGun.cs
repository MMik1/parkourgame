
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickupgun : MonoBehaviour
{
    public AudioClip pickupsound;
    public GameObject PickUpText;
    public GameObject GrappelGunOnPlayer;
    void Start()
    {
        GrappelGunOnPlayer.SetActive(false);
        PickUpText.SetActive(false);   
    }
    private void OnTriggerStay(Collider other)
{
    if(other.gameObject.tag == "Player")
    {
        PickUpText.SetActive(true);

        if(Input.GetKey(KeyCode.E))
        {
            this.gameObject.SetActive(false);

          AudioSource.PlayClipAtPoint(pickupsound, transform.position);

            GrappelGunOnPlayer.SetActive(true);

            PickUpText.SetActive(false);
        }
    }
}
    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
}
