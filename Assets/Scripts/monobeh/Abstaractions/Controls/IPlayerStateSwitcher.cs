public interface IPlayerStateSwitcher
{    void SwitchPlayerState<T>() where T : BaseGameState;
}
