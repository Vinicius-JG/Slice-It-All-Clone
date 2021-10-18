using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    List<Transform> destructibles = new List<Transform>();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            destructibles.Add(transform.GetChild(i));
        }
    }

    public void ResetPlatform()
    {
        foreach (Transform destuctible in destructibles)
        {
            destuctible.gameObject.SetActive(true);
            if (destuctible.GetComponent<Destructible>().cutted)
            {
                destuctible.GetComponent<Destructible>().ResetBlock();
            }
        }
    }
}
