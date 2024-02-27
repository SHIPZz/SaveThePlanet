namespace CodeBase.Gameplay.Tutorial
{
    public class FinishedStep : AbstractTutorialStep
    {
        public override void OnStart()
        {
            ShowSkipButton();
            ShowMessage();
        }
    }
}