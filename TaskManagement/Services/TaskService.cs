using Api.Model.ApiResponse;
using AutoMapper;
using CommentManagement.Dal;
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
        private CommentDal _commentDal;
        private readonly IMapper _mapper;

        public TaskService(TaskDal TaskDal, IMapper mapper, CommentDal commentDal)
        {
            _taskDal = TaskDal;
            _mapper = mapper;
            _commentDal = commentDal;
        }

        public ApiResponse GetTasks()
        {
            var list = _mapper.Map<List<TaskModel>>(_taskDal.GetTasks() );
            return new ApiResponse(list);
        }

        public ApiResponse GetTaskById(int id)
        {
            var taskModel = _mapper.Map<TaskModel>(_taskDal.GetTaskById(id));
            taskModel.Comments = _mapper.Map<List<CommentModel>>(_commentDal.GetComments(id));

            return new ApiResponse(taskModel);
        }

        public async Task<ApiResponse> Create(TaskModel TaskModel)
        {
            return new ApiResponse(await _taskDal.Create(_mapper.Map<TaskEntity>(TaskModel)));
        }

        public async Task<ApiResponse> AssignTask(AssignModel assignModel)
        {
            return new ApiResponse(await _taskDal.AssignTask(_mapper.Map<UserTaskEntity>(assignModel)));
        }

        public ApiResponse Edit(TaskModel model)
        {
            var task = _taskDal.GetTaskById(model.Id);
            task.Title = model.Title;
            task.Desciption = model.Description;

            _taskDal.Save();

            return new ApiResponse(task);
        }
    }
}
