using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StackScript : MonoBehaviour
{
    private int _giveScore = 1;
    private Player _player;
    private PlayerController _playerController;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _playerController = _player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Dashes")
        {
            _player.UpdateScore(_giveScore);
            other.gameObject.tag = "Normal";
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.AddComponent<StackScript>();
            _playerController.PushDashes(other.gameObject);
            Destroy(this);
        }
    }

}
