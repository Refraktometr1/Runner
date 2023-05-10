using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Infrastructure.States
{
  public class LoadLevelState : IPayloadedState<string>
  {
    private const string InitialPointTag = "InitialPoint";

    private readonly GameStateMachine _stateMachine;
    //private readonly SceneLoader _sceneLoader;
    //private readonly LoadingCurtain _loadingCurtain;
    private IGameFactory _gameFactory;
    private IPersistentProgressService _progressService;

    
   
    [Inject]
    public LoadLevelState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, IGameFactory gameFactory)
    {
      _stateMachine = gameStateMachine;
      _progressService = progressService;
      _gameFactory = gameFactory;
      
    }

    public void Enter(string sceneName)
    {
      //_loadingCurtain.Show();
      _gameFactory.Cleanup();
      var loadScene =  SceneManager.LoadSceneAsync(sceneName);
      loadScene.completed += OnLoaded;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
      //_loadingCurtain.Hide();
    }
    

    private void OnLoaded(AsyncOperation asyncOperation)
    {
      InitGameWorld();
      InformProgressReaders();

      _stateMachine.Enter<GameLoopState>();
    }

    private void InformProgressReaders()
    {
      foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
        progressReader.LoadProgress(_progressService.Progress);
    }

    private void InitGameWorld()
    {
      GameObject hero = _gameFactory.CreateHero(Vector3.zero);
      _gameFactory.CreateRoad(hero.transform);
      _gameFactory.CreateRoadsideEnvironment(hero.transform);
      InitHud(hero);

      CameraFollow(hero);
    }

    private void InitHud(GameObject hero)
    {
      GameObject hud = _gameFactory.CreateHud();
    }

    private void CameraFollow(GameObject hero) =>
      Camera.main.GetComponent<CameraFollow>().Follow(hero);
  }
}