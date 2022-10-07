﻿using Api.Model.ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TaskManagement.models;
using TaskManagement.Services;

namespace TaskManagement.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("list")]
        public ApiResponse List()
        {
            try
            {
                return _taskService.GetTasks();
            }
            catch (Exception ex)
            {
                return new ApiResponse((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getById/{id}")]
        public ApiResponse GetById(int id)
        {
            try
            {
                return _taskService.GetTaskById(id);
            }
            catch (Exception ex)
            {
                return new ApiResponse((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ApiResponse> Create(TaskModel taskModel)
        {
            try
            {
                return await _taskService.Create(taskModel);
            }
            catch (Exception ex)
            {
                return new ApiResponse((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //[Route("Edit")]
        //public string Edit()
        //{
        //    return "";
        //}
    }
}
