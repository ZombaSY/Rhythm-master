using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private const int FRAME_RATE = 144;

    public GameObject keyHandler;
    public GameObject noteHandler;
    public GameObject Note_Prefab_1;
    public GameObject Note_Prefab_2;

    private static KeyHandler keyHandler_comp;
    private static NoteHandler noteHandler_comp;

    private int CURRENT_KEY_MODE = 6;
    private int note_frame = 6; // maximum inputs on floating note.
    private int note_frame_begin;

    private bool is_getting_inputs = false;

    void Start()
    {
        keyHandler_comp = keyHandler.GetComponent<KeyHandler>();
        noteHandler_comp = noteHandler.GetComponent<NoteHandler>();

        Application.targetFrameRate = FRAME_RATE;
    }

    void Update()
    {

        ProcessKeyEvent(CURRENT_KEY_MODE);

        if (!is_getting_inputs)
        {
            // Stick to frame untill instantiate all notes
            do
            {
                noteHandler_comp.InstantiateNote(this.CURRENT_KEY_MODE);
            } while (!noteHandler_comp.IsNoteQueueClear());
        }
    }

    private void ProcessKeyEvent(int key_mode)
    {
        if (!is_getting_inputs) note_frame_begin = Time.frameCount; // mark the input beginning frame.

        if (Input.anyKeyDown)
        {
            is_getting_inputs = true;

            switch (key_mode)
            {
                case 4:
                    ProcessNoteKey(keyHandler_comp.GetKeys_4());
                    break;

                case 6:
                    ProcessNoteKey(keyHandler_comp.GetKeys_6());
                    break;

                case 8:
                    ProcessNoteKey(keyHandler_comp.GetKeys_8());
                    break;

                default:
                    break;
            }

            if (Input.GetKeyDown("1"))
            {
                noteHandler_comp.ReduceNoteSpeed();
                Debug.Log("Speed Down");
            }
            if (Input.GetKeyDown("2"))
            {
                noteHandler_comp.IncreaseNoteSpeed();
                Debug.Log("Speed Up");
            }

            if (Input.GetKeyDown("4"))
            {
                this.CURRENT_KEY_MODE = 4;
                OnChangeKeyMode();
                Debug.Log("To key 4");
            }

            if (Input.GetKeyDown("6"))
            {
                this.CURRENT_KEY_MODE = 6;
                OnChangeKeyMode();
                Debug.Log("To key 6");
            }

            if (Input.GetKeyDown("8"))
            {
                this.CURRENT_KEY_MODE = 8;
                OnChangeKeyMode();
                Debug.Log("To key 8");
            }

            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }
        else { is_getting_inputs = false;  }

        int current_frame = Time.frameCount;
        if ((current_frame - note_frame_begin) > note_frame) is_getting_inputs = false;

        void ProcessNoteKey(KeyCode[] key_codes)
        {
            foreach (KeyCode key_code in key_codes)
            {
                if (Input.GetKeyDown(key_code))
                {
                    Debug.Log(Time.frameCount + "  " + key_code.ToString());
                    noteHandler_comp.AddNoteQueue(key_code);
                }
            }
        }
    }

    public bool OnChangeKeyMode() { // on key mode changing

        return true;
    }
}