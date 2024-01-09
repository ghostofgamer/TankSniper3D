using UnityEngine;

public class GameOverScreen : EndGame
{
    [SerializeField] private PanelInfo _panelInfo;
    [SerializeField] private CameraMovement _reviewCamera;

    private AimInputButton _aimInputButton;

    public Player Player { get; private set; }

    public void Init(Player player, AimInputButton aimInputButton)
    {
        Player = player;
        _aimInputButton = aimInputButton;
    }

    private void OnEnable()
    {
        Player.Dying += OnEndGame;
    }

    private void OnDisable()
    {
        Player.Dying -= OnEndGame;
    }

    protected override void OnEndGame()
    {
        _aimInputButton.ReturnHide();
        _panelInfo.Close();
        base.OnEndGame();
        _reviewCamera.enabled = false;
    }
}