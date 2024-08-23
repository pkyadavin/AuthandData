using Auth.Model.Entity;

namespace Auth.Service
{
    public interface IBomService
    {
        dynamic GetBOM(List<Item> items, int id);
    }
}