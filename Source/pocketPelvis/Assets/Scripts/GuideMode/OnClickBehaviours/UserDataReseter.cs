public class UserDataReseter : AbstractOnClickButtonBehaviour
{
  protected override void OnClickButton()
    {
        saveDataManager.ResetSaveData();
    }
}
