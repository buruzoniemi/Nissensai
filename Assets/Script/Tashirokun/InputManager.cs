using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�g����ނ̃{�^����p�ӂ��Ă�
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
    //����Pad�̃{�^����������Ă��邩�ǂ����𔻒肷��ϐ�����
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
    /// Key�̃`�F�b�N�����Ă���Ƃ�
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
    /// ���͂��ꂽ�L�[�̃`�F�b�N
    /// </summary>
    /// <param name="key">���͂��ꂽ�L�[���󂯎��</param>
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
                // ���X�e�B�b�N��x��y�̒l���擾
                float x = leftStick.x;
                float y = leftStick.y;

                // �X�e�B�b�N�̌X���Ɋ�Â��ĕ����𔻒f����
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    // x�̐�Βl��y�̐�Βl���傫���ꍇ�A���������ɌX���Ă���Ɣ��f
                    return x > 0; // x�����̏ꍇ�͉E�����A���̏ꍇ�͍�����
                }
                else
                {
                    // y�̐�Βl��x�̐�Βl���傫���ꍇ�A���������ɌX���Ă���Ɣ��f
                    return y > 0; // y�����̏ꍇ�͏�����A���̏ꍇ�͉�����
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