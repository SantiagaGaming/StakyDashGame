using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDetectionDown : MonoBehaviour
{
    [SerializeField] private float _z;
    [SerializeField] private float _x;
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        transform.position = new Vector3(_playerController.transform.position.x + _x, transform.position.y, _playerController.transform.position.z + _z);
        Ray ray = new Ray(this.transform.position, -this.transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {

            if (hit.collider.tag == "Water")
            {
                _playerController.canMoveDown = false;


            }
            if (hit.collider.tag == "Ground")
            {
                _playerController.canMoveDown = true;
            }


        }
    }
}
