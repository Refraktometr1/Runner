using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
  public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
  {
    public LoadingCurtain CurtainPrefab;
    private GameStateMachine _stateMachine;

    [Inject]
    public void Construct(GameStateMachine stateMachine, BootstrapState bootstrapState,
      LoadProgressState loadProgressState, LoadLevelState loadLevelState, GameLoopState gameLoopState)
    {
      _stateMachine = stateMachine;
      _stateMachine.AddState(typeof(BootstrapState), bootstrapState);
      _stateMachine.AddState(typeof(LoadProgressState), loadProgressState);
      _stateMachine.AddState(typeof(LoadLevelState), loadLevelState);
      _stateMachine.AddState(typeof(GameLoopState), gameLoopState);
    }

    private void Awake()
    {
      _stateMachine.Enter<BootstrapState>();

      DontDestroyOnLoad(this);
    }
  }
}