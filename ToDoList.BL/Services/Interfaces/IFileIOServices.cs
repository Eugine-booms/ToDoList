namespace ToDoList.BL.Services
{
    public interface IFileIOServices<T>
    {
        T LoadData();
        void SaveData(T data);
    }
}