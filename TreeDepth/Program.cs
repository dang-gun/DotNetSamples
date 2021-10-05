using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// https://medium.com/@vinjenks/depth-first-hierarchy-in-c-f9e0599abeeb
/// </summary>
namespace TreeDepth
{
    public class Item
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public Item(int id, int parentId, string name)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var items = new List<Item>() {
               new Item(1, 0, "Ralph"),
               new Item(2, 1, "Ron"),
               new Item(3, 2, "Vin"),
               new Item(4, 3, "Armando"),
               new Item(5, 3, "Alex"),
               new Item(6, 3, "Ana")
             };


            foreach (var item in items)
            {
                Console.WriteLine("id {0} , name {1}, GetParentsString {2}"
                    , item.Id
                    , item.Name
                    //, TopDown1(items, item));
                    , TopDown1(items, item));
            }
        }


        static string DownTop1(List<Item> all, Item current)
        {
            string path = "";


            Action<List<Item>, int> GetPath = null;

            GetPath = (List<Item> ps, int p) => {
                var parents = all.Where(x => x.Id == p);
                foreach (var parent in parents)
                {
                    path += $"/{ parent.Name}";
                    GetPath(ps, parent.ParentId);
                }
            };
            GetPath(all, current.ParentId);
            string[] split = path.Split(new char[] { '/' });
            Array.Reverse(split);

            return string.Join("/", split);
        }


        static string TopDown1(List<Item> all, Item current)
        {
            string path = "";


            Action<List<Item>, int> GetPath = null;
            GetPath = (List<Item> ps, int p) => {
                var children = all.Where(x => x.ParentId == p);
                foreach (var child in children)
                {
                    path += $"/{ child.Name}";
                    GetPath(ps, child.Id);
                }
            };
            GetPath(all, current.Id);


            return string.Join("/", path);
        }



    }
}
