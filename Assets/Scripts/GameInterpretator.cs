using UnityEngine;
using UnityEngine.InputSystem;

public class GameInterpretator : MonoBehaviour
{
    private Controller _controller;
    private Field _gameField;
    private sbyte _pause;

    private void Awake()
    {
        _controller = new Controller();
        _pause = 0;

    }

    private void OnEnable()
    {
        _controller = new Controller();
        if (_gameField != null)
        {
            SetActionOnCancelClick();
        }
        _controller.Enable();
    }

    private void OnDisable()
    {
        _controller.Disable();
    }

    public void SetField(Field field)
    {
        _gameField = field;
        SetActionOnCancelClick();
    }

    public void SetActionOnCancelClick()
    {
        _controller.PlayMode.TokenInterpretator.canceled += _gameField.MatchManager.GenerateMatchCanceled;
    }

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed && _pause == 0)
        {
            _gameField.MatchManager.GenerateMatchPerformed();
        }
    }

    public void ChangePauseValue(sbyte value)
    {
         _pause += value;
    }
}