[System.Serializable]
public class DataManagerBSaveHelper
{
    public int   paramA;
    public float paramB;

    public void Save(DataManagerB target)
    {
        paramA = target.paramA;
        paramB = target.paramB;
    }

    public void Load(DataManagerB target)
    {
        target.paramA = paramA;
        target.paramB = paramB;
    }
}