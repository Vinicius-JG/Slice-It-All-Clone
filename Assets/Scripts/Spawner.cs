using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    Transform[] platforms;
    Transform lastPlatform;
    [SerializeField]
    Transform player;
    [SerializeField]
    float offset;

    private void Start()
    {
        lastPlatform = platforms[platforms.Length - 1];
    }

    private void Update()
    {
        foreach (Transform platform in platforms)
        {
            if (platform.position.x < player.position.x - 15)
            {
                platform.GetComponent<Platform>().ResetPlatform();
                platform.position = new Vector3(lastPlatform.position.x + offset, lastPlatform.position.y, lastPlatform.position.z);
                lastPlatform = platform;
            }
        }
    }
}
