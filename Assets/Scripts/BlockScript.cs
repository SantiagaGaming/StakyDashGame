using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private int _takeScore = -1;
    private bool _isWall = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _isWall)
        {
          
            if (other.gameObject.GetComponent<Player>().GetScore()>0)
            {
                _isWall = false;
                Destroy(gameObject.GetComponent<BoxCollider>());
            other.gameObject.GetComponent<Player>().UpdateScore(_takeScore);
                other.GetComponent<PlayerController>().PopDashes();
            transform.GetChild(0).gameObject.SetActive(true);
            }

        }
    }
}
