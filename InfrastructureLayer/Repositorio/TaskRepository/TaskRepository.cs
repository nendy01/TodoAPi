using DomainLayer.Models;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositorio.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositorio.TaskRepository
{
    public class TaskRepository : ICommonsProcess<Tareas>
    {
        private readonly TodoApiContext _context;

        public TaskRepository(TodoApiContext todoApiContext)
        {
            _context = todoApiContext;
        }

        public async Task<(bool isCompleted, string Message)> AddAsync(Tareas entity)
        {
            try
            {
                await _context.Tareas.AddAsync(entity);
                await _context.SaveChangesAsync();
                return (true, "tarea guardada");
            }
            catch (Exception ex)
            {
                return (false, "no se pudo guardar la tarea");
            }
        }

        public async Task<IEnumerable<string>> AddAsync()
        {
            throw new NotImplementedException("This method is not implemented.");
        }

        public async Task<(bool isCompleted, string Message)> DeleteAsync(int id)
        {
            try
            {
                var tarea = await _context.Tareas.FindAsync(id);
                if (tarea != null)
                {
                    _context.Tareas.Remove(tarea);
                    await _context.SaveChangesAsync();
                    return (true, "la tarea fue eliminada");
                }
                else
                {
                    return (false, "no se encontro la tarea");
                }
            }
            catch (Exception)
            {
                return (false, "no se pudo eliminar la tarea");
            }
        }

        public async Task<IEnumerable<Tareas>> GetAllAsync()
        => await _context.Tareas.ToListAsync();

        public async Task<Tareas> GetByIdAsync(int id)
        => await _context.Tareas.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<(bool isCompleted, string Message)> UpdateAsync(Tareas entity)
        {
            try
            {
                _context.Tareas.Update(entity);
                await _context.SaveChangesAsync();
                return (true, "tarea actualizada");
            }
            catch (Exception ex)
            {
                return (false, "no se pudo actualizar la tarea");
            }
        }
    }
}
