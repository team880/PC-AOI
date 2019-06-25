using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private string horizontalAxis = "Horizontal";
    [SerializeField] private string verticalAxis = "Vertical";
    public string shootButton = "Mouse1";
    public string slashButton = "Mouse2";
    public string dashButton = "Dash";
    public string slowDownButton = "Slowdown";

    //A vector representing the 2D direction in which
    internal Vector2 inputVector = new Vector2();
    public Vector2 cursorPosition;
    private Camera maincam;
    
    private void Start()
    {
        maincam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton(slowDownButton)) print("slow");
        inputVector = new Vector2(Input.GetAxisRaw(horizontalAxis), Input.GetAxisRaw(verticalAxis));
    }

    public Vector2 GetCursorPosition()
    {
        return maincam.ScreenToWorldPoint(Input.mousePosition);
    }
}
