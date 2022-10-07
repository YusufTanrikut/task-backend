using Api.Model.ApiResponse;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Dal;
using TaskManagement.Entities;
using TaskManagement.models;

namespace TaskManagement.Services
{
    public class TaskService
    {
        private TaskDal _taskDal; 
        private readonly IMapper _mapper;

        public TaskService(TaskDal TaskDal, IMapper mapper)
        {
            _taskDal = TaskDal;
            _mapper = mapper;
        }

        public ApiResponse GetTasks()
        {
            var list = _mapper.Map<List<TaskModel>>(_taskDal.GetTasks() );
            return new ApiResponse(list);
        }

        public ApiResponse GetTaskById(int id)
        {
            var TaskModel = _mapper.Map<TaskModel>(_taskDal.GetTaskById(id));
            return new ApiResponse(TaskModel);
        }

        public async Task<ApiResponse> Create(TaskModel TaskModel)
        {
            return new ApiResponse(await _taskDal.Create(_mapper.Map<TaskEntity>(TaskModel)));
        }
    }
}
