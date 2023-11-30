using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
    private static EntryPoint _instance;
    [SerializeField] private Material _backgroundMaterial;
    public Match3SceneManager _sceneManager;
    [SerializeField] private GameObject _tilePrefab;

    private void Start()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = gameObject.GetComponent<EntryPoint>();
        DontDestroyOnLoad(gameObject);

        _sceneManager = new Match3SceneManager();
        SceneManager.LoadScene("BaseScene");
        _sceneManager.Initialize();

        for (int i = 0; i < _sceneManager.GameField.RowCount; i++)
        {
            for (int j = 0; j < _sceneManager.GameField.ColumnCount; j++)
            {
                GameObject tile = Instantiate(_tilePrefab, new Vector2(i, j), Quaternion.identity, gameObject.transform);
            }
        }
    }

    public static EntryPoint GetInstance()
    {
        return _instance;
    }
}