using System;
using System.Collections.Generic;
using TutorLinkAPI.ViewModel;
using DataLayer.Entities;
using DataLayer.DAL.Repositories;
using System.Linq;
using TutorLinkAPI.BusinessLogics.IServices;
using DataLayer.DAL;

namespace TutorLinkAPI.BusinessLogics.Services
{
    public class ApplyServices : IApplyService
    {
        private readonly IGenericRepository<Apply> _applyRepository;
        private readonly TutorDbContext _context;


        public ApplyServices(IGenericRepository<Apply> applyRepository, TutorDbContext context)
        {
            _context= context;
            _applyRepository = applyRepository;
        }

        public Apply GetApplyById(Guid applyId)
        {
            return _applyRepository.Get(a => a.ApplyId == applyId);
        }

        public Apply AddNewApply(Guid postId, Guid tutorId)
        {
            var newApply = new Apply
            {
                ApplyId = Guid.NewGuid(),
                PostId = postId,
                TutorId = tutorId,
                Status = ApplyStatuses.Pending
            };
            _context.Applies.Add(newApply);
            _context.SaveChanges();
            return newApply;
        }

        public void UpdateApplyStatus(Guid applyId, UpdateApplyViewModel model)
        {
            var apply = _applyRepository.Get(a => a.ApplyId == applyId);
            if (apply == null)
                throw new Exception("Apply not found.");

            apply.Status = model.Status;
            _applyRepository.Update(apply);
        }

        public void DeleteApply(Guid applyId)
        {
            _applyRepository.Delete(applyId);
        }

        public List<Apply> GetAppliesByTutorId(Guid tutorId)
        {
            return _applyRepository.GetList(a => a.TutorId == tutorId).ToList();
        }

        public List<Apply> GetAllApplies()
        {
            return _applyRepository.GetAll().ToList();
        }
    }
}