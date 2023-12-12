using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public GameObject Player; // Reference to the player prefab

    public float posX; // Define the range for X-axis spawn
    public float posZ; // Define the range for Z-axis spawn

    void Start()
    {
        // Generate a random position within the defined X and Z ranges
        Vector3 randomPosition = new Vector3(Random.Range(-posX, posX), 0f, Random.Range(-posZ, posZ));

        // Instantiate the player GameObject at the random position with no rotation
        PhotonNetwork.Instantiate(Player.name, randomPosition, Quaternion.identity);
    }
}
