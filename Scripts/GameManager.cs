using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private const int FRAME_RATE = 144;

    private KeyHandler keyHandler_comp;

    public GameObject keyHandler;
    public GameObject Note_Prefab_1;
    public GameObject Note_Prefab_2;

    private int CURRENT_KEY_MODE = 2;   // 1: 4k, 2: 6k, 3: 8k

    public float note_speed = 10f;

    void Start()
    {
        keyHandler_comp = keyHandler.GetComponent<KeyHandler>();

        Application.targetFrameRate = FRAME_RATE;
    }

    void Update()
    {
        ProcessKeyEvent(CURRENT_KEY_MODE);

        if (Time.frameCount % 3 == 0)
        {
                // Stick to frame untill instantiate all notes
                do
            {
                keyHandler_comp.InstantiateNote();
            } while (!keyHandler_comp.IsNoteQueueClear());
        }
    }

    private void ProcessKeyEvent(int key_mode)
    {
        if (Input.anyKeyDown)
        {
            switch (key_mode)
            {
                case 1:
                    ProcessNoteKey(keyHandler_comp.key_4);
                    break;

                case 2:
                    ProcessNoteKey(keyHandler_comp.key_6);
                    break;

                case 3:
                    ProcessNoteKey(keyHandler_comp.key_8);
                    break;

                default:
                    break;
            }

            if (Input.GetKeyDown("1"))
            {
                this.note_speed--;
            }
            if (Input.GetKeyDown("2"))
            {
                this.note_speed++;
            }

        }

        void ProcessNoteKey(KeyCode[] key_codes) {
            foreach (KeyCode key_code in key_codes)
            {
                if (Input.GetKeyDown(key_code))
                {
                    keyHandler_comp.AddNoteQueue(key_code);
                }
            }
        }
    }
    public bool OnChangeKeyMode() { // on key mode changing

        return true;
    }
    public float GetNoteSpeed() { return this.note_speed; }
}