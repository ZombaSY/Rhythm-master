using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject DeadLine;
    public GameObject gameManager;
    public GameObject noteHandler;

    private static GameManager gameManager_comp;
    private static NoteHandler noteHandler_comp;

    private Vector3 note_vector = new Vector3(0, -0.005f, 0);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Frame_Bottom")
        {
            Destroy(gameObject, 0f);
        }
    }

    void Start()
    {
        gameManager_comp = gameManager.GetComponent<GameManager>();
        noteHandler_comp = noteHandler.GetComponent<NoteHandler>();
    }


    void Update()
    {
        gameObject.transform.Translate(note_vector * noteHandler_comp.GetNoteSpeed());
    }
}
