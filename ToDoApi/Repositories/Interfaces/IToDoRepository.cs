using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Repositories.Interfaces
{
	public interface IToDoRepository
	{
		void Add(Item item);
		IEnumerable<Item> GetAll();
		Item Find(int id);
		Item Remove(int id);
		void Update(Item item);
	}
}
