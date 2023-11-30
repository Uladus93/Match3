using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Material _backgroundMaterial;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _canvas;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("BaseScene");
        TileFactory tileFactory = new TileFactory(_tilePrefab);
        Field field = new Field(5, 7, _canvas, tileFactory);
    }
}