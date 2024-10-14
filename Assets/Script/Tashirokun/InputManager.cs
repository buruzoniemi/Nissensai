using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//使う種類のボタンを用意してね
public enum PadButton
{
    West,
    East,
    North,
    South,
    Left,
    Right,
    Up,
    Down,
    LeftTrigger,
    RightTrigger,
    LeftShoulder,
    RightShoulder,
    LeftStick
}

public enum KeyBoard
{
    WKey,
    AKey,
    SKey,
    DKey,
    UpArrow,
    DownArrow,
    LeftArrow,
    RightArrow,
    SpaceKey
}


public class InputManager : MonoBehaviour
{
    //このPadのボタンが押されているかどうかを判定する変数たち
    private static bool west;
    private static bool east;
    private static bool north;
    private static bool south;
    private static bool left;
    private static bool right;
    private static bool up;
    private static bool down;
    private static bool leftTrigger;
    private static bool rightTrigger;
    private static bool leftShoulder;
    private static bool rightShoulder;

    //Keyboard
    private static bool w;
    private static bool a;
    private static bool s;
    private static bool d;
    private static bool upArrow;
    private static bool downArrow;
    private static bool leftArrow;
    private static bool rightArrow;
    private static bool space;

    private static Vector2 leftStick;


    /// <summary>
    /// Keyのチェックをしているとこ
    /// </summary>
    void Update()
    {
       // west = Gamepad.current.buttonWest.wasPressedThisFrame;
       // east = Gamepad.current.buttonEast.wasPressedThisFrame;
       // north = Gamepad.current.buttonNorth.wasPressedThisFrame;
       // south = Gamepad.current.buttonSouth.wasPressedThisFrame;
       // left = Gamepad.current.dpad.left.wasPressedThisFrame;
       // right = Gamepad.current.dpad.right.wasPressedThisFrame;
       // up = Gamepad.current.dpad.up.wasPressedThisFrame;
       // down = Gamepad.current.dpad.down.wasPressedThisFrame;
       // leftTrigger = Gamepad.current.leftTrigger.wasPressedThisFrame;
       // rightTrigger = Gamepad.current.rightTrigger.wasPressedThisFrame;
       // leftShoulder = Gamepad.current.leftShoulder.wasPressedThisFrame;
       // rightShoulder = Gamepad.current.rightShoulder.wasPressedThisFrame;
       // leftStick = Gamepad.current.leftStick.ReadValue();

        w = Keyboard.current.wKey.isPressed ? true : false; ;
        a = Keyboard.current.aKey.isPressed ? true : false;;
        s = Keyboard.current.sKey.isPressed ? true : false;;
        d = Keyboard.current.dKey.isPressed ? true : false; ;
        upArrow = Keyboard.current.upArrowKey.isPressed ? true : false; ;
        downArrow = Keyboard.current.downArrowKey.isPressed ? true : false;
        leftArrow = Keyboard.current.leftArrowKey.isPressed ? true : false;
        rightArrow = Keyboard.current.rightArrowKey.isPressed ? true : false;
        space = Keyboard.current.spaceKey.isPressed ? true : false;
    }

    /// <summary>
    /// 入力されたキーのチェック
    /// </summary>
    /// <param name="key">入力されたキーを受け取る</param>
    /// <returns></returns>
    public static bool GetKeyPad(PadButton pad)
    {
        switch (pad)
        {
            case PadButton.West:
                return west;
            case PadButton.East:
                return east;
            case PadButton.South:
                return south;
            case PadButton.North:
                return north;
            case PadButton.Left:
                return left;
            case PadButton.Right:
                return right;
            case PadButton.Up:
                return up;
            case PadButton.Down:
                return down;
            case PadButton.LeftTrigger:
                return leftTrigger;
            case PadButton.RightTrigger:
                return rightTrigger;
            case PadButton.LeftShoulder:
                return leftShoulder;
            case PadButton.RightShoulder:
                return rightShoulder;
            case PadButton.LeftStick:
                // 左スティックのxとyの値を取得
                float x = leftStick.x;
                float y = leftStick.y;

                // スティックの傾きに基づいて方向を判断する
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    // xの絶対値がyの絶対値より大きい場合、水平方向に傾いていると判断
                    return x > 0; // xが正の場合は右方向、負の場合は左方向
                }
                else
                {
                    // yの絶対値がxの絶対値より大きい場合、垂直方向に傾いていると判断
                    return y > 0; // yが正の場合は上方向、負の場合は下方向
                }
        }
        return false;
    }

    public static bool GetKey(KeyBoard Key)
    {
        switch (Key)
        {
            case KeyBoard.WKey:
                return w ? true : false;
            case KeyBoard.AKey:
                return a ? true : false;
            case KeyBoard.SKey:
                return s ? true : false;
            case KeyBoard.DKey:
                return d ? true : false;
            case KeyBoard.UpArrow:
                return upArrow ? true : false;
            case KeyBoard.DownArrow:
                return downArrow ? true : false;
            case KeyBoard.LeftArrow:
                return leftArrow ? true : false;
            case KeyBoard.RightArrow:
                return rightArrow ? true : false; ;
            case KeyBoard.SpaceKey:
                return space ? true : false;
        }
        return false;
    }
}