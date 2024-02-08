using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using static UnityEngine.InputSystem.InputAction;

public class GameInterpretator : MonoBehaviour
{
    private Controller _controller;
    private Field _gameField;

    private void Awake()
    {
        _controller = new Controller();
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
        if (Mouse.current.leftButton.isPressed)
        {
            _gameField.MatchManager.GenerateMatchPerformed();
        }
    }
}