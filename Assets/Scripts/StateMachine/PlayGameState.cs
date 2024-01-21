using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGameState : IGameState
{
    private StateMachine _stateMachine;
    private const string _sceneName = "GamePlayScene";
    private TileFactory _tileFactory;
    private ElementOfFieldFactory _elementOfFieldFactory;
    private Field _gameField;
    
    public StateMachine StateMachine => throw new System.NotImplementedException();
    public PlayGameState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public async void Enter()
    {
        var playGameSceneOperation = Addressables.LoadSceneAsync(_sceneName, activateOnLoad: true);
        if (SceneManager.GetActiveScene().name == "LoadingScene" && SceneManager.GetActiveScene().isLoaded)
        {
            while (playGameSceneOperation.PercentComplete <= 0.9f)
            {
                LoadingStateText.SetLoadingText(this, _sceneName);
                LoadingProgressImage.SetFillOfImage(this, playGameSceneOperation.PercentComplete);
            }
        }

        AsyncOperationHandle<Sprite> fieldOpHandle = Addressables.LoadAssetAsync<Sprite>("FieldImage");
        await fieldOpHandle.Task;
        GameObject field = GameObject.Find("Field Image");
        field.GetComponent<Image>().sprite = fieldOpHandle.Result;
        AsyncOperationHandle<GameObject> tileOpHandle = Addressables.LoadAssetAsync<GameObject>("Tile");
        await tileOpHandle.Task;
        _tileFactory = new TileFactory(tileOpHandle.Result, field);
        AsyncOperationHandle<GameObject> sandOpHandle = Addressables.LoadAssetAsync<GameObject>("SandTokenImage");
        AsyncOperationHandle<GameObject> spiceOpHandle = Addressables.LoadAssetAsync<GameObject>("SpiceTokenImage");
        AsyncOperationHandle<GameObject> wormOpHandle = Addressables.LoadAssetAsync<GameObject>("WormTokenImage");
        AsyncOperationHandle<GameObject> soldersOpHandle = Addressables.LoadAssetAsync<GameObject>("SoldersTokenImage");
        AsyncOperationHandle<GameObject> waterOpHandle = Addressables.LoadAssetAsync<GameObject>("WaterTokenImage");
        AsyncOperationHandle<GameObject> baitOpHandle = Addressables.LoadAssetAsync<GameObject>("BaitTokenImage");
        await sandOpHandle.Task;
        await spiceOpHandle.Task;
        await wormOpHandle.Task;
        await soldersOpHandle.Task;
        await waterOpHandle.Task;
        await baitOpHandle.Task;
        _elementOfFieldFactory = new ElementOfFieldFactory(sandOpHandle.Result, spiceOpHandle.Result, wormOpHandle.Result, soldersOpHandle.Result, waterOpHandle.Result, baitOpHandle.Result);
        _gameField = new Field(_tileFactory, _elementOfFieldFactory);
        _gameField.GenerateField();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

}