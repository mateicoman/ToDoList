using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;
using ToDoApi.Repositories.Interfaces;

namespace ToDoApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ToDoController : ControllerBase
	{
		readonly IToDoRepository _toDoRepository;
		public ToDoController(IToDoRepository toDoRepository)
		{
			_toDoRepository = toDoRepository;
		}
		
		public IEnumerable<Item> GetAll()
		{
			var result = _toDoRepository.GetAll();
			return result;
		}

		[HttpGet("{id}", Name = "GetItemByID")]
		public IActionResult GetById(int id)
		{
			var result = _toDoRepository.Find(id);
			if (result == null)
			{
				return NotFound();
			}
			return new ObjectResult(result);
		}

		[HttpPost]
		public IActionResult Create([FromBody] Item newItem)
		{
			if (newItem == null)
			{
				return BadRequest();
			}
			_toDoRepository.Add(newItem);
			return CreatedAtRoute("GetItemByID", new { id = newItem.id }, newItem);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] Item item)
		{
			if (item == null || item.id != id)
			{
				return BadRequest();
			}

			var todo = _toDoRepository.Find(id);
			if (todo == null)
			{
				return NotFound();
			}

			_toDoRepository.Update(item);
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_toDoRepository.Remove(id);
		}
	}
}
