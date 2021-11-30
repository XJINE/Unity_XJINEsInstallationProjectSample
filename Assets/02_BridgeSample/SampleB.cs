using UnityEngine;
using XGUI;

public class SampleB : MonoBehaviour
{
    private readonly FlexWindow     _window    = new("SampleB"){ MinWidth = 300, MinHeight = 300 };
    private readonly FlexGUI<int>   _paramAGUI = new("ParaA",    0, 100);
    private readonly FlexGUI<float> _paramBGUI = new("ParaB", -100, 100);

    private void OnGUI()
    {
        _window.Show(() =>
        {
            var dataManagerB = DataManagerB.Instance;

            dataManagerB.paramA = _paramAGUI.Show(dataManagerB.paramA);
            dataManagerB.paramB = _paramBGUI.Show(dataManagerB.paramB);

            XGUILayout.HorizontalLayout(() =>
            {
                if (GUILayout.Button("Save"))
                {
                    var helper = new DataManagerBSaveHelper();
                        helper.Save(dataManagerB);

                   JsonFileReadWriter.WriteJsonToStreamingAssets(helper, "SubDirName");

                   // NOTE:
                   // Check 'instanceID' problem if you need.
                   // var jsonText = JsonUtility.ToJson(dataManagerB);
                   // Debug.Log(jsonText);
                }

                if (GUILayout.Button("Load"))
                {
                    var (data, success) = JsonFileReadWriter.ReadJsonFromStreamingAssets<DataManagerBSaveHelper>("SubDirName");

                    if (success)
                    {
                        data.Load(dataManagerB);
                    }
                }
            });
        });
    }
}