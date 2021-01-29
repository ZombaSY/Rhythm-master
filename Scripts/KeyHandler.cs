using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyHandler : MonoBehaviour
{
    public GameObject gameManager;

    private static GameManager gameManager_comp;

    private static KeyCode[] key_4 = new KeyCode[] { KeyCode.S, KeyCode.D, KeyCode.L, KeyCode.Semicolon };
    private static KeyCode[] key_6 = new KeyCode[] { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.L, KeyCode.Semicolon, KeyCode.Quote };
    private static KeyCode[] key_8 = new KeyCode[] { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.L, KeyCode.Semicolon, KeyCode.Quote, KeyCode.LeftShift, KeyCode.RightShift };

    // Start is called before the first frame update
    void Start()
    {
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

    public void SetKeys_8(char[] keys)
    {
        //this.key_6 = keys;
    }

    public KeyCode[] GetKeys_4()
    {
        return key_4;
    }
    public KeyCode[] GetKeys_6()
    {
        return key_6;
    }

    public KeyCode[] GetKeys_8()
    {
        return key_8;
    }
}
