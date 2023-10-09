namespace Assets.CodeBase.Architecture.GameStates
{
    public interface IState: IExitableState
    {
        void Enter();
    }
}