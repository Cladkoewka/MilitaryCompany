namespace Assets.CodeBase.Architecture.GameStates
{
    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}