using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private readonly GameStateMachine _stateMachine;

    [Inject]
    public BootstrapState(GameStateMachine stateMachine) => 
      _stateMachine = stateMachine;

    public void Enter()
    {
      _stateMachine.Enter<LoadProgressState>();
    }

    public void Exit()
    {
    }
  }
}