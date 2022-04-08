using Microsoft.EntityFrameworkCore;
using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.DataBase.Repositories
{
    class QuestionRepository : DbRepository<Question> , IEntityRepository<Question>
    {
        public override IQueryable<Question> Items => base.Items
            .Include(item => item.User)
            .Include(item => item.Theme)
            .Include(item => item.Consultant)
            ;

        public QuestionRepository(stuff_shopContext db) : base(db) { }

        public Question Get(int id) => Items.SingleOrDefault(question => question.Id == id);
        public async Task<Question> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(question => question.Id == id, Cancel)
           .ConfigureAwait(false);

        public IQueryable<Question> GetByUser(Person user) => Items.Where(question => question.User == user);

        public IQueryable<Question> GetByQTheme(QTheme theme) => Items.Where(question => question.Theme == theme);

        public IQueryable<Question> GetByConsultant(Person consultant) => Items.Where(question => question.Consultant == consultant);

        public IQueryable<Question> GetUnanswered(int consultantId) => Items.Where(question => question.QStatus == 0 || question.ConsultantId == consultantId && question.QStatus == 1);

        public void Remove(int id)
        {
            var question = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new Question { Id = id };
            _db.Remove(question);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new Question { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
