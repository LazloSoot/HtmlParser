using HtmlParser.Data.Entities;

namespace HtmlParser.Bl.Interfaces
{
    public interface IDataController<ResultType> where ResultType : class
    {
        bool SaveData(ResultType data);
        ResultType ReadData();
    }
}
