﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Dal;
using TaskManagement.Entities;

namespace CommentManagement.Dal
{
    public class CommentDal
    {
        private readonly TaskManagementContext _context;

        public CommentDal(TaskManagementContext context)
        {
            _context = context;
        }

        public List<CommentEntity> GetComments()
        {
            return _context.Comments.ToList();
        }

        public async Task<bool> Create(CommentEntity Comment)
        {
            var res = await _context.Comments.AddAsync(Comment);
            await _context.SaveChangesAsync();
            return res.Entity.Id > 0;
        }

        public CommentEntity GetCommentById(int id)
        {
            return _context.Comments.FirstOrDefault(x => x.Id == id);
        }
    }
}