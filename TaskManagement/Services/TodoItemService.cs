using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;
using TaskManagement.Services;

namespace TaskManagement.Services
{
    public class TodoItemService
    {


        private readonly TaskManagementeContext _context;

        public TodoItemService(TaskManagementeContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<TodoItem>>> index()
        {
            return await _context.TodoItem.ToListAsync();
        }

        public async Task<TodoItem> show(long id)
        {
            return await _context.TodoItem.FindAsync(id);
        }

        public async Task store(TodoItem todoItem)
        {
            _context.TodoItem.Add(todoItem);
            await _context.SaveChangesAsync();
        }


    }
}
