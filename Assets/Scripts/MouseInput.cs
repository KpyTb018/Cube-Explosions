using UnityEngine;

[RequireComponent(typeof(Spawner))]

public class MouseInput : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Spawner _spawner;
    private Ray _ray;
    private RaycastHit _hit;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit))
                if (_hit.collider.TryGetComponent(out Cube cube))
                    _spawner.CreateCubes(cube);
        }
    }
}
