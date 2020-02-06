using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample02.Models;
using Sample02.Models.ViewModels;
using AutoMapper;

namespace Sample02.Services
{

    public class MemberService : IDisposable
    {
        private TestEntities db;

        public MemberService()
        {
            db = new TestEntities();
        }


        /// <summary>
        /// Get Single Member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MemberViewModel GetOne(int id)
        {
            var result = db.Member.Find(id);

            Mapper.Initialize(cfg => cfg.CreateMap<Member, MemberViewModel>());

            return Mapper.Map<Member, MemberViewModel>(result);
        }

        /// <summary>
        /// List Members
        /// </summary>
        /// <returns></returns>
        public List<MemberViewModel> List()
        {
            var result = db.Member.ToList();

            Mapper.Initialize(cfg => cfg.CreateMap<Member, MemberViewModel>());

            return Mapper.Map<List<Member>, List<MemberViewModel>>(result);
        }

        /// <summary>
        /// Search Members
        /// </summary>
        /// <param name="givenInfo">帳號 或 姓名</param>
        /// <returns></returns>
        public List<MemberViewModel> List(string givenInfo)
        {
            var result = db.Member
                .Where(o => o.Account.Contains(givenInfo) || o.Name.Contains(givenInfo))
                .ToList();

            Mapper.Initialize(cfg => cfg.CreateMap<Member, MemberViewModel>());

            return Mapper.Map<List<Member>, List<MemberViewModel>>(result);
        }

        /// <summary>
        /// Add Member
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public string Add(MemberViewModel viewModel)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<MemberViewModel, Member>());

            var newMember = Mapper.Map<MemberViewModel, Member>(viewModel);

            try
            {
                db.Member.Add(newMember);
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw ex;
            }

            return "新增成功";
        }

        /// <summary>
        /// Update Member
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public string Update(MemberViewModel viewModel)
        {
 
            Member member = db.Member.Find(viewModel.id);
            member.Account = viewModel.Account;
            member.Name = viewModel.Name;
            member.Gender = viewModel.Gender;
            member.Birthday = viewModel.Birthday;
            member.Title = viewModel.Title;
            member.Salary = viewModel.Salary;

            try
            {
                db.SaveChanges();
            }
            
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw ex;
            }

            return "更新成功";
        }

        /// <summary>
        /// Delete Members by id
        /// </summary>
        /// <param name="selected"></param>
        /// <returns></returns>
        public string Delete(int [] selected)
        {
            foreach (var id in selected)
            {
                db.Member.RemoveRange(db.Member.Where(o => o.id == id));
            }

            db.SaveChanges();

            return "刪除成功";
        }

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 處置 Managed 狀態 (Managed 物件)。
                }

                // TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。

                disposedValue = true;
            }
        }

        // TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放 Unmanaged 資源的程式碼時，才覆寫完成項。
        // ~MemberService()
        // {
        //   // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 加入這個程式碼的目的在正確實作可處置的模式。
        void IDisposable.Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}