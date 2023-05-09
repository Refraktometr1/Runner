namespace CodeBase.Infrastructure.States
{
  public interface IState
  {
    void Enter();

    void Exit();
  }

  public interface IPayloadedState<TPayload> : IState
  {
    void Enter(TPayload payload);
  }
}