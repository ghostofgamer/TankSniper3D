using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI.Buttons
{
    public class RestartButton : AbstractButton
    {
        public override void OnClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}