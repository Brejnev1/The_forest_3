using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI openDoor;

    [SerializeField] private KeyCode keyG;

    [SerializeField] private string openAnimation = "DoorOpen";
    [SerializeField] private string closeAnimation = "DoorClose";
    [SerializeField] private Animator animDoor;
    private int openHash;
    private int closeHash;

    private void Awake()
    {
        openDoor.enabled = false;

        animDoor = GetComponent<Animator>();
        openHash = Animator.StringToHash(openAnimation);
        closeHash = Animator.StringToHash(closeAnimation);
    }

    private void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Player")
        {
            openDoor.enabled = true;

            if (Input.GetKey(keyG))
            {
                openDoor.enabled = false;
                animDoor.SetTrigger(openHash);
                Destroy(this.gameObject);
            }
        }
    }
}
