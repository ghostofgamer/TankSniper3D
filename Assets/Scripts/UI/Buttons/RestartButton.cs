using UnityEngine.SceneManagement;

namespace Tank3D
{
    public class RestartButton : AbstractButton
    {
        public override void OnClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}