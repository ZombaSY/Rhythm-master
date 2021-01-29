using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHandler : MonoBehaviour
{
    public GameObject keyHandler;
    public GameObject gameManager;

    private static KeyHandler keyHandler_comp;
    private static GameManager gameManager_comp;

    private static Queue<KeyCode> note_queue = new Queue<KeyCode>();

    private static float note_speed = 10f;

    void Start()
    {
        keyHandler_comp = keyHandler.GetComponent<KeyHandler>();
        gameManager_comp = gameManager.GetComponent<GameManager>();

        note_queue.Enqueue(KeyCode.S);
        note_queue.Enqueue(KeyCode.D);

    }

    void Update()
    {
        
    }

    public void AddNoteQueue(KeyCode key_code)
    {
        note_queue.Enqueue(key_code);
    }

    public void InstantiateNote(int key_mode)
    {
        /*
        1. 노트 queue 확인
        2. queue 안에 있는 keycode 확인
        3. keycode 위치로 instantiate
        */

        switch (key_mode)
        {
            case 4: // 4k
                for (int i = 0; i < note_queue.Count; i++)
                {
                    KeyCode key_code = note_queue.Dequeue();

                    if (key_code == keyHandler_comp.GetKeys_4()[0]) Instantiate(gameManager_comp.Note_Prefab_1, new Vector3(-0.9f, 5f, 0f), Quaternion.identity);
                    if (key_code == keyHandler_comp.GetKeys_4()[1]) Instantiate(gameManager_comp.Note_Prefab_2, new Vector3(-0.3f, 5f, 0f), Quaternion.identity);
                    if (key_code == keyHandler_comp.GetKeys_4()[2]) Instantiate(gameManager_comp.Note_Prefab_1, new Vector3(0.3f, 5f, 0f), Quaternion.identity);
                    if (key_code == keyHandler_comp.GetKeys_4()[3]) Instantiate(gameManager_comp.Note_Prefab_1, new Vector3(0.9f, 5f, 0f), Quaternion.identity);
                }
                break;

            case 6: // 6k
                for (int i = 0; i < note_queue.Count; i++)
                {
                    KeyCode key_code = note_queue.Dequeue();

                    if (key_code == keyHandler_comp.GetKeys_6()[0]) Instantiate(gameManager_comp.Note_Prefab_1, new Vector3(-1.5f, 5f, 0f), Quaternion.identity);
                    if (key_code == keyHandler_comp.GetKeys_6()[1]) Instantiate(gameManager_comp.Note_Prefab_2, new Vector3(-0.9f, 5f, 0f), Quaternion.identity);
                    if (key_code == keyHandler_comp.GetKeys_6()[2]) Instantiate(gameManager_comp.Note_Prefab_1, new Vector3(-0.3f, 5f, 0f), Quaternion.identity);
                    if (key_code == keyHandler_comp.GetKeys_6()[3]) Instantiate(gameManager_comp.Note_Prefab_1, new Vector3(0.3f, 5f, 0f), Quaternion.identity);
                    if (key_code == keyHandler_comp.GetKeys_6()[4]) Instantiate(gameManager_comp.Note_Prefab_2, new Vector3(0.9f, 5f, 0f), Quaternion.identity);
                    if (key_code == keyHandler_comp.GetKeys_6()[5]) Instantiate(gameManager_comp.Note_Prefab_1, new Vector3(1.5f, 5f, 0f), Quaternion.identity);

                }
                break;

            case 8: // 8k
                for (int i = 0; i < note_queue.Count; i++)
                {
                    KeyCode key_code = note_queue.Dequeue();

                    if (key_code == keyHandler_comp.GetKeys_8()[0]) Instantiate(gameManager_comp.Note_Prefab_1, new Vector3(-1.5f, 5f, 0f), Quaternion.identity);
                    if (key_code == keyHandler_comp.GetKeys_8()[1]) Instantiate(gameManager_comp.Note_Prefab_2, new Vector3(-0.9f, 5f, 0f), Quaternion.identity);
                    if (key_code == keyHandler_comp.GetKeys_8()[2]) Instantiate(gameManager_comp.Note_Prefab_1, new Vector3(-0.3f, 5f, 0f), Quaternion.identity);
                    if (key_code == keyHandler_comp.GetKeys_8()[3]) Instantiate(gameManager_comp.Note_Prefab_1, new Vector3(0.3f, 5f, 0f), Quaternion.identity);
                    if (key_code == keyHandler_comp.GetKeys_8()[4]) Instantiate(gameManager_comp.Note_Prefab_2, new Vector3(0.9f, 5f, 0f), Quaternion.identity);
                    if (key_code == keyHandler_comp.GetKeys_8()[5]) Instantiate(gameManager_comp.Note_Prefab_1, new Vector3(1.5f, 5f, 0f), Quaternion.identity);

                }
                break;

            default:
                break;
        }
    }
    public bool IsNoteQueueClear()
    {
        if (note_queue.Count == 0) return true;
        else return false;
    }

    public int GetNotQueueCount() { return note_queue.Count; }

    public float GetNoteSpeed() { return note_speed; }
    public void ReduceNoteSpeed() { note_speed--; }
    public void IncreaseNoteSpeed() { note_speed++; }
}
