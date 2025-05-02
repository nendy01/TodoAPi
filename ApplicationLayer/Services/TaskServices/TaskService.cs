using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.DTO;
using DomainLayer.Models; 
using InfrastructureLayer.Repositorio.Commons;

namespace ApplicationLayer.Services.TaskServices
{
    public class TaskService
    {
        private readonly ICommonsProcess<Tareas> _commonsProcess;

        public TaskService(ICommonsProcess<Tareas> commonsProcess)
        {
            _commonsProcess = commonsProcess;
        }

        public async Task<Response<Tareas>> GetTaskAllAsync()
        {
            var response = new Response<Tareas>();
            try
            {
                response.DataList = await _commonsProcess.GetAllAsync();
                response.Successful = true;
            }
            catch (Exception e)
            {
                response.Errors.Add(e.Message);
            }
            return response;
        }

        public async Task<Response<Tareas>> GetTaskByIdAsync( int id)
        {
            var response = new Response<Tareas>();
            try
            {
                var result = await _commonsProcess.GetByIdAsync(id);
                if (result != null)
                {
                    response.SingleData = result;
                    response.Successful = true;
                }
                else
                {
                    response.Successful = false;
                    response.Message = "No se encontró la tarea";
                }
                    
            }
            catch (Exception e)
            {
                response.Errors.Add(e.Message);
            }
            return response;
        }

        public async Task<Response<string>> AddTaskAsync(Tareas tarea)
        {
            var response = new Response<string>();
            try
            {
                var result = await _commonsProcess.AddAsync(tarea);
                response.Successful = result.isCompleted;
                response.Message = result.Message;
            }
            catch (Exception e)
            {
                response.Errors.Add(e.Message);
            }
            return response;
        }
        public async Task<Response<string>> UpdateTaskAsync(Tareas tarea)
        {
            var response = new Response<string>();
            try
            {
                var result = await _commonsProcess.UpdateAsync(tarea);
                response.Successful = result.isCompleted;
                response.Message = result.Message;
            }
            catch (Exception e)
            {
                response.Errors.Add(e.Message);
            }
            return response;
        }

        public async Task<Response<string>> DeleteTaskAsync(int id)
        {
            var response = new Response<string>();
            try
            {
                var result = await _commonsProcess.DeleteAsync(id);
                response.Successful = result.isCompleted;
                response.Message = result.Message;
            }
            catch (Exception e)
            {
                response.Errors.Add(e.Message);
            }
            return response;
        }
    }
} 