using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(MouseInput))]

public class SelectedCube : MonoBehaviour
{
    private MouseInput _mouseInput;
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        _mouseInput = GetComponent<MouseInput>();
    }

    private void OnEnable()
    {
        _mouseInput.CubeSelected += TryDivide;
    }

    private void OnDisable()
    {
        _mouseInput.CubeSelected -= TryDivide;
    }

    private void TryDivide(Cube cube)
    {
        if (cube.TryDivide())
            _spawner.CreateCubes(cube);

        Destroy(cube.gameObject);
    }
}
