using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject DeadLine;
    public GameObject gameManager;

    private GameManager gameManager_comp;

    private Vector3 note_vector = new Vector3(0, -0.005f, 0);
    private float note_speed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Frame_Bottom")
        {
            Destroy(gameObject, 0f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager_comp = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        note_speed = gameManager_comp.GetNoteSpeed();
        Debug.Log(note_speed);

        gameObject.transform.Translate(note_vector * note_speed);
    }

    public void SetNoteSpeed(float note_speed)
    {
        this.note_speed = note_speed;
    }
}
