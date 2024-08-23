using Auth.Model.Entity;

namespace Auth.Service
{
    public class BomService : IBomService
    {
        public dynamic GetBOM(List<Item> items, int id)
        {
            return GetItems(items, new ItemBom(), "", id);
        }

        private dynamic GetItems(List<Item> items, ItemBom BomObject, string name, int id)
        {
            var childList = items.Where(i => i.ParentCategoryId == id).ToList();
            var item = items.Where(i => i.CategoryId == id).FirstOrDefault();
            BomObject.Name = item.Name;
            BomObject.CategoryId = item.CategoryId;
            BomObject.ParentCategoryId = item.ParentCategoryId;
            BomObject.SubItems = GetBom(childList);
            var childCount = childList.Count;
            foreach (var c in BomObject.SubItems)
            {
                childList = items.Where(j => j.ParentCategoryId == c.CategoryId).ToList();
                childCount = childList.Count;
                if (childCount > 0)
                {
                    GetItems(items, c, c.Name, c.CategoryId);
                }
            }
            return BomObject;
        }

        private List<ItemBom> GetBom(List<Item> items)
        {
            List<ItemBom> itemBoms = new List<ItemBom>();
            foreach (var i in items)
            {
                var b = new ItemBom
                {
                    CategoryId = i.CategoryId,
                    Name = i.Name,
                    ParentCategoryId = i.ParentCategoryId,
                    SubItems = new List<ItemBom>()
                };
                itemBoms.Add(b);
            }
            return itemBoms;
        }
    }
}
