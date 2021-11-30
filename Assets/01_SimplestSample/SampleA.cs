using UnityEngine;
using XGUI;

public class SampleA : MonoBehaviour
{
    private readonly FlexWindow     _window    = new("SampleA"){ MinWidth = 300, MinHeight = 300 };
    private readonly FlexGUI<int>   _paramAGUI = new("ParaA",    0, 100);
    private readonly FlexGUI<float> _paramBGUI = new("ParaB", -100, 100);

    private void OnGUI()
    {
        _window.Show(() =>
        {
            var dataManagerA = DataManagerA.Instance;

            dataManagerA.dataSetA.paramA = _paramAGUI.Show(dataManagerA.dataSetA.paramA);
            dataManagerA.dataSetA.paramB = _paramBGUI.Show(dataManagerA.dataSetA.paramB);

            XGUILayout.HorizontalLayout(() =>
            {
                if (GUILayout.Button("Save"))
                {
                    JsonFileReadWriter.WriteJsonToStreamingAssets(dataManagerA.dataSetA, "SubDirName");
                }

                if (GUILayout.Button("Load"))
                {
                    var (data, success) = JsonFileReadWriter.ReadJsonFromStreamingAssets<DataSetA>("SubDirName");

                    if (success)
                    {
                        dataManagerA.dataSetA = data;
                    }
                }
            });
        });
    }
}