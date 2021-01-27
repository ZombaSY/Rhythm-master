using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyHandler : MonoBehaviour
{
    public GameObject gameManager;

    private GameManager gameManager_comp;

    private Queue<KeyCode> note_queue = new Queue<KeyCode>();

    public KeyCode[] key_4 = new KeyCode[] { KeyCode.S, KeyCode.D, KeyCode.L, KeyCode.Semicolon };
    public KeyCode[] key_6 = new KeyCode[] { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.L, KeyCode.Semicolon, KeyCode.Quote };
    public KeyCode[] key_8 = new KeyCode[] { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.L, KeyCode.Semicolon, KeyCode.Quote, KeyCode.LeftShift, KeyCode.RightShift };

    // Start is called before the first frame update
    void Start()
    {
        this.note_queue.Enqueue(KeyCode.A);
        this.note_queue.Enqueue(KeyCode.S);
        this.note_queue.Enqueue(KeyCode.D);
        this.note_queue.Enqueue(KeyCode.L);
        this.note_queue.Enqueue(KeyCode.Semicolon);
        this.note_queue.Enqueue(KeyCode.Quote);

        gameManager_comp = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetKeys_4(char[] keys)
    {

    }
    public void SetKeys_6(char[] keys)
    {
        //this.key_6 = keys;
    }

    public void AddNoteQueue(KeyCode key_code)
    {
        this.note_queue.Enqueue(key_code);
    }
    public void InstantiateNote()
    {
        /*
        1. 노트 queue 확인
        2. queue 안에 있는 keycode 확인
        3. keycode 위치로 instantiate
        */

        for (int i = 0; i < this.note_queue.Count; i++)
        {
            KeyCode key_code = this.note_queue.Dequeue();

            if (key_code == this.key_6[0]) Instantiate(gameManager_comp.Note_Prefab_1, new Vector3(-1.5f, 5f, 0f), Quaternion.identity);
            if (key_code == this.key_6[1]) Instantiate(gameManager_comp.Note_Prefab_2, new Vector3(-0.9f, 5f, 0f), Quaternion.identity);
            if (key_code == this.key_6[2]) Instantiate(gameManager_comp.Note_Prefab_1, new Vector3(-0.3f, 5f, 0f), Quaternion.identity);
            if (key_code == this.key_6[3]) Instantiate(gameManager_comp.Note_Prefab_1, new Vector3(0.3f, 5f, 0f), Quaternion.identity);
            if (key_code == this.key_6[4]) Instantiate(gameManager_comp.Note_Prefab_2, new Vector3(0.9f, 5f, 0f), Quaternion.identity);
            if (key_code == this.key_6[5]) Instantiate(gameManager_comp.Note_Prefab_1, new Vector3(1.5f, 5f, 0f), Quaternion.identity);

        }
    }

    public bool IsNoteQueueClear() {
        if (this.note_queue.Count == 0) return true;
        else return false;
    }

    public int GetNotQueueCount() { return this.note_queue.Count;  }
}
