using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;
using ToDoApi.Repositories.Interfaces;

namespace ToDoApi.Repositories
{
	public class ToDoRepository: IToDoRepository
    {
		private static ConcurrentDictionary<int, Item> _toDoList = new ConcurrentDictionary<int, Item>();
        public IEnumerable<Item> GetAll()
        {
            return _toDoList.Values;
        }

        public void Add(Item item)
        {
            item.id = _toDoList.Count + 1;
            _toDoList[item.id] = item;
        }

        public Item Find(int id)
        {
            Item item;
            _toDoList.TryGetValue(id, out item);
            return item;
        }

        public Item Remove(int id)
        {
            Item item;
            _toDoList.TryGetValue(id, out item);
            _toDoList.TryRemove(id, out item);
            return item;
        }

        public void Update(Item item)
        {
            _toDoList[item.id] = item;
        }
    }
}
