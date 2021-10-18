using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField]
    GameObject[] pieces;
    GameController gameController;
    [HideInInspector]
    public bool cutted;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void Cut()
    {
        foreach (GameObject piece in pieces)
        {
            piece.SetActive(true);
            piece.transform.SetParent(null);

            Rigidbody pieceRb = piece.GetComponent<Rigidbody>();
            Vector3 direction = transform.position - piece.transform.position;

            pieceRb.AddForce(-direction * 800f);
        }

        cutted = true;
        gameController.ScoreUp();
        gameObject.SetActive(false);
    }

    public void ResetBlock()
    {
        cutted = false;

        foreach (GameObject piece in pieces)
        {
            piece.GetComponent<Piece>().ResetPosition();
        }
    }
}
